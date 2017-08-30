using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[System.Serializable]
public class StretchEvent : UnityEvent<Stretch>
{

}

public struct Stretch
{
    public Vector2 FromPosition;
    public Vector2 ToPosition;
    public Vector2 Force;
}

public class Elastic : MonoBehaviour
{
    public float Elasticity;

    public LineRenderer LineRenderer;

    public StretchEvent DidBeginStretch;
    public StretchEvent DidStretch;
    public StretchEvent DidRelease;

    public Stretch CurrentStretch;
    
    // Use this for initialization
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {

    }

    public void StartStretchingAt(Vector3 position)
    {
        if (this.isActiveAndEnabled)
        {
            LineRenderer.SetPositions(
                new Vector3[2] { transform.position, transform.position }
            );

            CurrentStretch.FromPosition = position;
            CurrentStretch.Force = GetForce();
            DidBeginStretch.Invoke(CurrentStretch);
        }
    }

    public void StretchTo(Vector3 position)
    {
        if (this.isActiveAndEnabled)
        {
            LineRenderer.SetPositions(
            new Vector3[2] { transform.position, position }
            );

            CurrentStretch.ToPosition = position;
            CurrentStretch.Force = GetForce();
            DidStretch.Invoke(CurrentStretch);
        }
    }

    public void StopStretchingAt(Vector3 position)
    {
        if (this.isActiveAndEnabled)
        {
            LineRenderer.SetPositions(
            new Vector3[2] { transform.position, transform.position }
            );

            CurrentStretch.ToPosition = position;
            CurrentStretch.Force = GetForce();
            DidRelease.Invoke(CurrentStretch);
        }
    }

    public Vector2 GetForce()
    {
        return (CurrentStretch.ToPosition - CurrentStretch.FromPosition)
            * Elasticity;
    }
}