using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed;
	public int normalDropRate;
	public int boostDropRate;
	public int boostEndPoint;
	public int startHealth;
	public Text health;
	public Material m;

	private int currentHealth;
	private bool gameOver;
	private bool isBoost;

	private float jumpHeight = 7.0f;
	private Rigidbody rb;
	private Transform tf;
	void Start () {
		rb = GetComponent<Rigidbody>();
		tf = GetComponent<Transform> ();
		currentHealth = startHealth;
		health.text = "Health: " + currentHealth.ToString();
		InvokeRepeating("lostHealth", 5, 1);
		gameOver = false;
		isBoost = false;
		m.SetColor("_Color", Color.yellow);
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);

		rb.AddForce (movement * speed);
		if (Input.GetKeyDown (KeyCode.Space)) {
			if(tf.position.y <= 2.0f) {
				rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
			}
		}

		if (currentHealth <= 0) {
			gameOver = true;
			currentHealth = 0;
			gameObject.SetActive(false);
		}

		if (currentHealth < boostEndPoint) {
			isBoost = false;
			m.SetColor("_Color", Color.yellow);
			if (currentHealth < 33){
				m.SetColor("_Color",Color.red);
			} else {
				m.SetColor("_Color", Color.yellow);
			}
		}


		health.text = "Health: " + currentHealth.ToString();
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pill")) 
		{
			currentHealth = currentHealth + 10;
			if (currentHealth > startHealth) {
				isBoost = true;
				m.SetColor("_Color", Color.magenta);
				currentHealth = 100;
			}
		}
		if (other.gameObject.CompareTag ("Harzard")) 
		{
			if (!isBoost){
				currentHealth = currentHealth - 10;
			}
		}
		Destroy(other.gameObject);
	}

	private void lostHealth(){
		if (isBoost) {
			currentHealth = currentHealth - boostDropRate;
		} else {
			currentHealth = currentHealth - normalDropRate;
		}
	}

	public bool isGameOver(){
		return gameOver;
	}

	public bool isBoosting(){
		return isBoost;
	}

	public float getCurrentHealth(){
		return ((float)currentHealth) / 100.0f;
	}



}
     