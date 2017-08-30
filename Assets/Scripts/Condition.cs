using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Linq;

public class ConditionEvent : UnityEvent<Condition> { }

public class Condition : MonoBehaviour {

    public string Name;
    public string Description;

    public ConditionEvent OnConditionChanged;

    public bool InitialValue;

    private bool _value;

    void Awake()
    {
        _value = InitialValue;

        OnConditionChanged = new ConditionEvent();
    }

    public bool GetValue()
    {
        return _value;
    }

    public void SetTrue()
    {
        _value = true;
        OnConditionChanged.Invoke(this);
    }

    public void SetFalse()
    {
        _value = false;
        OnConditionChanged.Invoke(this);
    }

}
