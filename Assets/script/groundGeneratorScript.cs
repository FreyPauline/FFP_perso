using UnityEngine;
using System.Collections;

public class groundGeneratorScript : MonoBehaviour {
    public float timer = 0.0f;
	public GameObject player;
	public GameObject myPrefab;

	void Start () {

	}

	void Update () {
		this.transform.position = new Vector3 (player.transform.position.x + 32, 0, 0);
		timer += Time.deltaTime;

		if (timer >= 0.3f) {
			Swap ();
		}

	}

	void Swap()
	{
		timer = 0;
		Instantiate(myPrefab, new Vector3 (player.transform.position.x + 32, 0, 0), transform.rotation);
	}
}
