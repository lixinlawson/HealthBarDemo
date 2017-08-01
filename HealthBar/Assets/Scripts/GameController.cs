using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public GameObject pill;
	public GameObject player;
	private PlayerController controller;

	public Vector3 spawnValues;
	public int objectCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public Text restartText;
	public Text gameOverText;

	private bool restart;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnWaves ());
		controller = player.GetComponent<PlayerController> ();
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
	}
	
	// Update is called once per frame
	void Update()
	{
		if (restart) 
		{
			if(Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves() 
	{
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < objectCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				if (Random.Range(0.0f, 10.0f) > 3.5f) {
					Instantiate (hazard, spawnPosition, spawnRotation);
				} else {
					Instantiate (pill, spawnPosition, spawnRotation);
				}
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			if (controller.isGameOver())
			{
				restartText.text = "Press 'R' for Restart";
				gameOverText.text = "Game Over!";
				restart = true;
				break;
			}
		}
	}
}
