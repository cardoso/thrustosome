using UnityEngine;
using System.Collections;

public class BallAbsorber : MonoBehaviour {

    public Ball Ball;

    public bool IsAbsorbing { get; set; }
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (IsAbsorbing && coll.gameObject.tag == "Ball")
        {
            Ball otherBall = coll.gameObject.GetComponent<Ball>();

            if (otherBall.Mass < Ball.Mass)
            {
                Ball.Mass += otherBall.Mass;

                Destroy(otherBall.gameObject);
            }
            else
            {
                otherBall.Mass += Ball.Mass;

                Destroy(gameObject);
            }
        }
    }
}
