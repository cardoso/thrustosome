using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Timer : MonoBehaviour {

    public float TimeInterval;
    public bool FireOnStart;
    public bool Loop;

    public UnityEvent OnTimerFired;
    public UnityEvent OnTimeElapsed;

    public string Description;
    public bool ConsoleDebug;

    private float _currentTime;
    private bool _fired;

	void Start () {
	    if(FireOnStart)
        {
            Fire();
        }
	}
	
	// Update is called once per frame
	void Update () {
        UpdateTime();
    }

    void UpdateTime()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= TimeInterval && _fired)
        {
            _fired = false;
            OnTimeElapsed.Invoke();

            if(ConsoleDebug)
                Debug.Log(this.Description);

            if (Loop)
                Fire();
        }
    }

    public void Fire()
    {
        _currentTime = 0;
        _fired = true;

        OnTimerFired.Invoke();
    }
}
