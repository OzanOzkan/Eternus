using UnityEngine;
using System.Collections;

public class InstantiateObjects : MonoBehaviour {

	public GameObject[] galaxies;
	public GameObject[] stars;
	public Vector3 vector;
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		Invoke("SpawnGalaxy", 20);
		Invoke("SpawnStar", 5);
	}

	// Update is called once per frame
	void Update () {

	}

	void SpawnGalaxy(){
		vector = new Vector3 (Random.Range(-12,12), 12 , 0);
		var rnd = Random.Range (0, 0);
		Instantiate (galaxies[rnd], vector, Quaternion.identity);

		Invoke("SpawnGalaxy", 20);
	}

	void SpawnStar(){
		vector = new Vector3 (Random.Range(-12,12), 12 , 0);
		var rnd = Random.Range (0, 2);
		Instantiate (stars[rnd], vector, Quaternion.identity);
		
		Invoke("SpawnStar", 5);
	}
}
