using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SkillButton : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent myAction;
    public Image myImage;
    public float coolTime = 2.0f;
    Coroutine act = null;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 1)
        {
            OnAction();
        }
    }
    public void OnAction()
    {
        if (act != null) return;
        act = StartCoroutine(Cooling());
    }

    IEnumerator Cooling()
    {
        myAction?.Invoke();
        myImage.fillAmount = 0.0f;
        float speed = 1.0f / coolTime;
        while (myImage.fillAmount < 1.0f)
        {
            myImage.fillAmount += speed * Time.deltaTime;
            yield return null;
        }
        act = null;
    }
}
