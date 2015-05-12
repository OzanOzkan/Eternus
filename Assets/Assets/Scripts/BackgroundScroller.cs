﻿using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

	public float scrollSpeed;
	private Vector2 savedOffset;

	// Use this for initialization
	void Start () {
		savedOffset = renderer.sharedMaterial.GetTextureOffset ("_MainTex");
	}
	
	// Update is called once per frame
	void Update () {
		float y = Mathf.Repeat (Time.time * scrollSpeed, 1);
		Vector2 offset = new Vector2 (0, y);
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}

	void OnDisable(){
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", savedOffset);
	}
}
