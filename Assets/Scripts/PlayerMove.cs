using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{   private Rigidbody rb;
    public Text countText;
    public Text EndText;
    public Text timeText;
    private int count;
    public float speed;
    private int time;
    private float startTime;
    private bool timeOut;
    private bool timeStop;
    // Start is called before the first frame update
    void Start()
    {   count=0;
        timeStop=false;
        timeOut=false;
        time=80;
        startTime=Time.time;
        rb = GetComponent<Rigidbody>();
        countText.text="Blocks Collected: " + count;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   if(!timeStop){
        time-=1;
        float t=Time.time-startTime;
        timeText.text=((80-(int)t).ToString());
        if(timeText.text.Equals("0")){
            timeOut=true;
            timeStop=true;
            GetComponent<PlayerMove>().enabled=false;
             EndText.text="TimeOut!!!";
            EndText.gameObject.SetActive(true);
        }
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
        if(transform.position.z<=-1.39){
            movement = new Vector3(-1*moveHorizontal,0.0f,moveVertical);
        }
        rb.AddForce(movement*speed);
    }

    void OnTriggerEnter(Collider col){
        if(!timeOut){
        if(col.gameObject.CompareTag("Pickup"))
        col.gameObject.SetActive(false);
        count++;
        countText.text="Blocks Collected: " + count;
        if(count==16){
            GetComponent<PlayerMove>().enabled=false;
            EndText.text="You Win!!!";
            timeStop=true;
            EndText.gameObject.SetActive(true);
        }
        }
    }
}