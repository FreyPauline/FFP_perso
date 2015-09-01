using UnityEngine;
using System.Collections;

public class coinGenerator : MonoBehaviour {
	public float timer = 0.0f;
	public GameObject player;
	public GameObject myPrefab ;
	float nb;
	float nbPosition;
	void Start () {
		Swap ();
	}
	
	void Update () {
		this.transform.position = new Vector3 (player.transform.position.x + 47, 3, 0);
		
		
		
	}
	
	void Swap()
	{
		nbPosition = Mathf.PingPong(Time.time * 5, 4) + 1.5f;
		Instantiate(myPrefab, new Vector3 (player.transform.position.x + 47, nbPosition, 0), transform.rotation);
		nb = Random.Range (3f, 7f);
		Invoke ("Swap", nb);
	}
}