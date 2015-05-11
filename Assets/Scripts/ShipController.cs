using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

	public KeyCode moveLeft = KeyCode.LeftArrow;
	public KeyCode moveRight = KeyCode.RightArrow;

	public float speed = 10.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (moveLeft)) {
			var vel = rigidbody2D.velocity;
			vel.x = -1 * speed;
			rigidbody2D.velocity = vel;
		} else if (Input.GetKeyDown (moveRight)) {
			var vel = rigidbody2D.velocity;
			vel.x = speed;
			rigidbody2D.velocity = vel;
		} else if (!Input.anyKey) {
			var vel = rigidbody2D.velocity;
			vel.x = 0;
			rigidbody2D.velocity = vel;
		}
	}
}
