using UnityEngine;
using System.Collections;

public class MarkController : MonoBehaviour {
	public GameObject player;
	private PlayerController controller;
	Renderer rend;
	void Start () {
		controller = player.GetComponent<PlayerController> ();
		rend = GetComponent<Renderer> ();
	}

	void Update () {
		if (controller.isBoosting()) {
			rend.enabled = true;
		} else {
			rend.enabled = false;
		}
	}
}
