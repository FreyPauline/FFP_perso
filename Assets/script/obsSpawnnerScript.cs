using UnityEngine;
using System.Collections;

public class obsSpawnnerScript : MonoBehaviour {
	public float timer = 0.0f;
	public GameObject player;
	public GameObject myPrefab ;
	float nb;
	void Start () {
		Swap ();
	}
	
	void Update () {
		this.transform.position = new Vector3 (player.transform.position.x + 36, 1, 0);


		
	}

	void Swap()
	{
		Instantiate(myPrefab, new Vector3 (player.transform.position.x + 36, 1, 0), transform.rotation);
		nb = Random.Range (2f, 10f);
		Invoke ("Swap", nb);
	}
}
