using UnityEngine;
using System.Collections;

public class InstantiateObjects : MonoBehaviour {

	public GameObject[] galaxies;
	public GameObject[] stars;
	public GameObject bullet;
	public GameObject laserbeam;
	public GameObject ship;
	public Vector3 vector;
	public float moveSpeed;
	public float bulletFireSpeed;
	public float laserFireSpeed;

	// Use this for initialization
	void Start () {
		// Spawn methods for game objecs.
		Invoke("SpawnGalaxy", 20);
		Invoke("SpawnStar", 5);
		Invoke("SpawnBullet", bulletFireSpeed);
		Invoke("SpawnLaserBeam", laserFireSpeed);
	}

	// Update is called once per frame
	void Update () {

	}

	// Galaxy spawn
	void SpawnGalaxy(){
		vector = new Vector3 (Random.Range(-12,12), 12 , 0);
		var rnd = Random.Range (0, 0);
		GameObject galaxy = (GameObject)Instantiate (galaxies[rnd], vector, Quaternion.identity);

		// For random direction.
		galaxy.transform.Rotate (0, 0, Random.Range(-5.0f,5.0f));

		Invoke("SpawnGalaxy", 20);
	}

	// Star spawn
	void SpawnStar(){
		vector = new Vector3 (Random.Range(-12,12), 12 , 0);
		var rnd = Random.Range (0, 2);
		GameObject star = (GameObject)Instantiate (stars[rnd], vector, Quaternion.identity);

		// For random direction.
		star.transform.Rotate (0, 0, Random.Range(-8.0f,8.0f));

		Invoke("SpawnStar", 5);
	}

	void SpawnBullet(){
		GameObject currentBullet = (GameObject)Instantiate (bullet, ship.transform.position, Quaternion.identity);

		Invoke("SpawnBullet", bulletFireSpeed);
	}

	void SpawnLaserBeam(){
		GameObject currentBullet = (GameObject)Instantiate (laserbeam, ship.transform.position, Quaternion.identity);
		
		Invoke("SpawnLaserBeam", laserFireSpeed);
	}
}