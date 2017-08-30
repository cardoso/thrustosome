using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Speedometer : MonoBehaviour {

    public float Speed;

    public Rigidbody2D Rigidbody2D;

    public UnityEvent OnSpeedReached;
    public UnityEvent OnSpeedFell;

    private float lastSpeed;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        float newSpeed = Rigidbody2D.velocity.magnitude;

        if(newSpeed >= Speed && lastSpeed < Speed)
        {
            OnSpeedReached.Invoke();
        }

        if(newSpeed < Speed && lastSpeed >= Speed)
        {
            OnSpeedFell.Invoke();
        }

        lastSpeed = newSpeed;
	}
}
