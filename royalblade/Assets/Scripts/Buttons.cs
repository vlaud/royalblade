using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Buttons : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent myAction;
    public Image myImage;
   
    public virtual void OnPointerClick(PointerEventData eventData)
    {
       
    }
    public virtual void OnAction() { }
}
