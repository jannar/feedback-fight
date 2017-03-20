﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagerScript : MonoBehaviour {

	// VARIABLES FOR HEALTH MAINTENANCE
	public const int BOX_HEALTH_MIN = 0;
	public const int BOX_HEALTH_MAX = 50;

	private static int boxHealth;

	// BoxHealth property
	public int BoxHealth{
		get {
			return boxHealth;
		}

		set {
			boxHealth = value;

			if (boxHealth > BOX_HEALTH_MAX) {
				boxHealth = BOX_HEALTH_MAX;
			}

			if (boxHealth < BOX_HEALTH_MIN) {
				boxHealth = BOX_HEALTH_MIN;
			}
		}
	}

	// VARIABLES FOR SCORING AND SAVING
	private const string WINNER_STREAK = "winnerStreak";

	private int streak;

	// Streak property
	public int Streak{
		get {
			return streak;
		}

		set{
			streak = value;

			if (streak > StreakValue) {
				StreakValue = streak;
			}

			Debug.Log (streak);
		}
	}

	private int streakValue = 3;

	// StreakValue property
	public int StreakValue{
		get { 
			streakValue = PlayerPrefs.GetInt (WINNER_STREAK);
			return streakValue;
		}

		set {
			Debug.Log ("New Streak!!!");
			streakValue = value;
			PlayerPrefs.SetInt (WINNER_STREAK, streakValue);
		}
	}

	public static HealthManagerScript instance;

	// Use this for initialization
	void Start () {

		// don't destroy on load
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this);
		} else {
			Destroy (gameObject);
		}

		// keep the health the max score
		BoxHealth = BOX_HEALTH_MAX;

	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log ("boxHealth: " + boxHealth);
		Debug.Log ("streakValue: " + streakValue);
		
	}
}
