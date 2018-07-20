using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// GameEventListener implementation
/// ToDo: Usage docs
/// </summary>
public class GameEventListener : MonoBehaviour
{
    public GameEvent GameEvent;
    public UnityEvent GameEventResponse;

    [TextArea] public string Notes;

    private void OnEnable()
    {
        GameEvent.AddListener(this);
    }

    private void OnDisable()
    {
        GameEvent.RemoveListener(this);
    }

    public void OnEventRaised()
    {
        GameEventResponse.Invoke();
    }
}