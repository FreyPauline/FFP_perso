using UnityEngine;
using System.Collections;

public class charactereScript : MonoBehaviour {

	public Vector3 mouvement = Vector3.zero;
	public float jump = 15f;
	bool onGround;
	int score = 0;
	GameObject text;
	GUIText myText;
	int highScore;
	Animator anim;
	private GUISkin skin;

	protected bool paused = false;

	//Use this for initialization
	void Start () {
		text = new GameObject("SomeGUIText");
		Instantiate(text);
		myText = text.AddComponent<GUIText>();
		myText.transform.position = new Vector3(0.1f,0.9f,0f);
		myText.GetComponent<GUIText> ().text = "Score ";
		myText.GetComponent<GUIText> ().fontSize = 100;
		SetCountText ();
		anim = GetComponent<Animator>();
		highScore = PlayerPrefs.GetInt("HighScore");
		skin = Resources.Load("GUISkin") as GUISkin;
	}
	
	//Update is called once per frame
    void Update() {
		transform.position += mouvement * Time.deltaTime;


    }
	void OnCollisionEnter(Collision ground) {
		if (ground.gameObject.name == "Sol" || ground.gameObject.name == "Sol(Clone)" || ground.gameObject.name == "platform(Clone)") {
			onGround = true;
			anim.SetBool("jumpBool", false);
		}

		if (ground.gameObject.name == "obsObject(Clone)") {
			if(score > PlayerPrefs.GetInt("HighScore")){
				PlayerPrefs.SetInt("HighScore",score );
			}
			PlayerPrefs.SetInt("currentScore",score );
			score = 0;
			Application.LoadLevel (2);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "cubeCoin" || other.gameObject.name == "cubeCoin(Clone)") {
			Destroy(other.gameObject);
			score += 5;
			SetCountText();
			
		}
	}
	void OnGUI () {
		Debug.Log ("coucou");
		GUI.skin = skin;
		// Set up gui skin
		const int buttonWidth = 100;
		const int buttonHeight = 100;
		// Our GUI is laid out for a 1920 x 1200 pixel display (16:10 aspect). The next line makes sure it rescales nicely to other resolutions.
		// GUI.matrix = Matrix4x4.TRS (Vector3(0, 0, 0), Quaternion.identity, Vector3 (Screen.height / nativeVerticalResolution, Screen.height / nativeVerticalResolution, 1));

		if(GUI.Button (new Rect(150f, 10f, buttonWidth, buttonHeight), "||"))
		{
			Debug.Log ("bouton");
			Time.timeScale = 0f;
			paused = true;
		}
		if(GUI.Button (new Rect(300f, 10f, 400, 100), "Restart"))
		{
			Application.LoadLevel(1);
			Time.timeScale = 1f;
			paused = false;
		}
		if(GUI.Button (new Rect(800f, 10f, 300, 100), "Menu"))
		{
			Application.LoadLevel(0);
			Time.timeScale = 1f;
			paused = false;
		}
		if(GUI.Button (new Rect(30f, 10f, buttonWidth, buttonHeight), "|>"))
		{
			Time.timeScale = 1f;
			paused = false;
		}
			
		Debug.Log (Time.timeScale);

		if (Input.GetMouseButtonDown(0) && paused != true && onGround == true) {
			Debug.Log ("coucou2");

			anim.SetBool("jumpBool", true);
			if (onGround == true){
				GetComponent<Rigidbody>().AddForce(Vector3.up * jump);
				onGround = false;
			}
		}		
	}

	void SetCountText() {
		myText.GetComponent<GUIText>().text = "Score: " + score;
	}
}