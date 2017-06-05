using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootScript : MonoBehaviour {

    public GameObject ammo;

    void Start () {
	}

    void Update() {
        if (Input.GetButtonDown("Fire")) {
            ammo.GetComponent<RocketScript>().sourceWeapon = this.transform;
            Instantiate(ammo);
        }
    }

}
