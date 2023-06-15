using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JumpButton : Buttons
{
    public enum State
    {
        None,
        Normal,
        Ult
    }
    Vector2 dragOffset = Vector2.zero;
    Vector2 originPos = Vector2.zero;
    Vector2 sliderSize = Vector2.zero;
    float yLimit;
    [SerializeField] bool isDrag = false;
    public UnityEvent myUltimate;
    public GameObject background;
    public Image Slider;
    public State state;
    private void Start()
    {
        originPos = transform.position;
        sliderSize = Slider.GetComponent<RectTransform>().sizeDelta;
        float size = myImage.GetComponent<RectTransform>().sizeDelta.y;
        yLimit = originPos.y + sliderSize.y - size;
        ChangeState(State.Normal);
    }
    public void ChangeState(State s)
    {
        if (state == s) return;
        state = s;

        switch(state)
        {
            case State.Normal:
                myImage.fillAmount = 0.0f;
                Slider.gameObject.SetActive(false);
                background.SetActive(false);
                effect.SetActive(false);
                break;
            case State.Ult:
                Slider.gameObject.SetActive(true);
                background.SetActive(true);
                effect.SetActive(true);
                break;
        }
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount >= 1 && !isDrag)
        {
            OnAction();
        }
    }
    public override void OnBeginDrag(PointerEventData eventData)
    {
        if (state != State.Ult) return;
        dragOffset = (Vector2)transform.position - eventData.position;
    }
    public override void OnDrag(PointerEventData eventData)
    {
        if (state != State.Ult) return;
        isDrag = true;
        Vector2 pos = eventData.position + dragOffset;
        pos.y = Mathf.Clamp(pos.y, originPos.y, yLimit);
        transform.position = new Vector2(originPos.x, pos.y);
    }
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (state != State.Ult) return;
        OnUlt();
        isDrag = false;
        transform.position = originPos;
        ChangeState(State.Normal);
    }
    public override void OnAction()
    {
        myAction?.Invoke();
    }
    public void OnUlt()
    {
        myUltimate?.Invoke();
    }
}
