using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

	public Button startText;
	public Button instructionsText;
//	public Button resetText;

	public static SceneManagerScript instance;

	// Use this for initialization
	public void Start () {

		startText = startText.GetComponent<Button> ();
		instructionsText = instructionsText.GetComponent<Button> ();
//		resetText = resetText.GetComponent<Button> ();
		
	}

	// ADD MORE LEVELS AS NEEDED
	
	// Update is called once per frame
	public void Update () {
		
	}

	public void StartLevel(){
		SceneManager.LoadScene (1);
	}

	public void ShowInstructions(){
		SceneManager.LoadScene (0);
	}
}
