using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject playerCarPrefab = null;

        string car = PlayerPrefs.GetString("car");
        string weapon = PlayerPrefs.GetString("weapon");
        if(car == "Beetle") {
            if (weapon == "Machine Gun")
                playerCarPrefab = (GameObject)Resources.Load("Cars/Car1Bullet", typeof(GameObject));
            else if (weapon == "Raygun")
                playerCarPrefab = (GameObject)Resources.Load("Cars/Car1Laser", typeof(GameObject));
            else if (weapon == "Rocket Launcher")
                playerCarPrefab = (GameObject)Resources.Load("Cars/Car1Rocket", typeof(GameObject));

        }
        else if (car == "Lambo") {
            if (weapon == "Machine Gun")
                playerCarPrefab = (GameObject)Resources.Load("Cars/Car2Bullet", typeof(GameObject));
            else if (weapon == "Raygun")
                playerCarPrefab = (GameObject)Resources.Load("Cars/Car2Laser", typeof(GameObject));
            else if (weapon == "Rocket Launcher")
                playerCarPrefab = (GameObject)Resources.Load("Cars/Car2Rocket", typeof(GameObject));
        }
        else if (car == "Truck") {
            if (weapon == "Machine Gun")
                playerCarPrefab = (GameObject)Resources.Load("Cars/Car3Bullet", typeof(GameObject));
            else if (weapon == "Raygun")
                playerCarPrefab = (GameObject)Resources.Load("Cars/Car3Laser", typeof(GameObject));
            else if (weapon == "Rocket Launcher")
                playerCarPrefab = (GameObject)Resources.Load("Cars/Car3Rocket", typeof(GameObject));
        }
        GameObject playerCar = GameObject.Instantiate(playerCarPrefab);

        GameObject.FindWithTag("MainCamera").GetComponent<CameraFollowCarWithinBoundsScript>().target = playerCar.transform;
        GameObject.FindWithTag("HealthBar").GetComponent<HudScript>().target = playerCar.transform;
    }
}
