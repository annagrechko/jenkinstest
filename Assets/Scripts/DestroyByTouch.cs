using UnityEngine;
using System.Collections;

public class DestroyByTouch : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;

	private GAmeController gameController;
	public int scoreValue;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GAmeController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GAmeController' script");
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
			return; 

		Instantiate (explosion, transform.position, transform.rotation);

		if (other.tag == "Player") 
		{
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}
		gameController.AddScore (scoreValue);

		Destroy(other.gameObject);
		Destroy (gameObject);
	}
}
