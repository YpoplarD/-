using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletplane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   private void OnTriggerEnter2D(Collider2D col) {
    //print("222");
    if (col.CompareTag("endfly") )
        {   
            Destroy(gameObject);
        }
   }
}
