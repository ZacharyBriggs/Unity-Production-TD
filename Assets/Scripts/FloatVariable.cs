using UnityEngine;

[CreateAssetMenu(menuName ="Variables/Float")]
public class FloatVariable : Variable
{
    public float _value;
    public float _MaxValue;
    public override object Value
    {
        get
        {
            return _value;
        }
    }

    public override object MaxValue
    {
        get
        {
            return _MaxValue;
        }
    }

}
