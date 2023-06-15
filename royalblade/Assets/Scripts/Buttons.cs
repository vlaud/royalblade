using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Buttons : MonoBehaviour, IPointerClickHandler, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public UnityEvent myAction;
    public Image myImage;
    public GameObject effect;
   
    public virtual void OnPointerClick(PointerEventData eventData)
    {
       
    }
    public virtual void OnBeginDrag(PointerEventData eventData)
    {

    }
    public virtual void OnDrag(PointerEventData eventData)
    {

    }
    public virtual void OnEndDrag(PointerEventData eventData)
    {

    }
    public virtual void OnAction() { }
}
