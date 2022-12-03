using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{

    //[SerializeField] GameObject estrellas;
    [SerializeField] SpriteRenderer estrellasRenderer;
    // Start is called before the first frame update
    void Start()
    {
        //estrellas.SetActive(false);
        estrellasRenderer.color = new Color(255, 255, 255, 0);
    }

    void PintarEstrellas()
    {
        //estrellas.SetActive(true);
        StartCoroutine("Aparecer");
        
    }

    void BorrarEstrellas()
    {
        StartCoroutine("Desaparecer");
        //estrellas.SetActive(false);
    }

    IEnumerator Aparecer()
    {
      
        float a = 0;
        
        while(true)
        {
            estrellasRenderer.color = new Color(255, 255, 255, a);
            a += 0.05f;
            
            yield return new WaitForSeconds(0.05f);

            if(a == 1)
            {
                StopAllCoroutines();
            }

        }
    }

    

    IEnumerator Desaparecer()
    {
        float a = 1;

        while (true)
        {
            estrellasRenderer.color = new Color(255, 255, 255, a);
            a -= 0.05f;

            yield return new WaitForSeconds(0.05f);

            if (a == 0)
            {
                StopAllCoroutines();
            }

        }
    }
}
