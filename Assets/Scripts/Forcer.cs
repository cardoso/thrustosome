using UnityEngine;
using System.Collections;

public class Forcer : MonoBehaviour {

    public Rigidbody2D Rigidbody2D;

    public float Multiplier = 1.0f;
    public void SetMultiplier(float newValue) { Multiplier = newValue; }

	public void AddImpulse(Vector2 force)
    {

        Rigidbody2D.AddForce(force * Multiplier, ForceMode2D.Impulse);
    }

    public void AddForce(Vector2 force)
    {

        Rigidbody2D.AddForce(force*Multiplier, ForceMode2D.Force);
    }

    public void AddImpulseToPosition(Vector2 position)
    {

        Rigidbody2D.AddForce((position - (Vector2)transform.position) * Multiplier, ForceMode2D.Impulse);
    }

    public void AddForceToPosition(Vector2 position)
    {

        Rigidbody2D.AddForce((position - (Vector2)transform.position) * Multiplier, ForceMode2D.Force);
    }
}
