using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillButton : Buttons
{
    public float coolTime = 2.0f;
    Coroutine act = null;
    
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount >= 1)
        {
            OnAction();
        }
    }
    public override void OnAction()
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
