using UnityEngine;
using System.Collections;

public class InstantiateObjects : MonoBehaviour {

	public GameObject[] galaxies;
	private GameObject currentGalaxy;
	public Vector3 vector;
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		Invoke("SpawnGalaxy", 20);
	}

	// Update is called once per frame
	void Update () {
		if (currentGalaxy != null){
			currentGalaxy.transform.Translate (-Vector2.up * moveSpeed * Time.deltaTime);

			if(currentGalaxy.transform.position.y <= -18)
				Destroy(currentGalaxy);
		}
	}

	void SpawnGalaxy(){
		vector = new Vector3 (Random.Range(-12,12), 18 , 0);
		var rnd = Random.Range (0, 3);
		currentGalaxy = (GameObject)Instantiate (galaxies[rnd], vector, Quaternion.identity);

		Invoke("SpawnGalaxy", 20);
	}
}
