using UnityEngine;
using System.Collections;

public class menuScript : MonoBehaviour {
	GameObject text;
	GUIText myText;
	int higthScore;
	private GUISkin skin;

	void Start () {
		higthScore = PlayerPrefs.GetInt ("HighScore");
		text = new GameObject ("SomeGUIText");
		Instantiate (text);
		myText = text.AddComponent<GUIText> ();
		myText.transform.position = new Vector3 (0.3f, 0.2f, 0f);
		myText.GetComponent<GUIText> ().text = " Meilleur score : " + higthScore;
		myText.GetComponent<GUIText> ().fontSize = 100;
		// Chargement de l'apparence
		skin = Resources.Load("GUISkin") as GUISkin;
	}

	void OnGUI()
	{
		const int buttonWidth = 300;
		const int buttonHeight = 150;
		GUI.skin = skin;
		// Affiche un bouton pour démarrer la partie
		// Centré en x, 2/3 en y
		if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight), "Start!"))
		{
			// Sur le clic, on démarre le premier niveau
			Application.LoadLevel(1);
		}
	}
}
