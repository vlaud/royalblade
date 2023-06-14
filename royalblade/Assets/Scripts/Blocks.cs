using playerController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : Observers
{
    [SerializeField] private Destructable destructable;
   
    public void Destruction()
    {
        myRigid.constraints = RigidbodyConstraints.FreezeAll;
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
                myRigid.AddForce(Vector3.up * 600.0f);
                Debug.Log(myTarget);
                break;
            case AttackState.Attack:
                Destruction();
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            if (myTarget != collision.transform) myTarget = collision.transform;
    }
}
