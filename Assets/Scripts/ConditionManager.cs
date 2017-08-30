using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Linq;

public class ConditionManager : MonoBehaviour {

    public string ConditionName;

    public UnityEvent OnConditionSatisfied;
    public UnityEvent OnConditionUnsatisfied;

    public bool ConsoleDebug;

    private List<Condition> _conditions;
    private bool _isSatisfied;

    void Awake()
    {
        _conditions = new List<Condition>();
    }

    void Start()
    {
        ReloadConditions();
        AssertAll();
    }

    public void OnConditionChanged(Condition condition)
    {
        if(ConsoleDebug)
            Debug.Log("[" + this.ConditionName + "] " + condition.Description + " -> " + condition.GetValue());

        if (condition.GetValue())
        {
            AssertAll();
        }
    }

    public void AssertAll()
    {
        if (_conditions.Count > 0)
        {
            foreach (var c in _conditions)
            {
                if (!c.GetValue())
                {
                    if(_isSatisfied)
                    {
                        _isSatisfied = false;
                        OnConditionUnsatisfied.Invoke();
                    }

                    return;
                }
            }

            OnConditionSatisfied.Invoke();
            _isSatisfied = true;
        }
    }

    public void ReloadConditions()
    {
        foreach (var condition in this._conditions)
        {
            condition.OnConditionChanged.RemoveListener(OnConditionChanged);
        }

        this._conditions = FindObjectsOfType<Condition>().Where(o => o.Name == this.ConditionName).ToList();

        foreach(var condition in this._conditions)
        {
            condition.OnConditionChanged.AddListener(OnConditionChanged);
        }

        if (ConsoleDebug)
            Debug.Log("[" + this.ConditionName + "] Found " + _conditions.Count() + " conditions");
    }

    private void OnLevelWasLoaded()
    {
        ReloadConditions();
    }
}
