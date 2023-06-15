using playerController;
using UnityEngine;

public class Blocks : Observers
{
    public Destructable destructable;
    public float limitVelocity = 5.0f;
    private void FixedUpdate()
    {
        if (Mathf.Abs(myRigid.velocity.y) > limitVelocity) // 가속도가 5 이상이라면
            myRigid.velocity = new Vector3(myRigid.velocity.x, Mathf.Sign(myRigid.velocity.y) * limitVelocity, myRigid.velocity.z); //가속도 제한

    }
    public void GetLimit(float limit)
    {
        limitVelocity = limit;
    }
    public void Destruction()
    {
        var attackButton = ButtonManager.instance.attackButton;
        attackButton.myImage.fillAmount += Player.inst.fillAttack;
        myRigid.constraints = RigidbodyConstraints.FreezeAll;
        myTarget.GetComponent<Detect>().LostTarget();
        Debug.Log(myTarget);
        ObjectPool.Inst.ReleaseObject<Blocks>(gameObject, destructable.blockName);
    }
    public void ResetBlock()
    {
        myRigid.constraints = RigidbodyConstraints.FreezeAll;
        myRigid.constraints &= ~RigidbodyConstraints.FreezePositionY;
    }
    public override void Notified(AttackState s)
    {
        switch(s)
        {
            case AttackState.None:
                break;
            case AttackState.Block:
                myRigid.AddForce(Vector3.up * Player.inst.blockPower);
                Debug.Log(myTarget);
                var jumpbutton = ButtonManager.instance.jumpButton;
                jumpbutton.myImage.fillAmount += Player.inst.fillBlock;
                break;
            case AttackState.Attack:
                Destruction();
                break;
        }
    }
    public override void FindTarget(Transform target)
    {
        myTarget = target;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            myTarget = collision.transform;
    }
}
