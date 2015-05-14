using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIController : MonoBehaviour {

	public float killCount;
	public Text scoreText;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = killCount.ToString ();
	}
}
