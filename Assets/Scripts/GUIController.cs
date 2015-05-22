using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIController : MonoBehaviour {

	bool countDown = true;
	public ShipController shipController;
	public float ultiBarFullTreshold;

	// User Interface
	public Text scoreText;
	public Text levelText;
	public Image healthBar;
	public Image ultiBar;

	float[]ultiBarLevels;
	int filledUltiBarLevel;
	public float currentKill;

	// Use this for initialization
	void Start () {
		healthBar.fillAmount = 0.502f;

		ultiBarLevels = new float[15];
		ultiBarLevels [0] = 0f;
		ultiBarLevels [1] = 0.060f;
		ultiBarLevels [2] = 0.146f;
		ultiBarLevels [3] = 0.213f;
		ultiBarLevels [4] = 0.282f;
		ultiBarLevels [5] = 0.354f;
		ultiBarLevels [6] = 0.429f;
		ultiBarLevels [7] = 0.498f;
		ultiBarLevels [8] = 0.578f;
		ultiBarLevels [9] = 0.641f;
		ultiBarLevels [10] = 0.716f;
		ultiBarLevels [11] = 0.785f;
		ultiBarLevels [12] = 0.865f;
		ultiBarLevels [13] = 0.928f;
		ultiBarLevels [14] = 1f;

		ultiBar.fillAmount = ultiBarLevels [0];
		ultiBarFullTreshold = 14;
		filledUltiBarLevel = 0;
		currentKill = 0;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = shipController.killCount.ToString ();
		levelText.text = shipController.level.ToString ();

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

		if (shipController.killCount >= ultiBarFullTreshold) {
			ultiBarFullTreshold = 14 * shipController.level;
		}

		if (currentKill == shipController.level) {
			filledUltiBarLevel++;
			ultiBar.fillAmount = ultiBarLevels[filledUltiBarLevel];
			currentKill = 0;
		}

		if (filledUltiBarLevel == 14) {
			shipController.randomPowerUp = Random.Range(0,2);
			filledUltiBarLevel = 0;
			ultiBar.fillAmount = ultiBarLevels[filledUltiBarLevel];
		}
	}

	public void RestartClicked(){
		Application.LoadLevel ("GameO01");
	}

	public void BackToMainMenuClicked(){
		Application.LoadLevel ("Menu");
	}
}
