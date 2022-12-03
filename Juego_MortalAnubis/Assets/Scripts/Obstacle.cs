using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{

    [SerializeField] GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = GameObject.Find("Canvas");
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.alive = false;
            Destroy(collision.gameObject);
            gameOver.SetActive(true);
            Invoke("Reload", 3f);
        }
    }

    void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
