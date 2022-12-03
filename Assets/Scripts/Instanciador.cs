using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    [SerializeField] GameObject Obstacle;
    [SerializeField] Transform instPos;

    [SerializeField] PlayerManager playerManager;

    //Intervalo de la corrutina
    float intervalo;
    float distanciaEntreObstaculos;
    float speed;

    float obstacleInicial;
    float distIntermedia;
    float distPrimer = 100f;

    //rango aleatorio instanciacion
    float randomX;
    float randomRangeX = 40f;
    
    // Start is called before the first frame update
    void Start()
    {
        distanciaEntreObstaculos = 20f;
        speed = playerManager.speed;
        intervalo = distanciaEntreObstaculos / speed;

        StartCoroutine("Iniciar");

        CrearIniciales();

    }

    void CrearIniciales()
    {
        distIntermedia = transform.position.z - distPrimer;
        obstacleInicial = Mathf.Floor(distIntermedia / distanciaEntreObstaculos);

        float posZ = distPrimer;
        for (int n = 0; n < obstacleInicial; n++)
        {

            CrearObstaculo(posZ);
            posZ += distanciaEntreObstaculos;
        }

        /*
        float posZ = 60f;
        for(int n = 0; n < 100; n++)
        {
            CrearObstaculo(posZ);
            posZ += 10f;
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        speed = playerManager.speed;
        intervalo = distanciaEntreObstaculos / speed;
    }

    void CrearObstaculo(float posZ)
    {
        randomX = Random.Range(-randomRangeX, randomRangeX);
        Vector3 randomPos = new Vector3(randomX, instPos.position.y, posZ);
        Instantiate(Obstacle, randomPos, Quaternion.identity);
    }

    IEnumerator Iniciar()
    {

        while (true)
        {
            CrearObstaculo(transform.position.z);
            yield return new WaitForSeconds(intervalo);

        }
    }
}