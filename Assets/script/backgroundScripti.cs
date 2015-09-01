using UnityEngine;
using System.Collections;

public class backgroundScripti : MonoBehaviour {

	public float speed = 0.5f;
	public GameObject Target;
	
	void Start ()
	{
		
	}
	
	void Update ()
	{
		Vector2 offset = new Vector2 (Time.time * speed, 0);
		GetComponent<Renderer>().material.mainTextureOffset = offset;
		this.transform.position = new Vector3(Target.transform.position.x + 7, 5, 2);
	}
}
