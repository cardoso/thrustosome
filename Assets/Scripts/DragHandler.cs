using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[System.Serializable]
public class DragEvent : UnityEvent<Vector3> { }

public class DragHandler : MonoBehaviour {

    public DragEvent OnDragBegan;
    public DragEvent OnDrag;
    public DragEvent OnDragEnded;

    public bool IsDragging;

    public bool ShouldDrag { get; set; }

    Vector3 inputPosition
    {
        get
        {
            return Vector3.Scale(
                Camera.main.ScreenToWorldPoint(Input.mousePosition),
                new Vector3(1, 1, 0));
        }
    }



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDrag()
    {
        if (!IsDragging)
        {
            if (ShouldDrag)
            {
                OnDragBegan.Invoke(inputPosition);
                IsDragging = true;
            }
        }
        else
            OnDrag.Invoke(inputPosition);
    }

    void OnMouseUp()
    {
        if (IsDragging)
        {
            OnDragEnded.Invoke(inputPosition);
            IsDragging = false;
        }
    }
}
