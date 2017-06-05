using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Își crește gradual viteza din momentul tragerii
 * Explodează la impact
 * IGNORĂ IMPACTUL CU PLAYERUL CARE A TRAS
 * Are un lifespan de 10 secunde
 * Enemy tracking(opțional)
 */
public class RocketScript : MonoBehaviour {

    public Transform sourceWeapon;

	// Use this for initialization
	void Start () {
        this.gameObject.transform.position = sourceWeapon.position;
        this.gameObject.transform.rotation = sourceWeapon.rotation;
        this.gameObject.transform.localScale = new Vector3(0.25f, 0.25f, 0);

        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(40 * sourceWeapon.parent.GetComponent<Rigidbody2D>().velocity);
        sourceWeapon.parent.GetComponent<Rigidbody2D>().AddForce((-250 * new Vector2(sourceWeapon.up.x, sourceWeapon.up.y)));

        BoxCollider2D bc = this.gameObject.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(sourceWeapon.parent.GetComponent<BoxCollider2D>(), bc);

        Destroy(this.gameObject, 10f);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        this.GetComponent<Rigidbody2D>().AddForce(20 * transform.up);
    }

    void OnCollisionEnter2D(Collision2D col) {
        Destroy(this.gameObject);
        Debug.Log("Racheta a colidat cu " + col.gameObject);
    }
}
