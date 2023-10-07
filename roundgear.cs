using Erinn;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundgear : MonoBehaviour
{  public timecontrol tcl;//UI脚本
    public playererer playerc;//玩家脚本
    float value=0;
    private Rigidbody2D rb;
    public GameObject player;
    public bool nearpalyer = false;
    public goarworkingjudge workjudge;
    public float speed;
    public float rota;
    // Start is called before the first frame update
    void Start()
    {   
        rota=transform.rotation.z;
        player = GameObject.Find("Player");
        playerc = player.GetComponent<playererer>();
        GameObject timecontroller;
         if(workjudge.freeze==0)
        timecontroller = GameObject.Find("timecontroller");
        else if(workjudge.freeze==1)
        timecontroller = GameObject.Find("freezecontroller");
        else 
        timecontroller = GameObject.Find("freezecontroller2");

        
        tcl = timecontroller.GetComponent<timecontrol>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   if(tcl.working)
        {
            workjudge.controller.SetActive(true);
            workjudge.havingskill = true;
        }
        else
        {
            workjudge.controller.SetActive(false);
            workjudge.havingskill = false;
        }
        if(workjudge.havingskill){
        value = tcl.value;}
        else
        value = 0;
        if(value==0)
        {if(transform.rotation.z>rota+0.01)
            transform.Rotate(Vector3.forward, -0.05f, Space.Self);
         else if(transform.rotation.z<rota-0.01)
          transform.Rotate(Vector3.forward, 0.05f, Space.Self);
        }
        
        
        transform.Rotate(Vector3.forward, 0.03f*value, Space.Self);
    }
}
