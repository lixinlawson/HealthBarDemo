using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	
	public float speed;

	private Rigidbody rb;
	void Start()
	{
		rb = GetComponent<Rigidbody>();	
	}
	void FixedUpdate () {
		Vector3 movement = new Vector3 (0.0f, 0.0f, -speed);
		rb.AddForce (movement * speed);
	}
}