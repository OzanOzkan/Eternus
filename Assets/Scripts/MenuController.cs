using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public GameObject uiPlayButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayClicked(){
		Application.LoadLevel ("GameO01");
	}

	public void CreditsClicked(){
		Application.LoadLevel ("Credits");
	}

	public void MainMenuClicked(){
		Application.LoadLevel ("Menu");
	}
	
	public void ExitClicked(){
		Application.Quit ();
	}
}
