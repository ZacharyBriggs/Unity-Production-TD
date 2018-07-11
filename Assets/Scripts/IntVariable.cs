using UnityEngine;

public abstract class IntVariable : ScriptableObject
{
    public abstract int Value { get; }
    public abstract int MaxValue { get; }
    public delegate void OnValueChanged();
    public OnValueChanged onValueChanged;
}