using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Subject
{
    public void AddObserver(Observer ops);
    public void RemoveObserver(Observer ops);
    public void NotifyToObserver();
}
public interface Observer
{
    public void Notified();
    public void SetMySubject(Subject s);
}
public class Observers : MonoBehaviour
{
   
}
