using UnityEngine.EventSystems;

public class AttackButton : Buttons
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount >= 1)
        {
            OnAction();
        }
    }
    public override void OnAction()
    {
        myAction?.Invoke();
    }
}
