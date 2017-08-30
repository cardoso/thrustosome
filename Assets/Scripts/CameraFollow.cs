using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public string TargetTag;
    private Transform _targetTransform;

    public float Speed;

	// Use this for initialization
	void Start () {
        FindTarget();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (_targetTransform != null)
        {
            this.transform.position = Vector2.Lerp(this.transform.position, _targetTransform.position, Time.fixedDeltaTime * Speed);
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10.0f);
        }
        else
        {
            FindTarget();
        }
    }

    void FindTarget()
    {
        var target = GameObject.FindGameObjectWithTag(TargetTag);
        
        if(target != null)
            _targetTransform = target.transform;
    }
}
