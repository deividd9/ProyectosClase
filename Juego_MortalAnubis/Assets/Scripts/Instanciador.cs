using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{

    [SerializeField] float limit;
    [SerializeField] float initPos;
    [SerializeField] GameObject escenario;

    bool instanciado = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < limit && instanciado == false)
        {
            Instantiate(escenario, new Vector3(initPos, 0f, 0f), Quaternion.identity);
            instanciado = true;
        }

        if(transform.position.x < limit - 100)
        {
            Destroy(gameObject);
        }
    }
}
