using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform nave;
    [SerializeField] float offsetPosZ;
    [SerializeField] float offsetPosY;
    [SerializeField] float offsetPosX;



    // Start is called before the first frame update
    void Start()
    {
        offsetPosZ = 9f;
        offsetPosY = -0.2f;
        offsetPosX = 1.3f;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = nave.position - new Vector3(offsetPosX, offsetPosY, offsetPosZ);
        transform.position = newPos; 
    }
}

