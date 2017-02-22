using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorerScript : MonoBehaviour {

	// GAME OBJECTS
	public GameObject player1, player2;

	// VARIABLES FOR DAMAGE AND SPEED
	public int player1Damage;
	public int player2Damage;
	public PlayerMovementScript pms;
	private const int MIN_SPEED = 1;
	private const int MAX_SPEED = 50;

	// FIND THE HEALTH STUFF
	public GameObject gameManager;
	public HealthManagerScript hms;

	// FOR WRITING/SAVING VALUES
	public FileIOScript fs;

	// Use this for initialization
	void Start () {

		gameManager = GameObject.Find("GameManager");
		hms = gameManager.GetComponent<HealthManagerScript> ();
		pms = gameObject.GetComponent<PlayerMovementScript> ();
		fs = gameManager.GetComponent<FileIOScript> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (this.pms.speed < MIN_SPEED) {
			this.pms.speed = MIN_SPEED;
		}

		if (this.pms.speed > MAX_SPEED) {
			this.pms.speed = MAX_SPEED;
		}
	}

	void FixedUpdate(){

		if (pms.player2Move && Input.GetKey (KeyCode.RightShift)) {
			healthReturn (player1, player1Damage);
			Debug.Log ("health added: " + hms.BoxHealth);
		}

	}

	void OnCollisionEnter2D(Collision2D other) {

		if (other.gameObject.name.Contains ("Player1") && pms.player2Move) {
			Damager (player2, player2Damage);
		}

		if (other.gameObject.name.Contains("Player2") && pms.player1Move) {
			Damager (player1, player1Damage);
		}
	}

	public void Damager(GameObject go, int damage){

		hms.BoxHealth = hms.BoxHealth - damage;

		if (go == player1) {
			damage++;
			pms.speed--;
			fs.damageKeeper1.Add (damage);
			Debug.Log ("Damaging " + damage);

		} else if (go == player2) {
			damage--;
			pms.speed++;
			fs.damageKeeper2.Add (damage);
			Debug.Log ("Damaging " + damage);
		}

		if (damage > 0) {
			damage = 0;
		}
	}

	public void healthReturn(GameObject go, int plusHealth){
		hms.BoxHealth = hms.BoxHealth + (plusHealth - 2);
	}
}
