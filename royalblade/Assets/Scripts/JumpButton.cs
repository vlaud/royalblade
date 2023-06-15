using UnityEngine.EventSystems;

public class JumpButton : Buttons
{
    private void Start()
    {
        myImage.fillAmount = 0.0f;
    }
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
