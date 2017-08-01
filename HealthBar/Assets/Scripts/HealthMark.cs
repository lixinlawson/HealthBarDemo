using UnityEngine;
using System.Collections;

public class HealthMark : MonoBehaviour {

	public GameObject player;
	public GameObject mark;

	private PlayerController controller;

	Vector3 offset;
	void Start () {
		controller = player.GetComponent<PlayerController> ();
	}

	void LateUpdate () {
		float currentHealth = controller.getCurrentHealth ();
		transform.position = new Vector3 (mark.transform.position.x + ((currentHealth) * 9.55f)/6.72f,
		                                  mark.transform.position.y,
		                                  mark.transform.position.z);

	}

}
