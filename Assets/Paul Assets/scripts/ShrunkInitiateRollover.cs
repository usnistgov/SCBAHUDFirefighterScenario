using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ShrunkInitiateRollover : MonoBehaviour {

	private GameObject inp_manager;
	private Manager manager;
	private GameObject target;
	private GameObject evacText;
	private GameObject evacPath;
	private GameObject player;
	public bool growFire = false;
	private float dist;
	private GameObject victim;
	public bool rescued;
	private float er;
	private ParticleSystem.EmissionModule em;

	

	//Used, attached to camera to initiate rollover/evacuation sequence

	// Use this for initialization
	void Start () {
		manager = GameObject.FindWithTag("Manager").GetComponent<Manager>();
		inp_manager = GameObject.Find("InputManager");
		// gaze target starts null
		target = inp_manager.GetComponent<GazeManager>().HitObject;
		// assign to variables to deactivate and then reactivate later upon gazing at the fire
		//evacText = GameObject.FindWithTag("EvacText");
		//evacPath = GameObject.FindWithTag("EvacPath");
		player = gameObject;
		victim = GameObject.Find("Cylinder");
		//evacPath.SetActive(false);
		victim.SetActive(false);
		dist = 1;
		rescued = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		// update the target of the user's gaze every frame
		target = inp_manager.GetComponent<GazeManager>().HitObject;
		if (!rescued)
		{
			dist = Vector3.Distance(player.transform.position, victim.transform.position);
		}
		if (dist < 3.5 && !rescued){
			victim.SetActive(true);
			manager.currentState = Manager.states.Rescue;
		}
		
		if (target != null){
			//Debug.Log(target.name);
			// if the user gazes at the fire and has not failed yet
			if (inp_manager.GetComponent<SimpleSinglePointerSelector>().down && dist < 2){
				if (manager.currentState == Manager.states.Rescue){
					// fire begins to rollover
					Rollover();
				}
			}
		}
		if (manager.currentState == Manager.states.Success){
			growFire = false;
		}	
	}

	void Rollover(){
		//Debug.Log("INITIATED ROLLOVER");
		// evacuation time!w
		
		if (GameObject.Find("Cylinder")){
			Destroy(GameObject.Find("Cylinder"));
			rescued = true;
		}
		if (GameObject.Find("Line")){
			GameObject.Find("Line").SetActive(false);
		}
		manager.currentState = Manager.states.Evac;
		//evacPath.SetActive(true);
		growFire = true;

	}
}
