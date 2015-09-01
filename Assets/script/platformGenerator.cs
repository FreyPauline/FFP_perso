using UnityEngine;
using System.Collections;

public class platformGenerator : MonoBehaviour {

	public float timer = 0.0f;
	public GameObject player;
	public GameObject myPrefab ;
	float nb;
	void Start () {
		Swap ();
	}
	
	void Update () {
		this.transform.position = new Vector3 (player.transform.position.x + 37, 3, 0);
		
		
		
	}
	
	void Swap()
	{
		Instantiate(myPrefab, new Vector3 (player.transform.position.x + 37, 3, 0), transform.rotation);
		nb = Random.Range (3f, 12f);
		Invoke ("Swap", nb);
	}
}
