using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diantigear : MonoBehaviour
{   public dianti father;
    public GameObject player;
    private float distance;
    public float stopdistance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(father.canmove)
        {
            transform.Rotate(Vector3.forward, -0.4f, Space.Self);
        }
        distance = (transform.position - player.transform.position).magnitude;
        if(distance>stopdistance)
         {
            
            gameObject.SetActive(false);
            
         }
    }
}
