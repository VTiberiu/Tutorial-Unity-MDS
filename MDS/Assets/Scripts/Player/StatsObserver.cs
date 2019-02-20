using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsObserver : MonoBehaviour {

    public GameObject RocketExplosionGO;
    private Stats currentStats;

	// Use this for initialization
	void Start () {
        currentStats = this.gameObject.GetComponent<Stats>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Assert(currentStats.currentHealth >= 0);

		if(currentStats.currentHealth == 0) {
            PlayExplosion();
            Destroy(this.gameObject);
        }
	}

    void PlayExplosion() {
        GameObject explosion = Instantiate(RocketExplosionGO);
        explosion.transform.position = this.gameObject.transform.position;
    }
}
