using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Are viteză foarte mare, dar constantă din momentul tragerii
 * Se anulează la impact
 * Iese din ambele turete ale armei 
 * IGNORĂ IMPACTUL CU PLAYERUL CARE A TRAS
 */
public class BulletScript : MonoBehaviour {

    public int damage;
    public GameObject RocketExplosionGO;
    private enum Turret {
        LEFT, RIGHT
    }
    private static Turret currentTurretTurn;

    static BulletScript() {
        currentTurretTurn = Turret.LEFT;
    }

    // Use this for initialization
    void Start() {
        this.gameObject.transform.Translate(0.6f * Vector3.up);
        if (currentTurretTurn == Turret.LEFT)
            this.gameObject.transform.Translate(-0.2f * Vector3.right);
        else
            this.gameObject.transform.Translate(0.2f * Vector3.right);
        changeTurrentTurn();

        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(5 * (Vector2) this.gameObject.transform.parent.parent.transform.up + 0.1f * this.gameObject.transform.parent.parent.GetComponent<Rigidbody2D>().velocity);

        BoxCollider2D bc = this.gameObject.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(this.gameObject.transform.parent.parent.GetComponent<BoxCollider2D>(), bc);
    }

    // Update is called once per frame
    void Update() {
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            Debug.Log("Ai tras in masina " + col.gameObject);
            col.gameObject.GetComponent<Stats>().currentHealth -= damage;
            Debug.Log(col.gameObject.GetComponent<Stats>().currentHealth);
        }
        PlayExplosion();
        Destroy(this.gameObject);
    }

    void PlayExplosion() {
        GameObject explosion = Instantiate(RocketExplosionGO);
        explosion.transform.position = this.transform.position;
        explosion.transform.localScale = new Vector3(0.2f, 0.2f, 0);
    }

    private void changeTurrentTurn() {
        if (currentTurretTurn == Turret.RIGHT)
            currentTurretTurn = Turret.LEFT;
        else
            currentTurretTurn = Turret.RIGHT;
    }
}