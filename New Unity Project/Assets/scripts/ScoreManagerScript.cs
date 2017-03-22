using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManagerScript : MonoBehaviour {

	// FIND THE HEALTH STUFF
	public HealthManagerScript hms;
	public SceneManagerScript sceneManager;

	// FOR SCORING
	public List <int> damageKeeper1;
	public List <int> damageKeeper2;
	public List <int> timesWon1;
	public List <int> timesWon2;

	// FOR COUNTING VALUES
	public int total1;
	public int total2;

	// TEXT MESH
	public Text winnerText;

	// Use this for initialization
	public void Start () {

		hms = gameObject.GetComponent<HealthManagerScript> ();
		sceneManager = GameObject.Find ("GameManager").GetComponent<SceneManagerScript> ();

		winnerText = GameObject.Find ("Winner").GetComponent<Text> ();
		winnerText.text = " ";
		
	}

	public void FindTheWinner () {

		// total the lists
		ListTotaler (damageKeeper1, total1);
		ListTotaler (damageKeeper2, total2);

		// compare the values and add the wins
		if (total1 > total2) {
			timesWon1.Add(1);
			winnerText.text = "Player 1 wins this round";
		} else if (total2 > total1) {
			timesWon2.Add(1);
			winnerText.text = "Player 2 wins this round";
		} else if (total1 == total2) {
			winnerText.text = "It's a draw yo you both win this time, r to reset";
		}
			
		// choosing scenes to reload
		if (winnerText.text.Contains ("1")) {
			sceneManager.P1InCharge ();
			sceneManager.reloads++;
		} else if (winnerText.text.Contains ("2")) {
			sceneManager.P2InCharge ();
			sceneManager.reloads++;
		} else if (winnerText.text.Contains ("draw")) {
			if (Input.GetKeyDown (KeyCode.R)) {
				sceneManager.StartLevel ();
				sceneManager.reloads++;
			}
		}
			
	}

	public void ListTotaler(List<int> list, int f){
		foreach (int i in list) {
			f += i;
		}
	}
}
