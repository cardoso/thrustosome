using UnityEngine;
using System.Collections;

public class Grabber : MonoBehaviour {

    public string TargetTag;

    public float Speed;

    public bool GrabOnceAndLetGo;
    private bool _grabbedOnce;

    public bool Disabled;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == TargetTag)
        {
            _grabbedOnce = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!ShouldGrab()) return;

        if (other.tag == TargetTag)
        {
            float distance = Vector2.Distance(this.transform.position, other.transform.position);

            if (distance > 0.01f)
            {
                GrabTarget(other.transform);
            }
            else
            {
                _grabbedOnce = true;
            }
        }
    }

    void GrabTarget(Transform targetTransform)
    {
        targetTransform.position = Vector2.Lerp(targetTransform.position, transform.position, Time.deltaTime*Speed);

        Rigidbody2D rigidbody2D = targetTransform.GetComponent<Rigidbody2D>();

        rigidbody2D.velocity = Vector2.zero;
    }

    bool ShouldGrab()
    {
        return !(GrabOnceAndLetGo && _grabbedOnce) && !Disabled;
    }

    public void DisableGrab()
    {
        Disabled = true;
    }

    public void EnableGrab()
    {
        Disabled = false;
    }
}
