using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biggear : MonoBehaviour
{   public timecontrol tcl;//UI脚本
    public playererer playerc;//玩家脚本
    float value=0;
    private Rigidbody2D rb;
    public GameObject player;
    public bool nearpalyer = false;
    public goarworkingjudge workjudge;
    public float geartype = 1;
    // Start is called before the first frame update
    void Start()
    {   player = GameObject.Find("Player");
        playerc = player.GetComponent<playererer>();
        GameObject timecontroller = GameObject.Find("timecontroller");
        tcl = timecontroller.GetComponent<timecontrol>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   if(workjudge.havingskill){
        value = tcl.value;}
        else
        value = 0;
        if(value==0)
        transform.Rotate(Vector3.forward, geartype*(-0.1f), Space.Self);
        transform.Rotate(Vector3.forward, 0.03f*value, Space.Self);
        
        
        //print(value);
    }
   
   
}
