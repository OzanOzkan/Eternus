using UnityEngine;
using System.Collections;

public class ScrollController : MonoBehaviour {

	public float scrollSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Move spawned object to -Y constantly.
		transform.Translate (-Vector2.up * scrollSpeed * Time.deltaTime);

		// If spawned object went out to screen, destroy it.
		if (transform.position.y <= -18)
			Destroy (this.gameObject);
	}
}
