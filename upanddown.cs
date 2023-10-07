using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upanddown : MonoBehaviour
{   public Transform highpoint, lowpoint;
    public float highy, lowy;
    private Rigidbody2D rb;
    public GameObject player;
    public playererer playerc;
    public bool shouldup=true;
    // Start is called before the first frame update
    void Start()
    {   rb = GetComponent<Rigidbody2D>();
        highy = highpoint.position.y;
        lowy = lowpoint.position.y;
        Destroy(highpoint.gameObject);
        Destroy(lowpoint.gameObject);
        player = GameObject.Find("Player");
        playerc = player.GetComponent<playererer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldup)
        {
             rb.velocity = new Vector2(rb.velocity.y, 0.5f);
        }
        else
        {
             rb.velocity = new Vector2(rb.velocity.y, -0.5f);
        }
        if(transform.position.y>highy)
        {
            shouldup=false;
        }
        if(transform.position.y<lowy)
        {
            shouldup=true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player")
        {
            playerc.Qmax++;
            Destroy(gameObject);
        }
    }
}
