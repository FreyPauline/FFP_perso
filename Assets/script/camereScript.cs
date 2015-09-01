using UnityEngine;
using System.Collections;

public class camereScript : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (player.transform.position.x + 3, 6, -30);
	}
}
