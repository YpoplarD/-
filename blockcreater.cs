using KickHuXiaoYu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockcreater : MonoBehaviour
{
    public GameObject death;
    public TestFallDead deathc;
    public GameObject blockprefab;
    public float deathight;
    public GameObject child;
    public playererer playerc;
    // Start is called before the first frame update
    void Start()
    {
        death = GameObject.Find("À§À¿");
        deathc = death.GetComponent<TestFallDead>();
        deathight = deathc.DeadHeight;
        GameObject player = GameObject.Find("Player");
        playerc = player.GetComponent<playererer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(child.transform.position.y < deathight)
        {
            creatblock();
        }
        if(playerc.nearsave&&Input.GetKeyDown(KeyCode.E)) {
            
            creatblock();
        }
        
    }
    public void creatblock()
    {
        GameObject anotherchild = child;
        child = null;
        Destroy(anotherchild);
        child = Instantiate(blockprefab, transform.position, transform.rotation);
    }
}
