using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2DWASDControllerScript : MonoBehaviour {

    public float speedForce;
    public float torqueForce;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void FixedUpdate() {
        Rigidbody2D carRigidBody = this.GetComponent<Rigidbody2D>();

        //0 - nu driftează deloc, 1 - driftează la 90 de grade
        float driftFactor = 1 - (carRigidBody.velocity.magnitude != 0 ? (float)Math.Pow(Math.Abs(Vector2.Dot(carRigidBody.velocity.normalized, new Vector2(transform.up.x, transform.up.y))), 2) : 1);
        /*produsul scalar a doi vectori arată "cât de paraleli" sunt ei;
        în cazul acesta produsul scalar dintre vectorul cu direcția pe care o înfruntă mașina
        și vectorul cu direcția velocității este 0 când aceștia sunt perpendiculari (mașina driftează la 90 de grade)
        sau 1 când sunt paraleli (mașina merge înainte fără să drifteze); scad rezultatul final din 1 ca să obțin
        driftFactor*/

        //0 - mașina stă pe loc, 1 - virajul are randament maxim
        float turnFactor = (float)Math.Pow(Math.Min(carRigidBody.velocity.magnitude / torqueForce, 1), 2);
        //inversează direcția virajului când dă cu spatele
        turnFactor = Math.Sign(Vector3.Dot(carRigidBody.velocity.normalized, carRigidBody.transform.up)) * Math.Abs(turnFactor);

        //înainte + înapoi
        carRigidBody.AddForce(Input.GetAxis("ThrottleP2") * speedForce * transform.up);
        //aplică forță pozitivă pe direcția pe care o înfruntă mașina

        //reducerea vitezei în caz de drift
        carRigidBody.AddForce((-driftFactor) * (speedForce / 2) * carRigidBody.velocity.normalized);
        /*aplică forță negativă pe direcția velocității, NU pe direcția pe care o înfruntă mașina;
        cu cât e driftFactoru mai mare, cu atât forța e mai mare*/

        //stânga + dreapta
        carRigidBody.AddTorque(-turnFactor * Input.GetAxis("SteeringP2") * torqueForce);

        //oprirea rotației când mașina stă pe loc
        carRigidBody.angularVelocity = carRigidBody.velocity.magnitude < 0.05 ? 0 : carRigidBody.angularVelocity;
        //când viteza mașinii scade sub o constantă oarecare (se alege să fie cât mai realist) viteza unghiulară e setată la 0

        //Debug.Log(carRigidBody.velocity.magnitude);   
    }

    void Update() {
        if (Input.GetButtonDown("FireP1")) {
            this.gameObject.transform.GetChild(0).GetComponent<GunShootScript>().Shoot();
        }
    }
}
