using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class Checkpoint : MonoBehaviour {

    [SerializeField]
    private List<string> CheckpointTags;

    [SerializeField]
    private List<string> AllowedGuestTags;

    public UnityEvent OnGuestEnter;
    public UnityEvent OnGuestStay;
    public UnityEvent OnGuestExit;

    public bool Disable { get; set; }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Disable) return;

        CheckpointGuest guest;
        if ((guest = other.GetComponent<CheckpointGuest>()) != null && IsGuestWelcome(guest))
        {
            OnGuestEnter.Invoke();
            guest.CheckpointEnter(this);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Disable) return;

        CheckpointGuest guest;
        if ((guest = other.GetComponent<CheckpointGuest>()) != null && IsGuestWelcome(guest))
        {
            OnGuestStay.Invoke();
            guest.CheckpointStay(this);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (Disable) return;

        CheckpointGuest guest;
        if ((guest = other.GetComponent<CheckpointGuest>()) != null && IsGuestWelcome(guest))
        {
            OnGuestExit.Invoke();
            guest.CheckpointExit(this);
        }
    }

    public void AddCheckpointTag(string tag)
    {
        if (!CheckpointTags.Contains(tag))
            CheckpointTags.Add(tag);
    }

    public void RemoveCheckpointTag(string tag)
    {
        while (CheckpointTags.Contains(tag))
            CheckpointTags.Remove(tag);
    }

    public bool HasCheckpointTag(string tag)
    {
        return CheckpointTags.Contains(tag);
    }

    public void AddAllowedGuestTag(string tag)
    {
        if (!AllowedGuestTags.Contains(tag))
            AllowedGuestTags.Add(tag);
    }

    public void RemoveAllowedGuestTag(string tag)
    {
        while (AllowedGuestTags.Contains(tag))
            AllowedGuestTags.Remove(tag);
    }

    public bool HasAllowedGuestTag(string tag)
    {
        return AllowedGuestTags.Contains(tag);
    }

    private bool IsGuestWelcome(CheckpointGuest guest)
    {
        foreach(var tag in CheckpointTags)
        {
            if (CheckpointTags.Contains(tag))
            {
                foreach (var allowedTag in AllowedGuestTags)
                {
                    if (guest.HasGuestTag(allowedTag))
                        return true;
                }

                break;
            }
        }

        return false;
    }
}
