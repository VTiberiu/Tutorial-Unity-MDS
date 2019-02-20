using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    public int maxHealth;
    public float speedForce;
    public float torqueForce;
    [HideInInspector]
    public int currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        Debug.Log(currentHealth);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
