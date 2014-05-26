using UnityEngine;
using System.Collections;

public class GAmeController : MonoBehaviour 
{
	public GameObject hazard;
	public Vector3 spawnValue;
	public int hazartCount;

	public float spawnStart;
	public float spawnWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText gameOverText;
	public GUIText restartText;

	private bool gameOver;
	private bool restartGame;

	private int score;

	void Start()
	{
		gameOver = false;
		restartGame = false; 
		restartText.text = "";
		gameOverText.text = "";
		score = 0;

		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update()
	{
		if ((restartGame) &&  (Input.GetKeyDown (KeyCode.R)))
		{
			Application.LoadLevel (Application.loadedLevel);
		}
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (spawnStart);
		while (true) 
		{
			for (int i = 0; i< hazartCount; i++) {
					Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
					Quaternion spawnRotation = Quaternion.identity;
					Instantiate (hazard, spawnPosition, spawnRotation);
					yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restartGame = true;
				break;
			}
		}
	}

	public void AddScore(int scoreValue)
	{
		score += scoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score; 
	}

	public void GameOver()
	{
		gameOverText.text = "Game over!";
		gameOver = true;
	}
}
