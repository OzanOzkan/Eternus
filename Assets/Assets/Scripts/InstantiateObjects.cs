using UnityEngine;
using System.Collections;

public class InstantiateObjects : MonoBehaviour {

	public GameObject galaxy1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		int GalaxyInitiate = Random.Range (0, 5);

		if (GalaxyInitiate == 1) {
			Vector3 vector = new Vector3 (Random.Range(-12,12), 10 , 0);
			Instantiate (galaxy1, vector, Quaternion.identity);
			var vel = galaxy1.rigidbody2D.velocity;

			while (vel.y >= -10){
				vel.y =- 1;
			}
		}
	}
}
