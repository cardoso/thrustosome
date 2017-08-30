using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[System.Serializable]
public class LongPressEvent : UnityEvent<float> { }

public class LongPressHandler : MonoBehaviour {

    public LongPressEvent OnPress;

    public float Speed;

    public bool IsPressing;

    public bool ShouldPress { get; set; }

    private float _timePressing;

    void OnMouseOver()
    {
        if(Input.GetMouseButton(0) && ShouldPress)
        {
            _timePressing += Time.deltaTime*Speed;
            OnPress.Invoke(_timePressing);
            return;
        }

        _timePressing = 0;
    }

    void OnMouseUp()
    {
        _timePressing = 0;
    }
}
