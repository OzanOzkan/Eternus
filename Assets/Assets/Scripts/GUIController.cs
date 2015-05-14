using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIController : MonoBehaviour {

	public float killCount;
	public Text scoreText;
	public GameObject uiRestartButton;
	bool countDown = true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = killCount.ToString ();
	}

	public void RestartClicked(){
		Application.LoadLevel ("GameO01");
	}

	public void BackToMainMenuClicked(){
		Application.LoadLevel ("Menu");
	}
}
