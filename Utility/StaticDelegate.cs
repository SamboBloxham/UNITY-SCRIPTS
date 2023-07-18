using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDelegate : MonoBehaviour
{

    public delegate void ExampleEvent();

    public static ExampleEvent isEventHappened;


    private void Start()
    {
        StaticDelegate.isEventHappened += RecievedFunction;
    }

    public void TriggerEvent()
    {
        isEventHappened.Invoke();
    }

    public void RecievedFunction()
    {
        //Do stuff when event happens
    }

}
