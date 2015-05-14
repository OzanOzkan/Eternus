using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public GameObject enemyBullet;
	public float bulletFireSpeed;
	public GameObject enemyCannon;

	// Use this for initialization
	void Start () {
		Invoke ("SpawnBullet", bulletFireSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		enemyCannon.transform.position = this.transform.position + new Vector3 (-0.2f, -0.8f, 0.0f);
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Bullets") {
			Destroy(this.gameObject);
			Destroy(col.gameObject);
			GameObject gameController = GameObject.Find("GameController");
			GUIController guiController = gameController.GetComponent<GUIController>();
			guiController.killCount = guiController.killCount + 1;
		}
	}

	void SpawnBullet(){
		if (this.transform.position.y <= 11.4f){
			GameObject currentBullet = (GameObject)Instantiate (enemyBullet, enemyCannon.transform.position, Quaternion.identity);
		}

		Invoke("SpawnBullet", bulletFireSpeed);
	}
}
