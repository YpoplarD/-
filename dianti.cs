using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dianti : MonoBehaviour
{   public GameObject child1;
    private Rigidbody2D rb;
    private float highy;
    public bool canmove=true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        highy = child1.transform.position.y;
        Destroy(child1);
    }

    // Update is called once per frame
    void Update()
    {
        if(canmove&&transform.position.y<highy)
        {
            rb.velocity = new Vector2(rb.velocity.x, 2f);
        }
        else
        {  canmove = false;
           rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
