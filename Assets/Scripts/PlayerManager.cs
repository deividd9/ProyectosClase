using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour

{
    // Velocidad obstaculos

    public float speed;

    InputActions inputActions;

    [SerializeField] float desplSpeed = 0f;

    //Boleana vivo/muerto
    public bool alive;

    //Conocer si el juego se ha iniciado o no
    public bool juegoIncio = false;


    // Stick izquierdo

    float joyV;
    float joyH;

    Vector2 leftStick;


    // Stick derecho
    //float rotation;

    // Variables para la restringir movimiento X e Y

    float limiteUP = 25f;
    float limiteDOWN = 1f;
    float limiteLEFT = -10f;
    float limiteRIGHT = 70f;
    float posY;
    float posX;

    //booleanas para limitar movimiento
    bool EnLimiteV;
    bool EnLimiteH;

    //Variables para poder utilizar el SmoothDamp, suavizando asi el giro
    public Transform target;
    //[SerializeField] float smoothTime = 0.8f;
    private Vector3 velocity = Vector3.zero;

    //Variable para hacer q la nave desaparezca
    [SerializeField] GameObject nave;

    //Actualizar el HUD en el juego
    [SerializeField] CanvasManager canvasManager; 

    private void Awake()
    {
        inputActions = new InputActions();

        /*  inputActions.Player.Move.performed += ctx => leftStick = ctx.ReadValue<Vector2>();
          inputActions.Player.Move.canceled += _ => leftStick = Vector2.zero;
        */

        inputActions.Player.JV.performed += ctx => joyV = ctx.ReadValue<float>();
        inputActions.Player.JV.canceled += _ => joyV = 0f;
        inputActions.Player.JH.performed += ctx => joyH = ctx.ReadValue<float>();
        inputActions.Player.JH.canceled += _ => joyH = 0f;

        speed = 120f;

        GameManager.lifes = 3;
    }

    // Start is called before the first frame update
    void Start()
    {

        // Desplazamiento de la nave

        desplSpeed = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        MoverNave();
        CheckLimits();
    }


    void MoverNave()
    {
        //Mido mi posicion en todo momento
        posX = transform.position.x;
        posY = transform.position.y;

        //rotation = 0f;

        /* Vector3 despl = Vector3.up * speed * Time.deltaTime;
        initPos = initPos + despl;
        transform.position = initPos; */


        // Movimiento de la nave horizontal y vertical, con respecto al mundo
        
        if (EnLimiteV == true)
            transform.Translate(Vector3.up * desplSpeed * joyV * Time.deltaTime, Space.World);

        if(EnLimiteH == true)
            transform.Translate(Vector3.right * desplSpeed * joyH * Time.deltaTime, Space.World);


        

        Vector3 targetRotation = transform.eulerAngles = new Vector3(joyV * -30f, 0f, joyH * -20f);


        //transform.eulerAngles = new Vector3(joyV * -30f, 0f, joyH * -45f);
        //El SmoothDamp cambia de forma  gradual el valor del vector hasta un valor definido en un tiempo concreto.

        //transform.eulerAngles = Vector3.SmoothDamp(transform.eulerAngles, targetRotation, ref velocity, smoothTime);
    }

    void CheckLimits()
    {
        //RestriccionVertical

        if (posY > limiteUP && joyV > 0)
        {
            EnLimiteV = false;
        }
        else if (posY < limiteDOWN && joyV < 0)
        {
            EnLimiteV = false;
        }
        else
        {
            EnLimiteV = true;

            if (EnLimiteV)
                transform.Translate(Vector3.up * desplSpeed * joyV * Time.deltaTime, Space.World);
        }

        // RestriccionHorizontal

        if (posX > limiteRIGHT && joyH > 0)
        {
            EnLimiteH = false;
        }
        else if (posX < limiteLEFT && joyH < 0)
        {
            EnLimiteH = false;
        }
        else
        {
            EnLimiteH = true;
        }

        if (EnLimiteH == true)
            transform.Translate(Vector3.right * desplSpeed * joyH * Time.deltaTime, Space.World);

    }
    private void OnTriggerEnter(Collider other)
    {

        GameManager.lifes--;

        canvasManager.UpdateLifes();

        if(GameManager.lifes == 0)
        {
            speed = 0f;
            desplSpeed = 0f;
            nave.SetActive(false);
            canvasManager.MostrarGameOver();
        }
        
    }


    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

}
