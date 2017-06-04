using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootScript : MonoBehaviour {

    public Sprite sprite;

    void Start () {
	}

    void Update() {
        if (Input.GetButtonDown("Fire")) {
            GameObject ammo = new GameObject("Rocket");
            RocketScript rs = ammo.AddComponent<RocketScript>();
            rs.sourceWeapon = this.gameObject.transform;
            rs.sprite = sprite;
        }
    }

}
