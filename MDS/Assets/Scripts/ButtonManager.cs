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
        string carP1 = GameObject.Find("Player 1/Select Car/Car Dropdown").transform.Find("Label").gameObject.GetComponent<Text>().text;
        string weaponP1 = GameObject.Find("Player 1/Select Weapon/Weapon Dropdown").transform.Find("Label").gameObject.GetComponent<Text>().text;

        string carP2 = GameObject.Find("Player 2/Select Car/Car Dropdown").transform.Find("Label").gameObject.GetComponent<Text>().text;
        string weaponP2 = GameObject.Find("Player 2/Select Weapon/Weapon Dropdown").transform.Find("Label").gameObject.GetComponent<Text>().text;

        PlayerPrefs.SetString("carP1", carP1);
        PlayerPrefs.SetString("weaponP1", weaponP1);
        PlayerPrefs.SetString("carP2", carP2);
        PlayerPrefs.SetString("weaponP2", weaponP2);
    }
}
