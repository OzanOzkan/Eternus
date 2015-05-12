using UnityEngine;
using System.Collections;

public class ScrollController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (-Vector2.up * 2 * Time.deltaTime);
	}
}
