using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

	public KeyCode moveLeft = KeyCode.LeftArrow;
	public KeyCode moveRight = KeyCode.RightArrow;
	public KeyCode moveUp = KeyCode.UpArrow;
	public KeyCode moveDown = KeyCode.DownArrow;

	public float speed = 10.0f;
	public float touchSpeed = 0.05f;

	public GameObject shipCannon;
	bool shieldActive;
	bool laserBeamActive;
	bool ulti01Active;
	public float laserFireSpeed;
	public float bulletFireSpeed;
	public GameObject bullet;
	public GameObject blastPrefab;

	public GameObject damagePrefab;
	GameObject damage;

	public float health;
	public float level;
	public float killCount;
	public float newLevelSeed;

	public GameObject[] powerUps;
	GameObject tempShield;
	public int randomPowerUp;
	float savedTime;
	public float powerUpDuration;

	// Use this for initialization
	void Start () {
		shieldActive = false;
		laserBeamActive = false;
		randomPowerUp = -1;

		Invoke("SpawnBullet", bulletFireSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		shipCannon.transform.position = this.transform.position + new Vector3 (0.0f, 2.0f, 0.0f);

		// PC Controls
		if (Input.GetKeyDown (moveLeft)) {
			var vel = rigidbody2D.velocity;
			vel.x = -1 * speed;
			rigidbody2D.velocity = vel;
		} else if (Input.GetKeyDown (moveRight)) {
			var vel = rigidbody2D.velocity;
			vel.x = speed;
			rigidbody2D.velocity = vel;
		} else if (Input.GetKeyDown (moveDown)) {
			var vel = rigidbody2D.velocity;
			vel.y = -1 * speed;
			rigidbody2D.velocity = vel;
		} else if (Input.GetKeyDown (moveUp)) {
			var vel = rigidbody2D.velocity;
			vel.y = speed;
			rigidbody2D.velocity = vel;
		} else if (!Input.anyKey) {
			var vel = rigidbody2D.velocity;
			vel.x = 0;
			rigidbody2D.velocity = vel;
		}

		// Touch Controls
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			transform.Translate(touchDeltaPosition.x * touchSpeed, touchDeltaPosition.y * touchSpeed, 0);
		}

		// Limiting player's movement boundaries
		if (transform.position.x <= -4.0f)
			transform.position = new Vector2(-4.0f, transform.position.y);
		else if (transform.position.x >= 4.0f)
			transform.position = new Vector2(4.5f, transform.position.y);
		else if (transform.position.y >= 5.5f)
			transform.position = new Vector2(transform.position.x, 5.5f);
		else if (transform.position.y <= -6.5f)
			transform.position = new Vector2(transform.position.x, -6.5f);

		// Levelling
		if (killCount == newLevelSeed) {
			level++;
			newLevelSeed += newLevelSeed;

			GameObject gameController = GameObject.Find("GameController");
			InstantiateObjects instantiateObjects = gameController.GetComponent<InstantiateObjects>();
			if (instantiateObjects.enemySpawnSpeed >= 0.5)
				instantiateObjects.enemySpawnSpeed -= 0.20f;

			if (bulletFireSpeed >= 0.3)
				bulletFireSpeed -= 0.20f;
		}

		// Shield
		if (randomPowerUp == 0) {
			if (!shieldActive) {
				tempShield = (GameObject)Instantiate (powerUps [0], this.transform.position, Quaternion.identity);

				BoxCollider2D collider = GetComponent<BoxCollider2D> ();
				collider.enabled = false;
				
				shieldActive = true;
				savedTime = Time.time;
			} else {
				if (Time.time - savedTime >= powerUpDuration) {
					shieldActive = false;
					randomPowerUp = -1;

					BoxCollider2D collider = GetComponent<BoxCollider2D> ();
					collider.enabled = true;

					Destroy (tempShield);
				} else {
					tempShield.transform.position = this.transform.position;
				}
			}
		}
		// Laser Beam
		else if (randomPowerUp == 1) {
			if (!laserBeamActive) {
				Invoke ("SpawnLaserBeam", laserFireSpeed);
				laserBeamActive = true;
				savedTime = Time.time;
			} else {
				if (Time.time - savedTime >= powerUpDuration) {
					laserBeamActive = false;
					randomPowerUp = -1;
				}
			}
		} // Ulti 01 
		else if (randomPowerUp == 2) {
			if (!ulti01Active){
				tempShield = (GameObject)Instantiate (powerUps [2], shipCannon.transform.position, Quaternion.identity);
				ulti01Active = true;
				savedTime = Time.time;
			} else {
				if(Time.time - savedTime >= powerUpDuration){
					ulti01Active = false;
					randomPowerUp = -1;

					Destroy(tempShield);
				} else {
					tempShield.transform.position = shipCannon.transform.position;
				}
			}
		}

		damage.transform.position = this.transform.position;

	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "EnemyBullet" || col.gameObject.tag == "Enemies") {

			Destroy(col.gameObject);

			GameObject GameController = GameObject.Find("GameController");
			GUIController guiController = GameController.GetComponent<GUIController>();
			guiController.PlayerDamageUI();

			damage = (GameObject)Instantiate (damagePrefab,this.transform.position, Quaternion.identity);
			Destroy(damage.gameObject, 0.3f);

			if(health > 1){
				health -= 1;				
			} else {
				Destroy(this.gameObject);
				Destroy(shipCannon.gameObject);

				GameObject blast = (GameObject)Instantiate (blastPrefab,this.transform.position, Quaternion.identity);
				Destroy(blast.gameObject, 0.5f);
				
				GameObject UI = GameObject.Find("UI");
				GameObject Buttons = UI.transform.Find("Buttons").gameObject;
				Buttons.SetActive(true);
			}
		}
	}

	void SpawnLaserBeam(){
		GameObject currentLaserBeam = (GameObject)Instantiate (powerUps[1], shipCannon.transform.position, Quaternion.identity);

		if (laserBeamActive) {
			Invoke ("SpawnLaserBeam", laserFireSpeed);
		}
	}

	void SpawnBullet(){
		GameObject currentBullet = (GameObject)Instantiate (bullet, shipCannon.transform.position, Quaternion.identity);
		
		Invoke("SpawnBullet", bulletFireSpeed);
	}
}	