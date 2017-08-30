using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

[System.Serializable]
public struct ColorWithEvent
{
    public UnityEvent OnColorEnter;
    public UnityEvent OnColorLeave;
    public Color Color;
}

public class ColorInterpolatorCycle : MonoBehaviour {

    public ColorInterpolator ColorInterpolator;
    public List<ColorWithEvent> Colors;

	private int _currentColor;

    void Start()
    {
        ColorInterpolator.ColorFrom = Colors[0].Color;
        ColorInterpolator.ColorTo = Colors[1].Color;

        Colors[0].OnColorEnter.Invoke();

        _currentColor = 0;
    }

    public void Next()
    {
        Colors[_currentColor].OnColorLeave.Invoke();

        _currentColor++;
        _currentColor %= Colors.Count;

        Colors[_currentColor].OnColorEnter.Invoke();

        ColorInterpolator.ColorFrom = Colors[_currentColor].Color;
        ColorInterpolator.ColorTo = Colors[(_currentColor + 1) % Colors.Count].Color;

        Debug.Log(_currentColor);
    }
}
