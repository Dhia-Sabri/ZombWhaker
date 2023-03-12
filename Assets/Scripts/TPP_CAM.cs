
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPP_CAM : MonoBehaviour
{    
    float rotationX = 0f;
    public float sensitivity = 15f;
    void Update()
    {        
        rotationX += Input.GetAxisRaw("Mouse Y") * sensitivity;
        transform.localEulerAngles = new Vector3(rotationX, 0, 0);
    }
}
