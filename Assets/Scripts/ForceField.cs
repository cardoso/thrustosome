using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class ForceField : MonoBehaviour
{
    public List<string> AllowedTags;

    public Vector2 Force;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (this.AllowedTags.Contains(other.tag))
            other.GetComponent<Rigidbody2D>().AddForce(this.Force, ForceMode2D.Impulse);
    }
}
