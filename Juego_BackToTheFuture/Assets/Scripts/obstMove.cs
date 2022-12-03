using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstMove : MonoBehaviour
{
    [SerializeField] GameObject nave;
    [SerializeField] PlayerManager naveObj;

    float speed;
    Vector3 despl = Vector3.back;

    float posZ;
    // Start is called before the first frame update
    void Start()
    {
        nave = GameObject.Find("nave");
        naveObj = nave.GetComponent<PlayerManager>();

    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        Destruir();
    }

    void Mover()
    {
        speed = naveObj.speed;
        transform.Translate(despl * speed * Time.deltaTime);
    }

    void Destruir()
    {
        posZ = transform.position.z;
        if (posZ < -10f)
        {
            Destroy(gameObject);
        }

    }
}