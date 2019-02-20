using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudScript : MonoBehaviour {

    public Transform target;
    private RectTransform healthbarTransform;
    private float maxHealthbarWidth;

	// Use this for initialization
	void Start () {
        healthbarTransform = this.gameObject.transform.FindChild("Mask").FindChild("SubMask").gameObject.GetComponent<RectTransform>();
        maxHealthbarWidth = healthbarTransform.sizeDelta.x;    
    }
	
	// Update is called once per frame
	void Update () {
        int maxHealth = target.GetComponent<Stats>().maxHealth;
        int currentHealth = target.GetComponent<Stats>().currentHealth;
        healthbarTransform.sizeDelta = new Vector2(maxHealthbarWidth*((float)currentHealth /maxHealth), healthbarTransform.sizeDelta.y);
    }   
}
