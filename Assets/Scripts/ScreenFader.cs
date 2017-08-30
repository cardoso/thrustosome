using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScreenFader : MonoBehaviour {

    public Image Image;

    private bool _fadeIn;

	void FixedUpdate () {
        float currentAlpha = this.Image.canvasRenderer.GetAlpha();

        if (_fadeIn)
        {
            if(currentAlpha < 1.0f)
                this.Image.canvasRenderer.SetAlpha(this.Image.canvasRenderer.GetAlpha() + Time.fixedDeltaTime*2.0f);
        }
        else
        {
            if (currentAlpha > 0.0f)
                this.Image.canvasRenderer.SetAlpha(this.Image.canvasRenderer.GetAlpha() - Time.fixedDeltaTime*2.0f);
        }
	}

    public void FadeIn()
    {
        _fadeIn = true;
    }

    public void FadeOut()
    {
        _fadeIn = false;
    }
}
