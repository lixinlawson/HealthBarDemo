using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	
	void OnTriggerExit(Collider other) {
		// Destroy everything that leaves the trigger
		Destroy(gameObject);
	}
}
