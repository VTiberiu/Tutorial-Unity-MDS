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
        GameObject arrowPlayerCar = Instantiate(playerCarPrefab);
        Car2DArrowControllerScript arrowCtrl = arrowPlayerCar.AddComponent<Car2DArrowControllerScript>();
        arrowCtrl.torqueForce = 0.4f;
        arrowCtrl.speedForce = 4f;

        GameObject WASDPlayerCar = Instantiate(playerCarPrefab, new Vector3(0, 2), Quaternion.identity);
        Car2DWASDControllerScript WASDCtrl = WASDPlayerCar.AddComponent<Car2DWASDControllerScript>();
        WASDCtrl.torqueForce = 0.4f;
        WASDCtrl.speedForce = 4f;

        GameObject.FindWithTag("HealthBar").GetComponent<HudScript>().target = arrowPlayerCar.transform;
    }
}
