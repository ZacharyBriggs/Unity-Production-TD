using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameEvent")]
public class GameEvent : ScriptableObject
{
    private readonly List<GameEventListener> _listeners = new List<GameEventListener>();

    public void AddListener(GameEventListener listener)
    {
        if (_listeners.Contains(listener))
            return;
        _listeners.Add(listener);
    }
    public void RemoveListener(GameEventListener listener)
    {
        if (!_listeners.Contains(listener))
            return;
        _listeners.Remove(listener);
    }

    /// <summary>
    /// provide a method for raising an event
    /// </summary>
    public void Raise()
    {
        _listeners.ForEach(l => l.OnEventRaised());
    }
}