using System.Collections;
using System.Collections.Generic;
using KickHuXiaoYu;

using UnityEngine;
using UnityEngine.UI;
public class goarworkingjudge : MonoBehaviour
{   public timecontrol tcl; 
    public GameObject player;
     public playererer playerc;
     public bool nearpalyer = false;
     public float distance;
     public GameObject controller;
     public bool havingskill = false;
     public float stopdistance=10;
     public Sprite gearbase0,gearbase1,gearbase2,gearbase3;
     public int freeze=0;
     public GameObject gearbase;
     public int goarnumber=0;
     public TestButton tsb;
     public int freezennumber;
    // Start is called before the first frame update
    void Start()
    {
        GameObject timecontroller = GameObject.Find("timecontroller");
        tcl = timecontroller.GetComponent<timecontrol>();
        player = GameObject.Find("Player");
        playerc = player.GetComponent<playererer>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(freeze==0){
            if(tcl.superworking&&!havingskill)
            {
                startwork();
               ;
            }
            else if (!tcl.superworking&&!tcl.nomalworking) { 
                stopwork();
                tcl.stopjudge();
                tcl.nomalworking = true;
                if (goarnumber != 0)
                {
                    playerc.Qnumber=0;
                    goarnumber = 0;
                }
            }
            if(tcl.nomalworking&& playerc.Qnumber<=0&&havingskill)
            {
                stopwork();
                tcl.stopjudge();
                if (goarnumber != 0)
                {
                    playerc.Qnumber = 0;
                    goarnumber = 0;
                }
            }
        if(nearpalyer&&!havingskill)
        nearplayererer();
        if(havingskill&&!tcl.superworking)
        {distance = (transform.position - player.transform.position).magnitude;
         if(distance>stopdistance)
         {  
            havingskill=false;
            playerc.Qnumber--;
            goarnumber=0;
            controller.SetActive(false);
            tcl.stopjudge();
         }
         if(Input.GetKeyDown(KeyCode.F))
         {
                    if (goarnumber == playerc.Qnumber)
                    {
                        stopwork();
                        playerc.Qnumber--;
                    }
                    
                    tcl.stopjudge();
 
         }
        }}
        
    }
    void nearplayererer(){
         if(playerc.Qnumber<playerc.Qmax&&Input.GetKeyDown(KeyCode.Q))
            {
            startwork();
            playerc.Qnumber++;
            goarnumber = playerc.Qnumber;
        }
    }
    public void stopwork()
    {
       
           // print("stop");
            havingskill = false;
            controller.SetActive(false);
            goarnumber = 0;
            tcl.stopjudge();
           
    }
    public void startwork()
    {
        //print("start");
        controller.SetActive(true);
        havingskill = true;
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (freeze==0&&other.tag == "Player")
        {   player = other.gameObject;
            playerc = player.GetComponent<playererer>();
            nearpalyer = true;
            gearbase.GetComponent<SpriteRenderer>().sprite = gearbase1;
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (freeze==0&&other.tag == "Player")
        {
            nearpalyer = false;
            gearbase.GetComponent<SpriteRenderer>().sprite = gearbase0;
        }
    }
}
