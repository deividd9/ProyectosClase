using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstObstacle : MonoBehaviour
{
    [SerializeField] GameObject bolos;
    Vector3 instPos;
    Transform otroPos;

    //Numero de enemigos
    int enemies = 2;
    //Separacion
    float sep = 2f;

    //Intervalo de creacion de enemigos
    float intervalo = 1f;

    //Variables de movimiento
    float desplSpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine("CorrutinaEnemigos");
        //CrearEnemigos();

        //instPos = otroPos.position;
    }

    void CrearEnemigos()
    {
        instPos = transform.position;

        for (int n = 0; n < enemies; n++)
        {


            Instantiate(enemigoPrefab, instPos, Quaternion.identity);

            Vector3 sumaVector = new Vector3(0f, 0f, sep);
            instPos = instPos + sumaVector;
        }
    }

    // Update is called once per frame
    void Update()
    {
        instPos = transform.position;

        transform.Translate(Vector3.right * desplSpeed * Time.deltaTime);

    }

    IEnumerator CorrutinaEnemigos()
    {
        while(true)
        {

            CrearEnemigos();

            yield return new WaitForSeconds(intervalo);

            
        }
    }
}
