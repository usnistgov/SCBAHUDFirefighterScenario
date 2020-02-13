using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

//Used, attached to EvacPoint to initiate success

public class InitiateSuccess : MonoBehaviour {

	// input manager to get gazemanager component
	private GameObject inp_manager;

	private Manager manager;

	// variable to store the object we are currently targeting with our gaze
	private GameObject target;
	// game object that contains path of arrows to evacuation point
	private GameObject evacPath;
	// camera
	private GameObject player;


	// Use this for initialization
	void Start () {
		manager = GameObject.FindWithTag("Manager").GetComponent<Manager>();
		// should start as null
		inp_manager = GameObject.Find("InputManager");
		target = inp_manager.GetComponent<GazeManager>().HitObject;
		// assigning to variable to deactivate and activate later upon success
		player = GameObject.Find("MixedRealityCamera");
	}
	
	// Update is called once per frame
	void Update () {
		// re-assign what the user is gazing at every frame
		target = inp_manager.GetComponent<GazeManager>().HitObject;
		if (target != null){
			//Debug.Log(target);
		}
		// if the target is the evacuation point and the user has activated the evacuation path and the user has not yet succeeeded and the user has not yet failed
		if (target == GameObject.Find("EvacPoint") && manager.currentState == Manager.states.Evac){
			// launch success sequence
			Success();
		}
	}

	void Success(){
		//Debug.Log("INITIATED SUCCESS");
		// deactivate evacuation text
		manager.currentState = Manager.states.Success;
		if (GameObject.Find("FirePrefab(Clone)")){
			GameObject.Find("FirePrefab(Clone)").SetActive(false);
		}
	}
}
