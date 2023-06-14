using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    [SerializeField] private Destructable destructable;
    public Rigidbody m_Rigidbody;
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        ObjectPool.Inst.ReleaseObject<Blocks>(gameObject, destructable.blockName);
    }
}
