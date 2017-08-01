using UnityEngine;
using System.Collections;

public class HealthBarEdgeController : MonoBehaviour {

	public GameObject player;
	public PlayerController controller;
	public Material m;
	public Texture darkRed;
	public Texture black;
	private Renderer rend;
	void Start () {
		controller = player.GetComponent<PlayerController> ();
	}

	void Update () {
		float percentage = controller.getCurrentHealth ();
		if (percentage >= 0.3) {
			m.SetTexture("_MainTex", black);
		}
		else {
			m.SetTexture("_MainTex", darkRed);
		}
	}
}
