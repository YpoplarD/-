using System.Collections;
using System.Collections.Generic;
using KickHuXiaoYu;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Erinn;

public class playererer : MonoBehaviour
{
    public bool nearsave=false ;
    [Header("移动相关")]
    public Rigidbody2D rb;
    public float speed;
    public Collider2D coll;
    public float jumpforc;
    public Animator runanima;
    public LayerMask ground;
    public int jumpnumber = 0;
    public bool onplatform = false;
    public Rigidbody2D platform2d;
    public float beforejump = 0.1f;
    public Audiomanager audiomanager;
    [Header("技能相关")]
    public bool Qskill = false;
    public int Qmax = 3;
    public int Qnumber = 0;
    public bool nearorgan = false;
    public float standcd = 5f;
    public float standtimer = 5f;
    private float hormove;
    public bool cloudworking = false;
    // Start is called before the first frame update
    void Start()
    {
        TestHuXiaoYu.Save();
        SaveData.Pos = transform.position;
        audiomanager = Audiomanager.Instance;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {  
        if (Input.GetButtonDown("Jump") && jumpnumber < 1)
        {
            
            jumpnumber++;
            rb.velocity = new Vector2(rb.velocity.x, jumpforc);
            runanima.SetBool("jumping", true);
            runanima.SetBool("standing", false);
            runanima.SetBool("walking", false);
            jumpaudio();

        }
        if (coll.IsTouchingLayers(ground)&&jumpnumber>0)
        {  
            if (runanima.GetBool("falling")&&rb.velocity.y<=0)
            {
               // print("there");
                runanima.SetBool("falling", false);
                jumpnumber = 0;
                if (hormove == 0)
                {
                    runanima.SetBool("standing", true);
                }
                else
                {
                    runanima.SetBool("walking", true);
                }
            }

        }
        
    }

    public bool CanWalk=true;
    
    void Update()
    {
        if (!CanWalk)
        {
            runanima.SetBool("walking", false);
            runanima.SetBool("standing", true);
            audiomanager.stopsfx();
            return;
        }
            
        if(!runanima.GetBool("walking")&&!runanima.GetBool("jumping")&&!runanima.GetBool("falling"))
         {  
            
            audiomanager.stopsfx();
        }
        
        aboutanima();
        movement();
        if (Input.GetButtonDown("Jump") && jumpnumber < 1)
        {
            jumpaudio();
            jumpnumber++;
            rb.velocity = new Vector2(rb.velocity.x, jumpforc);
            runanima.SetBool("jumping", true);
            runanima.SetBool("standing", false);
            runanima.SetBool("walking", false);
        }
    }
    void aboutaudio()
    {

        audiomanager.playsfx(audiomanager.run);
      
    }
    void jumpaudio()
    {
        audiomanager.stopsfx();
        audiomanager.playoneshotaudio(audiomanager.jump);
        
    }
    void aboutanima()
    {
        if (standtimer > -1)
            standtimer -= Time.deltaTime;
        if (standtimer <= -1)
        {
            standtimer = standcd;
        }
        runanima.SetFloat("standcd", standtimer);

        if (runanima.GetBool("jumping"))
        {
            if (rb.velocity.y <= 0)
            {
                runanima.SetBool("jumping", false);
                runanima.SetBool("falling", true);

            }
        }
        if (runanima.GetBool("falling"))
        {
            if (rb.velocity.y == 0 && coll.IsTouchingLayers(ground))
            {
                
                runanima.SetBool("falling", false);
                runanima.SetBool("standing", true);
                jumpnumber = 0;
            }
            else if (rb.velocity.y > 0)
            {
                runanima.SetBool("falling", false);
                runanima.SetBool("jumping", true);
            }
        }

        else if (runanima.GetBool("standing"))
        {
            if (rb.velocity.y < -3)
            {
                runanima.SetBool("falling", true);
                runanima.SetBool("standing", false);
            }
            if (hormove != 0)
            {
                if (!runanima.GetBool("walking"))
                { runanima.SetBool("walking", true);
                runanima.SetBool("standing", false);
                aboutaudio();
            }
               
                
            }
            else
            {
                runanima.SetBool("walking", false);
                runanima.SetBool("standing", true);
            }

        }




    }

    void movement()
    {
        
        float faced = Input.GetAxisRaw("Horizontal");
        hormove = Input.GetAxis("Horizontal");
        

        if (!onplatform)
        {
            if (hormove != 0)
            {
                rb.velocity = new Vector2(hormove * speed, rb.velocity.y);
                
               
            }
            else
            {   
                runanima.SetBool("walking", false);
                runanima.SetBool("standing", true);
            }
        }
        else
        {
            if (platform2d == null)
            {
                onplatform = false;
            }
            else if (!Input.GetButtonDown("Jump"))
            {
                
                rb.velocity = new Vector2(hormove * speed + platform2d.velocity.x * 1.08f,rb.velocity.y );
            }
            else if(Input.GetButtonDown("Jump") && jumpnumber < 1)
            {
                jumpaudio();
                jumpnumber++;
                rb.velocity = new Vector2(hormove * speed + platform2d.velocity.x * 1.08f, jumpforc);
                runanima.SetBool("jumping", true);
                runanima.SetBool("standing", false);
                runanima.SetBool("walking", false);
            }
        }
        if (faced != 0)
        {
            transform.localScale = new Vector3(faced, 1, 1);
        }
        
        
            if (rb.velocity.y < 0.1 && coll.IsTouchingLayers(ground))
            {
                jumpnumber = 0;
                runanima.SetBool("jumping", false);
                runanima.SetBool("standing", true);

            }
        
    }
    void Qskill1()
    {

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "organ")
            nearorgan = true;
        if(other.CompareLayer(7))
        {
            cloudworking = true;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "organ")
            nearorgan = false;
        if (other.CompareLayer(7))
        {
            cloudworking =false;
        }
    }

}
