using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraRotate : MonoBehaviour
{   public Transform target;
    // Update is called once per frame
    void FixedUpdate()
    {   
        transform.LookAt(target);
    }
}
