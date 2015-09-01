using UnityEngine;
using System.Collections;

public class gameOverScript : MonoBehaviour {
	GameObject text;
	GUIText myText;
	int higthScore;
	int CurrentScore;
	private GUISkin skin;

	void Start () {
		higthScore = PlayerPrefs.GetInt("HighScore");
		CurrentScore = PlayerPrefs.GetInt("currentScore");
		text = new GameObject("SomeGUIText");
		Instantiate(text);
		myText = text.AddComponent<GUIText>();
		myText.transform.position = new Vector3(0.2f,0.2f,0f);
		myText.GetComponent<GUIText> ().text = "Score: " + CurrentScore + " Meilleur score : " + higthScore;
		myText.GetComponent<GUIText> ().fontSize = 100;
		skin = Resources.Load("GUISkin") as GUISkin;
	}
	void OnGUI()
	{
		const int buttonWidth = 500;
		const int buttonHeight = 150;
		GUI.skin = skin;

		// Centré en x, 1/3 en y
		if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (1 * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight), "Rejouer!"))
		{
			// Recharge le niveau
			Application.LoadLevel(1);
		}
		// Centré en x, 2/3 en y
		if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2), buttonWidth + 200, buttonHeight), "Menu Principal"))
		{
			// Retourne au menu
			Application.LoadLevel(0);
		}
	}
}
