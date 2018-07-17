using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTriggerListener : MonoBehaviour
{
    [Cinemachine.TagField]
    public string ListenerTag;
    public GameEvent EnterTrigger;
    public GameEvent ExitTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ListenerTag))
            EnterTrigger.Raise();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(ListenerTag))
            ExitTrigger.Raise();
    }
}
