using UnityEngine;
using System.Collections;

public class InstantiateObjects : MonoBehaviour {
	
	public GameObject[] galaxies;
	public GameObject[] stars;
	public GameObject[] enemies;
	public GameObject bullet;
	public GameObject laserbeam;
	public GameObject ship;
	public GameObject shipCannon;
	public GameObject ultiLaser;
	public Vector3 vector;
	public float moveSpeed;
	public float bulletFireSpeed;
	public float laserFireSpeed;
	public float enemySpawnSpeed;

	GameObject gameController;
	public float laserBeamKillTreshold;
	bool laserBeamControl;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find("GameController");
		laserBeamControl = true;

		// Spawn methods for game objecs.
		Invoke("SpawnGalaxy", 20);
		Invoke("SpawnStar", 5);
		Invoke("SpawnBullet", bulletFireSpeed);
		Invoke("SpawnEnemies", enemySpawnSpeed);
		//SpawnUltiLaser ();

		//Debug.Log (Camera.main.aspect.ToString ());
	}

	// Update is called once per frame
	void Update () {
		/*
		if (ship.GetComponent<ShipController>().killCount >= laserBeamKillTreshold && laserBeamControl) {
			Invoke ("SpawnLaserBeam", laserFireSpeed);
			laserBeamControl = false;
		}*/
	}

	// Galaxy spawn
	void SpawnGalaxy(){
		vector = new Vector3 (Random.Range(-5,5), 12 , 0);
		var rnd = Random.Range (0, 0);
		GameObject galaxy = (GameObject)Instantiate (galaxies[rnd], vector, Quaternion.identity);

		// For random direction.
		galaxy.transform.Rotate (0, 0, Random.Range(-5.0f,5.0f));

		Invoke("SpawnGalaxy", 20);
	}

	// Star spawn
	void SpawnStar(){
		vector = new Vector3 (Random.Range(-5,5), 12 , 0);
		var rnd = Random.Range (0, 2);
		GameObject star = (GameObject)Instantiate (stars[rnd], vector, Quaternion.identity);

		// For random direction.
		star.transform.Rotate (0, 0, Random.Range(-8.0f,8.0f));

		Invoke("SpawnStar", 5);
	}

	void SpawnBullet(){
		GameObject currentBullet = (GameObject)Instantiate (bullet, shipCannon.transform.position, Quaternion.identity);

		Invoke("SpawnBullet", bulletFireSpeed);
	}
	/*
	void SpawnLaserBeam(){
		GameObject currentLaserBeam = (GameObject)Instantiate (laserbeam, shipCannon.transform.position, Quaternion.identity);
		
		Invoke("SpawnLaserBeam", laserFireSpeed);
	}*/

	void SpawnUltiLaser(){
		ultiLaser = (GameObject)Instantiate (ultiLaser, shipCannon.transform.position, Quaternion.identity);
	}

	void SpawnEnemies(){
		vector = new Vector3 (Random.Range(1.2f,8.2f), 12 , 0);
		var rnd = Random.Range (0, 0);
		GameObject currentEnemy = (GameObject)Instantiate (enemies[rnd], vector, Quaternion.identity);

		Invoke("SpawnEnemies", enemySpawnSpeed);
	}
}