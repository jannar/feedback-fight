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
	// I was originally going to have this total the values of the ints in the list itself,
	// but it got complicated and I got frustrated so oops.
	public int total1;
	public int total2;

	// Use this for initialization
	void Start () {

		hms = gameObject.GetComponent<HealthManagerScript> ();
		fs = gameObject.GetComponent<FileIOScript> ();
		
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
				AddWins (fs.timesWon1, 1);
			} else if (total2 > total1) {
				AddWins (fs.timesWon2, 1);
			} else if (total1 == total2) {
				AddWins (fs.timesWon1, 1);
				AddWins (fs.timesWon2, 1);
			}
		}
	}

//	void ListTotaler(List<int> list, float f){
//		foreach (int i in list) {
//			f += i;
//		}
//	}

	// whoever is bigger value gets the win
	void AddWins(List<int> list, int i){
		list.Add (i);
		Debug.Log (list);
	}
}
