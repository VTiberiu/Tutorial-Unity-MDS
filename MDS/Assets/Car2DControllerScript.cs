using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2DControllerScript : MonoBehaviour {

	public float speedForce =10f;
	public float torquqForce = 1f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		if (Input.GetButton ("Accelerate")) {
			rb.AddForce (transform.up * speedForce);
		}

		rb.AddTorque (Input.GetAxis ("Horizontal") * torquqForce);
		
	}
}
