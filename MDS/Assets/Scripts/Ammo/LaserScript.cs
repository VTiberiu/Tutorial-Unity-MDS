using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Are viteză constantă din momentul tragerii
 * Se anulează la impact
 * Crește gradual în dimensiune din momentul tragerii
 * IGNORĂ IMPACTUL CU PLAYERUL CARE A TRAS
 * Are un lifespan de 10 secunde
 */
public class LaserScript : MonoBehaviour {

    public GameObject RocketExplosionGO;

    // Use this for initialization
    void Start() {
        this.gameObject.transform.Translate(2 * Vector3.up);

        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(50 * (Vector2) this.gameObject.transform.parent.parent.transform.up + this.gameObject.transform.parent.parent.GetComponent<Rigidbody2D>().velocity);

        BoxCollider2D bc = this.gameObject.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(this.gameObject.transform.parent.parent.GetComponent<BoxCollider2D>(), bc);
    }

    // Update is called once per frame
    void Update() {
        this.transform.localScale += new Vector3(Time.deltaTime / 4, Time.deltaTime / 4);
        this.gameObject.GetComponent<BoxCollider2D>().size += new Vector2(Time.deltaTime / 8, 0);
    }

        void OnCollisionEnter2D(Collision2D col) {
        PlayExplosion();
        Destroy(this.gameObject);
    }

    void PlayExplosion() {
        GameObject explosion = Instantiate(RocketExplosionGO);
        explosion.transform.position = this.transform.position;
    }
}
