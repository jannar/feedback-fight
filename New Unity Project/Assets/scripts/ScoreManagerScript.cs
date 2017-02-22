using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManagerScript : MonoBehaviour {

	// FIND THE HEALTH STUFF
	public HealthManagerScript hms;

	// FOR WRITING/SAVING VALUES
	public FileIOScript fs;

	// FOR COUNTING VALUES
	public int total1;
	public int total2;

	// TEXT MESH
	public Text winnerText;

	// Use this for initialization
	void Start () {

		hms = gameObject.GetComponent<HealthManagerScript> ();
		fs = GameObject.Find("GameManager").GetComponent<FileIOScript> ();
		winnerText = GameObject.Find ("Winner").GetComponent<Text> ();

		winnerText.text = " ";
		
	}
	
	// Update is called once per frame
	void Update () {

		// basically checking to see if there's a winner
		if (hms.BoxHealth == 0) {

			// total the lists
			total1 = fs.damageKeeper1.Count;
			total2 = fs.damageKeeper2.Count;
//			ListTotaler (fs.damageKeeper1, total1);
//			ListTotaler (fs.damageKeeper2, total2);

			// compare the values and add the wins
			if (total1 > total2) {
				fs.timesWon1.Add(1);
				winnerText.text = "Player 1 wins this round";
			} else if (total2 > total1) {
				fs.timesWon2.Add(1);
				winnerText.text = "Player 2 wins this round";
			} else if (total1 == total2) {
				fs.timesWon1.Add(1);
				fs.timesWon2.Add(1);
				winnerText.text = "It's a draw yo you both win this time";
			}

			if (SceneManager.GetActiveScene ().name == "main-stage-1") {
				SceneManager.LoadScene (2);
			} else if (SceneManager.GetActiveScene().name == "main-stage-2"){
				SceneManager.LoadScene(3);
			}
				
		}
	}

	void ListTotaler(List<int> list, int f){
		foreach (int i in list) {
			f += i;
		}
	}
}
