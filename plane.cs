using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plane : MonoBehaviour
{  
    public GameObject planeprefab;
    public GameObject endcloud;
    public float firecd = 5f;
    public float firetimer = 0f;
    public float flyway=3f;
    // Start is called before the first frame update
    void Start()
    {
     if(endcloud.transform.position.x<gameObject.transform.position.y)
     flyway = -flyway;
    }

    // Update is called once per frame
    void Update()
    {
      if (Time.time > firetimer)
      {
      firetimer = Time.time + firecd;
      
      GameObject bullet = Instantiate(planeprefab,transform.position,transform.rotation);
      
      bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(flyway,0);
      if(flyway>0)
      {
        bullet.transform.localScale = new Vector3(2f,2f,1f);
      }
      else
      {
         bullet.transform.localScale = new Vector3(-2f,2f,1f);
      }
      }
    }
}
