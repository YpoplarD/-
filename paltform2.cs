using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paltform2 : MonoBehaviour
{
    public timecontrol tcl;
    float value;
    public GameObject father;
    private Rigidbody2D rb;
    public Transform leftpoint, rightpoint, midpoint;
    public float leftx, rightx, midx;
    public playererer playerc;
    public float Speed;
    public GameObject player;
    public goarworkingjudge workjudge;




    void Start()
    {   if(father==null)
    {
        father=gameObject;
    }
        GameObject timecontroller = GameObject.Find("timecontroller");
        tcl = timecontroller.GetComponent<timecontrol>();
        player = GameObject.Find("Player");
        playerc = player.GetComponent<playererer>();
        rb = father.GetComponent<Rigidbody2D>();
        midx = transform.position.x;
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }
    private void FixedUpdate()
    {
        if (workjudge.havingskill)
        {   //Debug.Log(1);
            value = tcl.value;
            if (value < 0)
            {
                if (transform.position.x <= rightx)
                {

                    rb.velocity = new Vector2(2.5f, rb.velocity.y);

                }

            }
            else if (value > 0)
            {
                if (transform.position.x >= leftx)
                {

                    rb.velocity = new Vector2(-2.5f, rb.velocity.y);

                }

            }
        }
        else
            value = 0;
        if (value == 0)
        {
            if (transform.position.x > midx + 0.1)
                rb.velocity = new Vector2(-(Speed * 0.2f), rb.velocity.y);
            else if (transform.position.x < midx - 0.1)
                rb.velocity = new Vector2(Speed * 0.2f, rb.velocity.y);
            else rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if ((transform.position.x > rightx && value < 0) || (transform.position.x < leftx && value > 0))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
    // Update is called once per frame
    void Update()
    {



    }
}
