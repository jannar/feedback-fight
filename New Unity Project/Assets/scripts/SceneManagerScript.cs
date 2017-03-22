using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// USE ALL THE THINGS!!!!

public class SceneManagerScript : MonoBehaviour {

	public Button startText;
	public Button instructionsText;

	public static SceneManagerScript instance;

	// FOR BEIN' ABLE TO TELL IF THIS HAS ALL BEEN DONE BEFORE
	public int reloads = 0;

	// FOR LOADING NEW LEVELS
	// offsets
	public float offsetX = 0;
	public float offsetY = 0;

	// array for text levels
	// note: i really wanted to generate these procedurally
	// but I did not have the time
	// I did, however, read that book on Spelunky, so I hope that counts for something
	public string[] fileNames;
	public static int levelNum = 0;

	// Use this for initialization
	public void Start () {

		startText = startText.GetComponent<Button> ();
		instructionsText = instructionsText.GetComponent<Button> ();
		
	}

	public void StartLevel(){
		SceneManager.LoadScene (1);
	}

	public void ShowInstructions(){
		SceneManager.LoadScene (0);
	}

	public void P1InCharge(){
		SceneManager.LoadScene (3);
		LevelLoader ();
	}

	public void P2InCharge(){
		SceneManager.LoadScene (4);
		LevelLoader ();
	}

	public void LevelLoader(){
		// strings for places and things for the streamreader
		string fileName = fileNames [levelNum];
		string filePath = Application.dataPath + "/" + fileName;

		// streamreader to read levels from files
		StreamReader sr = new StreamReader (filePath);

		// gameobject to hold all them gatdang levels
		GameObject levelHolder = new GameObject ("Level Holder");

		// keep track of where the fuck we are
		int yPos = 0;

		// instantiate players from prefabs
		GameObject player1 = Instantiate (Resources.Load("prefabs/Player 1") as GameObject);
		GameObject player2 = Instantiate (Resources.Load("prefabs/Player 2") as GameObject);

		while (!sr.EndOfStream) {
			string line = sr.ReadLine ();

			for (int xPos = 0; xPos < line.Length; xPos++) {
				if (line [xPos] == 'x') {
					GameObject cube = Instantiate (Resources.Load("prefabs/Cube") as GameObject);
					cube.transform.parent = levelHolder.transform;

					cube.transform.position = new Vector3 (xPos + offsetX, yPos + offsetY, 0);

					float scaleX = cube.transform.localScale.x;
					float scaleY = cube.transform.localScale.y;

					float randomX = Random.Range (0f, 4f);
					float randomY = Random.Range (0f, 4f);

					// give it a random shape and size
					scaleX = randomX;
					scaleY = randomY;
				}

				if (line[xPos] == '1'){
					player1.transform.position = new Vector3 (xPos + offsetX, yPos + offsetY, 0);
				}

				if (line [xPos] == '2') {
					player1.transform.position = new Vector3 (xPos + offsetX, yPos + offsetY, 0);
				}
			}

			yPos--;
		}

		sr.Close ();

		levelNum++;
		
	}

}
