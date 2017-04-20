using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2DControllerScript : MonoBehaviour {

	public float speedForce =100f;
	public float torquqForce = 100f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		if (Input.GetButton ("Accelerate")) {
			rb.AddForce (transform.up * speedForce);
		} else if (Input.GetButton ("Break")) {
			rb.AddForce (-transform.up * speedForce);
		}

		rb.AddTorque (Input.GetAxis ("Horizontal") * torquqForce);




	}
}
