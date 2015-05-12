using UnityEngine;
using System.Collections;

public class InstantiateObjects : MonoBehaviour {

	public GameObject[] galaxies;
	public GameObject[] stars;
	public Vector3 vector;
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		// Spawn methods for game objecs.
		Invoke("SpawnGalaxy", 20);
		Invoke("SpawnStar", 5);
	}

	// Update is called once per frame
	void Update () {

	}

	// Galaxy spawn
	void SpawnGalaxy(){
		vector = new Vector3 (Random.Range(-12,12), 12 , 0);
		var rnd = Random.Range (0, 0);
		Instantiate (galaxies[rnd], vector, Quaternion.identity);

		Invoke("SpawnGalaxy", 20);
	}

	// Star spawn
	void SpawnStar(){
		vector = new Vector3 (Random.Range(-12,12), 12 , 0);
		var rnd = Random.Range (0, 2);
		Instantiate (stars[rnd], vector, Quaternion.identity);
		
		Invoke("SpawnStar", 5);
	}
}
