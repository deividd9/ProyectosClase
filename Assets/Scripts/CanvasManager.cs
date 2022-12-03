using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    PlayerManager playerManager;
    GameManager gameManager;
    [SerializeField] Image lifesImage;
    [SerializeField] GameObject gameOver;
    [SerializeField] Sprite[] lifesSprite;
    [SerializeField] Button BTN_Retry;
    [SerializeField] Text TEXT_Points;
    [SerializeField] float distancia;

    
        // Start is called before the first frame update
    void Start()
    {
        lifesImage.sprite = lifesSprite[GameManager.lifes];
        gameOver.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        //Distance();
    }
    public void UpdateLifes()
    {
        lifesImage.sprite = lifesSprite[GameManager.lifes];
    } 

    public void ActivarGameOver()
    {
        gameOver.SetActive(true);

    }
    
    public void MostrarGameOver()
    {
        Invoke("ActivarGameOver", 1.5f);
        BTN_Retry.Select();

    }

    void Distance ()
    {
        distancia += playerManager.speed * Time.deltaTime;
        TEXT_Points.text = distancia + "mts";
    }
    
   
}
