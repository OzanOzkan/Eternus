using UnityEngine;
using System.Collections;

public class InstantiateObjects : MonoBehaviour {

	public GameObject galaxy1;
	public Vector3 vector;
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		vector = new Vector3 (Random.Range(-15,15), 10 , 0);
		galaxy1 = (GameObject)Instantiate (galaxy1, vector, Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {
		galaxy1.transform.Translate (-Vector2.up * moveSpeed * Time.deltaTime);
		// galaxy1.transform.position = Vector3.Lerp (galaxy1.transform.position, new Vector3 (galaxy1.transform.position.x, -10, galaxy1.transform.position.z), 0.1f);
	}
}
