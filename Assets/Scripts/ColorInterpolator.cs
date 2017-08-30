using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class ColorInterpolator : MonoBehaviour {

    public SpriteRenderer SpriteRenderer;

    public Color ColorFrom;
    public Color ColorTo;

    public UnityEvent OnInterpolationCompleted;

    private bool _interpolationCompleted;

    public void Interpolate(float value)
    {
        if (value > 1.0f || value < 0)
        {
            if (!_interpolationCompleted)
            {
                OnInterpolationCompleted.Invoke();
                Debug.Log("Yay");
                _interpolationCompleted = true;
            }
        }
        else
        {
            SpriteRenderer.color = Color.Lerp(ColorFrom, ColorTo, value);

            if(_interpolationCompleted)
            {
                _interpolationCompleted = false;
            }
        }
    }
}
