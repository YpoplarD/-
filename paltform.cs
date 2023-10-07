using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paltform : MonoBehaviour
{
    // Start is called before the first frame update
    public timecontrol tcl;
    float value;
    
    private Rigidbody2D rb;
    public Transform highpoint, lowpoint, midpoint;
    public float highy, lowy, midy;
    public playererer playerc;
    public float Speed;
    public GameObject player;
    public goarworkingjudge workjudge;
    void Start()
    {   GameObject timecontroller;
        
        if(workjudge.freeze==0)
        timecontroller = GameObject.Find("timecontroller");
        else if(workjudge.freeze==1)
        timecontroller = GameObject.Find("freezecontroller");
        else 
        timecontroller = GameObject.Find("freezecontroller2");

        
        tcl = timecontroller.GetComponent<timecontrol>();
        
        player = GameObject.Find("Player");
        playerc = player.GetComponent<playererer>();
        rb = GetComponent<Rigidbody2D>();
        midy = transform.position.y;
        highy = highpoint.position.y;
        lowy = lowpoint.position.y;
        Destroy(highpoint.gameObject);
        Destroy(lowpoint.gameObject);
    }
    private void FixedUpdate() {
        if (tcl.working&&workjudge.freeze!=0)
        {
            workjudge.controller.SetActive(true);
            workjudge.havingskill = true;
        }
        else if(workjudge.freeze>0)
        {
            workjudge.controller.SetActive(false);
            workjudge.havingskill = false;
        }
        if (workjudge.havingskill)
        {   //print(value);
            value = tcl.value;
            if (value < 0)
            {
                if (transform.position.y <= highy)
                {

                    rb.velocity = new Vector2(rb.velocity.x,1.5f);
                }

            }
            else if (value > 0)
            {
                if (transform.position.y >= lowy)
                {
         
                    rb.velocity = new Vector2(rb.velocity.x, -1.5f);
                }

            }
        }
        else
        value = 0;
        if (value == 0)
        {
            if (transform.position.y > midy + 0.1)
                rb.velocity = new Vector2(rb.velocity.x, -(Speed * 0.2f));
            else if (transform.position.y < midy - 0.1)
                rb.velocity = new Vector2(rb.velocity.x, Speed * 0.2f);
            else rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        if ((transform.position.y > highy && value < 0) || (transform.position.y < lowy && value > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        if(workjudge.nearpalyer)
        {
            
            float ydistance = transform.position.y-player.transform.position.y;
            if(ydistance>0 && ydistance<1.5&&value>=0)
            {  
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
    }
    
   
}
