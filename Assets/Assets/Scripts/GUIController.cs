using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIController : MonoBehaviour {

	public float killCount;
	public Text scoreText;
	bool countDown = true;
	public ShipController shipController;

	// User Interface
	public Image healthBar;

	// Use this for initialization
	void Start () {
		healthBar.fillAmount = 0.502f;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = killCount.ToString ();

		if (shipController.health == 5)
			healthBar.fillAmount = 0.408f;
		else if (shipController.health == 4)
			healthBar.fillAmount = 0.302f;
		else if (shipController.health == 3)
			healthBar.fillAmount = 0.205f;
		else if (shipController.health == 2)
			healthBar.fillAmount = 0.099f;
		else if (shipController.health == 1)
			healthBar.fillAmount = 0.0f;
	}

	public void RestartClicked(){
		Application.LoadLevel ("GameO01");
	}

	public void BackToMainMenuClicked(){
		Application.LoadLevel ("Menu");
	}
}
