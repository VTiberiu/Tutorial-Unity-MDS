using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootScript : MonoBehaviour {

    public GameObject ammo;

    void Start () {
	}

    void Update() {
        if (Input.GetButtonDown("Fire")) {
            Instantiate(ammo, this.gameObject.transform, false);
        }
    }

}
