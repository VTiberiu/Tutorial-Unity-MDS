using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

	public void GotoScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
	}

    public void SetCurrentPlayerItems() {
        string car = GameObject.Find("Car Dropdown").transform.FindChild("Label").gameObject.GetComponent<Text>().text;
        string weapon = GameObject.Find("Weapon Dropdown").transform.FindChild("Label").gameObject.GetComponent<Text>().text;

        PlayerPrefs.SetString("car", car);
        PlayerPrefs.SetString("weapon", weapon);
    }
}
