using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTriggerListener : MonoBehaviour
{
    [Cinemachine.TagField]
    public string ListenerTag;
    public GameEvent EnterTrigger;
    public GameEvent ExitTrigger;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ListenerTag))
            EnterTrigger.Raise();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(ListenerTag))
            ExitTrigger.Raise();
    }
}
