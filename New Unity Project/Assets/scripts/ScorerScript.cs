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

	// Use this for initialization
	void Start () {

		gameManager = GameObject.Find("GameManager");
		hms = gameManager.GetComponent<HealthManagerScript> ();
		pms = gameObject.GetComponent<PlayerMovementScript> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (this.pms.speed < MIN_SPEED) {
			this.pms.speed = MIN_SPEED;
		}

		if (this.pms.speed > MAX_SPEED) {
			this.pms.speed = MAX_SPEED;
		}

		//if (gameObject.name.Contains(2) )
		
	}

	// I was going to try to fix this so that only one could do damage at a time,
	// but I actually find it kind of compelling that both do damage. Still, that would
	// change the win condition somewhat, so there has to be a way for both players to
	// put health back, rather than just one.
	void OnCollisionEnter2D(Collision2D other) {

		if (other.gameObject.name.Contains("Player1")) {
			Damager (player2, player2Damage);
		} else if (other.gameObject.name.Contains("Player2")) {
			Damager (player1, player1Damage);
		}

	}

	public void Damager(GameObject go, int damage){

		hms.BoxHealth = hms.BoxHealth - damage;

		if (go == player1) {
			damage++;
			pms.speed--;
			Debug.Log ("Damaging " + damage);

		} else if (go == player2) {
			damage--;
			pms.speed++;
			Debug.Log ("Damaging " + damage);
		}

		if (damage > 0) {
			damage = 0;
		}
	}
}
