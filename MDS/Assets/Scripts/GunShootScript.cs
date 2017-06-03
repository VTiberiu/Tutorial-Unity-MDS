using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootScript : MonoBehaviour {

    public Sprite sprite;
    private Component comp;

    void Start () {
        comp = null;
	}

    void FixedUpdate() {
        if (Input.GetButtonDown("Fire")) {
            GameObject ammo = new GameObject("Ammo");
            SpriteRenderer sr = ammo.AddComponent<SpriteRenderer>();
            sr.sprite = sprite;
            sr.sortingLayerName = "Foreground";
            ammo.transform.position = this.transform.position;
            ammo.transform.rotation = this.transform.rotation;

            Rigidbody2D rb = ammo.AddComponent<Rigidbody2D>();
            comp = rb;
            rb.gravityScale = 0;
            rb.AddForce(transform.up * 500);
        }
        if (comp != null)
            Debug.Log(((Rigidbody2D)comp).velocity.magnitude);
        Debug.Log("asd" + (transform.up * 200).magnitude);
    }

}
