using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCarWithinBoundsScript : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(Mathf.Max(Mathf.Min(target.position.x, 5), -5), Mathf.Max(Mathf.Min(target.position.y, 10), -10), -10);
	}
}
