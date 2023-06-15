using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance = null;
    public JumpButton jumpButton;
    public AttackButton attackButton;
    public SkillButton skillButton;

    private void Awake()
    {
        instance = this;
    }
}
