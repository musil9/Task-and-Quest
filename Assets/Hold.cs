using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    bool isPressed;
    float holdTime;
    GameObject hit;
    GameObject savedHit;

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
            hit = eventData.pointerCurrentRaycast.gameObject;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        holdTime = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;        
    }

    // Update is called once per frame
    void Update()
    {

        
        if(isPressed)
        {
            //Debug.Log(EventSystem.current.currentSelectedGameObject);
            holdTime += Time.deltaTime;
            //Debug.Log($"holdTime : {holdTime}");
        }
    }
}
