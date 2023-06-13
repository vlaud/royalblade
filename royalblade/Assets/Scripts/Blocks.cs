using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    [SerializeField] private Destructable destructable;
    private void OnCollisionEnter(Collision collision)
    {
        ObjectPool.Inst.ReleaseObject<Blocks>(gameObject, destructable.blockName);
    }
}
