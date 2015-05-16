using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public GameObject enemyBullet;
	public float bulletFireSpeed;
	public GameObject enemyCannon;
	public GameObject blastPrefab;
	public float destroyDelay = 2.0f;

	// Use this for initialization
	void Start () {
		Invoke ("SpawnBullet", bulletFireSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		enemyCannon.transform.position = this.transform.position + new Vector3 (-0.2f, -0.8f, 0.0f);
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Bullets" || col.gameObject.tag == "PlayerUlti") {
			Destroy(this.gameObject);
			GameObject blast = (GameObject)Instantiate (blastPrefab,this.transform.position, Quaternion.identity);
			Destroy(blast.gameObject, 0.5f);

			if (col.gameObject.tag != "PlayerUlti"){
				Destroy(col.gameObject);
			}

			GameObject ship = GameObject.Find("Ship");
			ShipController shipController = ship.GetComponent<ShipController>();
			shipController.killCount = shipController.killCount + 1;
		}
	}

	void SpawnBullet(){
		if (this.transform.position.y <= 11.4f){
			GameObject currentBullet = (GameObject)Instantiate (enemyBullet, enemyCannon.transform.position, Quaternion.identity);
		}

		Invoke("SpawnBullet", bulletFireSpeed);
	}
}
