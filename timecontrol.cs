using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class timecontrol : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool superworking;
    public bool nomalworking=true;
    [SerializeField] private Canvas m_Canvas;
    public float value;
    public bool working = false;
    public playererer playerc;
    public UnityEngine.UI.Image smallgear;
    public int workingnumber;
    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerc = player.GetComponent<playererer>();
    }
    private void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Q)&&gameObject.name=="timecontroller")
        {
            if (!working && playerc.nearorgan)
            {   
               startwork();
            }
        }
        

    }
    public void startwork(){
                working = true;
                Color c = smallgear.color;
                c.a = 1f;
                smallgear.color = c;
    }
    public void stopjudge(){
        if(playerc.Qnumber==0)
           {   
                working = false;
                Color c = smallgear.color;
                c.a = 0.5f;
                smallgear.color = c;
            }
    }
    public void freezestopjudge(){
        if(workingnumber==0)
        {
            working = false;
                Color c = smallgear.color;
                c.a = 0f;
                smallgear.color = c;
        }
    }
    private Vector3? CalculateWorldToScreenPos(Vector3 worldPos)
    {
        if (m_Canvas.renderMode == RenderMode.ScreenSpaceCamera)
        {
            return m_Canvas.worldCamera.WorldToScreenPoint(worldPos);
        }
        else if (m_Canvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            Vector3 screenPos = m_Canvas.transform.InverseTransformPoint(worldPos);
            var rectTrans = m_Canvas.transform as RectTransform;
            screenPos.x += rectTrans.rect.width * 0.5f * rectTrans.localScale.x;
            screenPos.y += rectTrans.rect.height * 0.5f * rectTrans.localScale.y;

            return screenPos;
        }

        return null;
    }
    [SerializeField] private float m_RotateSpeed;

    public void OnDrag(PointerEventData eventData)
    {
        if (working)
        {
            if (eventData.button != PointerEventData.InputButton.Left) return;

            //手指滑动偏移量
            Vector2 mouseXY = eventData.delta;
            mouseXY *= m_RotateSpeed;

            //计算当前物体距离画布左下角位置
            Vector3? curScreenPos = CalculateWorldToScreenPos(transform.position);
            if (curScreenPos == null) return;
            //手指位置偏移量
            Vector2 offset = eventData.position - (Vector2)curScreenPos.Value;


            if (Mathf.Abs(mouseXY.x) > Mathf.Abs(mouseXY.y)) // 判断水平滑动还是垂直滑动
            {
                //手指往水平滑动   下面旋转跟随偏移参数  上面与偏移参数相反
                value = mouseXY.x * Mathf.Sign(-offset.y);
            }
            else
            {
                //手指垂直滑动    右边跟随偏移参数    左边与偏移参数相反
                value = mouseXY.y * Mathf.Sign(offset.x);
            }
            if(Mathf.Abs(value)==0.625)
            value=0;
            transform.Rotate(Vector3.forward, value, Space.Self);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {   if (working)
        {
           
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        value = 0;
    }
}
