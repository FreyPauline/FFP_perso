using UnityEngine;
using System.Collections;

public class groundDestroyScript : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (player.transform.position.x - 20, 0, 0);
	}
	void OnCollisionEnter(Collision otherObj) {
		Destroy (otherObj.gameObject, 1f);
	}
	void OnTriggerEnter(Collider other) {
			Destroy(other.gameObject, 1f);
	}
}
