using System.Collections.Generic;
using UnityEngine;

public interface Subject
{
    public void AddObserver(Observer ops);
    public void RemoveObserver(Observer ops);
    public void NotifyToObserver(AttackState s);
}
public interface Observer
{
    public void Notified(AttackState s);
    public void SetMySubject(Subject s);
}
public interface Detect
{
    void FindTarget(Transform target);
    void LostTarget();
}
public enum AttackState
{
    None,
    Jump,
    Block,
    Attack
}
public class Observers : CharacterProperty, Subject, Observer, Detect
{
    protected List<Observer> myBlocks = new List<Observer>();
    Transform _target = null;
    protected Subject mySubject;

    protected Transform myTarget
    {
        get => _target;
        set
        {
            _target = value;
            //if (_target != null) _target.GetComponent<Subject>()?.AddObserver(this);
        }
    }
    public void AddObserver(Observer ops)
    {
        ops.SetMySubject(this);
        myBlocks.Add(ops);
    }
    public void RemoveObserver(Observer ops)
    {
        for (int i = 0; i < myBlocks.Count;)
        {
            if (ops == myBlocks[i])
            {
                ops.SetMySubject(null);
                myBlocks.RemoveAt(i);
                break;
            }
            ++i;
        }
    }
    public void NotifyToObserver(AttackState s)
    {
        foreach (Observer ops in myBlocks) { ops.Notified(s); }
        Debug.Log(myBlocks.Count);
    }
    public virtual void Notified(AttackState s)
    {

    }
    public virtual void SetMySubject(Subject s)
    {
        mySubject = s;
    }
    public virtual void FindTarget(Transform target)
    {

    }
    public virtual void LostTarget()
    {

    }
}
