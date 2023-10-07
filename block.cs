using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class block : MonoBehaviour
{
    public bool onplatform;
    public Rigidbody2D platform2d;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onplatform)
        {
            if (platform2d == null)
            {
                onplatform = false;
            }
            rb.velocity = new Vector2(platform2d.velocity.x*1.08f, platform2d.velocity.y);

        }
    }
}
