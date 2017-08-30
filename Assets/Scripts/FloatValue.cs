using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class FloatValueEvent : UnityEvent<float> { }

public class FloatValue : MonoBehaviour
{


    public float Value;

    public FloatValueEvent OnValueChanged;

    public void SetValue(float newValue)
    {
        Value = newValue;
        OnValueChanged.Invoke(Value);
    }

    public void AddValue(float addValue)
    {
        Value += addValue;
        OnValueChanged.Invoke(Value);
    }
}
