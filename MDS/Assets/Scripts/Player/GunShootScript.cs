using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootScript : MonoBehaviour {

    public GameObject ammo;

    void Start () {
	}

    public void Shoot() {
        Instantiate(ammo, this.gameObject.transform, false);
    }

}
