using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Își crește gradual viteza din momentul tragerii
 * Explodează la impact (cu damage, opțional)
 * IGNORĂ IMPACTUL CU PLAYERUL CARE A TRAS
 * Are un lifespan de 10 secunde
 * Enemy tracking(opțional)
 */
public class RocketScript : MonoBehaviour {

    public GameObject RocketExplosionGO;

	// Use this for initialization
	void Start () {
        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(40 * this.gameObject.transform.parent.parent.GetComponent<Rigidbody2D>().velocity);
        this.gameObject.transform.parent.parent.GetComponent<Rigidbody2D>().AddForce((-50 * new Vector2(this.gameObject.transform.parent.up.x, this.gameObject.transform.parent.up.y) * Mathf.Min(Mathf.Max(this.gameObject.transform.parent.parent.GetComponent<Rigidbody2D>().velocity.magnitude, 1), 1)));

        BoxCollider2D bc = this.gameObject.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(this.gameObject.transform.parent.parent.GetComponent<BoxCollider2D>(), bc);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        this.GetComponent<Rigidbody2D>().AddForce(2 * transform.up);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            Debug.Log("Ai tras in masina " + col.gameObject);
            col.gameObject.GetComponent<Stats>().currentHealth--;
            Debug.Log(col.gameObject.GetComponent<Stats>().currentHealth);
        }
        PlayExplosion();
        Destroy(this.gameObject);
    }

    void PlayExplosion()
    {
        GameObject explosion = Instantiate(RocketExplosionGO);
        explosion.transform.position = this.transform.position;
    }
}
