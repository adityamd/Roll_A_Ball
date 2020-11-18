using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{   public GameObject target;
    private float offset;
    // Update is called once per frame
    void Start(){
        offset=transform.position.z-target.transform.position.z;
    }
    void FixedUpdate()
    {   
        Vector3 new_position=new Vector3(transform.position.x,transform.position.y,target.transform.position.z+offset);
        transform.position=new_position;
    }
}
