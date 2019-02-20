using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject playerCarPrefab = null;

        string car = PlayerPrefs.GetString("carP1");
        string weapon = PlayerPrefs.GetString("weaponP1");
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
        GameObject arrowPlayerCar = Instantiate(playerCarPrefab, new Vector3(0, -6), Quaternion.identity);
        Car2DArrowControllerScript arrowCtrl = arrowPlayerCar.AddComponent<Car2DArrowControllerScript>();
        arrowCtrl.torqueForce = 0.4f;
        arrowCtrl.speedForce = 4f;

        car = PlayerPrefs.GetString("carP2");
        weapon = PlayerPrefs.GetString("weaponP2");
        if (car == "Beetle")
        {
            if (weapon == "Machine Gun")
                playerCarPrefab = (GameObject)Resources.Load("Cars/Car1Bullet", typeof(GameObject));
            else if (weapon == "Raygun")
                playerCarPrefab = (GameObject)Resources.Load("Cars/Car1Laser", typeof(GameObject));
            else if (weapon == "Rocket Launcher")
                playerCarPrefab = (GameObject)Resources.Load("Cars/Car1Rocket", typeof(GameObject));

        }
        else if (car == "Lambo")
        {
            if (weapon == "Machine Gun")
                playerCarPrefab = (GameObject)Resources.Load("Cars/Car2Bullet", typeof(GameObject));
            else if (weapon == "Raygun")
                playerCarPrefab = (GameObject)Resources.Load("Cars/Car2Laser", typeof(GameObject));
            else if (weapon == "Rocket Launcher")
                playerCarPrefab = (GameObject)Resources.Load("Cars/Car2Rocket", typeof(GameObject));
        }
        else if (car == "Truck")
        {
            if (weapon == "Machine Gun")
                playerCarPrefab = (GameObject)Resources.Load("Cars/Car3Bullet", typeof(GameObject));
            else if (weapon == "Raygun")
                playerCarPrefab = (GameObject)Resources.Load("Cars/Car3Laser", typeof(GameObject));
            else if (weapon == "Rocket Launcher")
                playerCarPrefab = (GameObject)Resources.Load("Cars/Car3Rocket", typeof(GameObject));
        }
        GameObject WASDPlayerCar = Instantiate(playerCarPrefab, new Vector3(0, 6), Quaternion.AngleAxis(180, new Vector3(0,0,1)));
        Car2DWASDControllerScript WASDCtrl = WASDPlayerCar.AddComponent<Car2DWASDControllerScript>();
        WASDCtrl.torqueForce = 0.4f;
        WASDCtrl.speedForce = 4f;

        //GameObject.FindWithTag("MainCamera").GetComponent<CameraFollowCarWithinBoundsScript>().target = arrowPlayerCar.transform;
        GameObject.Find("HealthBarP1").GetComponent<HudScript>().target = WASDPlayerCar.transform;
        GameObject.Find("HealthBarP2").GetComponent<HudScript>().target = arrowPlayerCar.transform;

        Debug.Log(WASDPlayerCar.transform.rotation);
    }
}
