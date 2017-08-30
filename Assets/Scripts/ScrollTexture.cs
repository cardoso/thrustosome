using UnityEngine;
using System.Collections;

public class ScrollTexture : MonoBehaviour {

    public float XSpeed;
    public float YSpeed;
    public MeshRenderer Renderer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 offset = new Vector2(Time.time * this.XSpeed, Time.time * this.YSpeed);

        this.Renderer.material.mainTextureOffset = offset;
	}
}
