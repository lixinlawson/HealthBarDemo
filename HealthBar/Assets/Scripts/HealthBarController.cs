using UnityEngine;
using System.Collections;

public class HealthBarController : MonoBehaviour {

	public GameObject player;
	private PlayerController controller;
	public Material m;

	public Texture green;
	public Texture yellow;
	public Texture red;

	private Vector3 offset;
	
	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
		controller = player.GetComponent<PlayerController> ();
	}

	void Update(){
		float percentage = controller.getCurrentHealth ();
		if (percentage >= 0.67) {
			m.SetTexture ("_CurrentTex", green);
		} else if (percentage >= 0.33) {
			m.SetTexture ("_CurrentTex", yellow);
		} else {
			m.SetTexture ("_CurrentTex", red);
		}
		m.SetFloat("_CurrentHealth", percentage);

		if (controller.isGameOver ()) {
			gameObject.SetActive(false);
		}

	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
