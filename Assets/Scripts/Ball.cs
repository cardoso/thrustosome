using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Ball : MonoBehaviour {

    public float Mass;
    public float Density;

    public SpriteRenderer SpriteRenderer;
    public Rigidbody2D Rigidbody2D;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void ElasticDidRelease(Stretch stretch)
    {
        Rigidbody2D.AddForce(stretch.Force);
    }
}