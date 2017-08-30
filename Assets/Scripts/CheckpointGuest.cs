using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class CheckpointGuest : MonoBehaviour {

    [SerializeField]
    private List<string> GuestTags;

    [SerializeField]
    private List<string> AllowedCheckpointTags; 

    public UnityEvent OnCheckpointEnter;
    public UnityEvent OnCheckpointStay;
    public UnityEvent OnCheckpointExit;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckpointEnter(Checkpoint checkpoint)
    {
        OnCheckpointEnter.Invoke();
    }

    public void CheckpointStay(Checkpoint checkpoint)
    {
        OnCheckpointStay.Invoke();
    }

    public void CheckpointExit(Checkpoint checkpoint)
    {
        OnCheckpointExit.Invoke();
    }

    public void AddGuestTag(string tag)
    {
        if (!GuestTags.Contains(tag))
            GuestTags.Add(tag);
    }

    public void RemoveGuestTag(string tag)
    {
        while (GuestTags.Contains(tag))
            GuestTags.Remove(tag);
    }

    public bool HasGuestTag(string tag)
    {
        return GuestTags.Contains(tag);
    }

    public void AddAllowedCheckpointTag(string tag)
    {
        if (!AllowedCheckpointTags.Contains(tag))
            AllowedCheckpointTags.Add(tag);
    }

    public void RemoveAllowedCheckpointTag(string tag)
    {
        while (AllowedCheckpointTags.Contains(tag))
            AllowedCheckpointTags.Remove(tag);
    }

    public bool HasAllowedCheckpointTag(string tag)
    {
        return AllowedCheckpointTags.Contains(tag);
    }
}
