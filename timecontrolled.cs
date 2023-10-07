using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timecontrolled : MonoBehaviour
{   public goarworkingjudge workjudge;
    public timecontrol tcl;
    float value;
    private void Start() {
        GameObject timecontroller;
         if(workjudge.freeze==0)
        timecontroller = GameObject.Find("timecontroller");
        else if(workjudge.freeze==1)
        timecontroller = GameObject.Find("freezecontroller");
        else 
        timecontroller = GameObject.Find("freezecontroller2");
        tcl = timecontroller.GetComponent<timecontrol>();
    }
    private void Update() {

        value = tcl.value;
        transform.Rotate(Vector3.forward, value, Space.Self);
        if(value==0)
        {  
            transform.Rotate(Vector3.forward, 0, Space.Self);
        }
        
        
        
    }
}
