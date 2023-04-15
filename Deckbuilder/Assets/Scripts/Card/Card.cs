using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour,IDrag, IPointerEnterHandler,IPointerExitHandler
{
    public void OnStartDrag()
    {
        
    }

    public void OnEndDrag()
    {
        
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Entro Mouse");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Salio Mouse");
    }
}
