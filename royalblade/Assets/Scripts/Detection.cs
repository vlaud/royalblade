using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Detection : MonoBehaviour
{
    public UnityEvent<Transform> FindTarget = default;
    public UnityEvent LostTarget = default;
    public LayerMask blockMask = default;
    public Transform myTarget = null;
    
    public void SetLayer(LayerMask layer)
    {
        blockMask = layer;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (myTarget != null) return;
        if ((blockMask & 1 << other.gameObject.layer) != 0)
        {
            myTarget = other.transform;
            FindTarget?.Invoke(myTarget);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (myTarget == other.transform)
        {
            LostTarget?.Invoke();
            myTarget = null;
        }
    }
}
