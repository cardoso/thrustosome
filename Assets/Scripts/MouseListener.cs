using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[System.Serializable]
public class MouseEvent : UnityEvent<Vector2>
{

}

public class MouseListener : MonoBehaviour {

    Vector3 inputPosition
    {
        get
        {
            return Vector3.Scale(
                Camera.main.ScreenToWorldPoint(Input.mousePosition),
                new Vector3(1, 1, 0));
        }
    }

    public MouseEvent OnMouseDown;
    public MouseEvent OnMouseHold;
    public MouseEvent OnMouseUp;

    public bool Listen;
    public void SetListen(bool value) { Listen = value; }

	void Update () {
        if (!Listen) return;

	    if(Input.GetMouseButtonDown(0))
        {
            OnMouseDown.Invoke(inputPosition);
        }
        else if (Input.GetMouseButton(0))
        {
            OnMouseHold.Invoke(inputPosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnMouseUp.Invoke(inputPosition);
        }
    }
}
