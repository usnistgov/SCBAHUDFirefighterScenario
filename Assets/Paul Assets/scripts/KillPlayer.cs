using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used, attached to camera to kill the player upon contact with Fire

public class KillPlayer : MonoBehaviour {

	private GameObject target;

	private GameObject player;

	private Manager manager;

	// Use this for initialization
	void Start () {
		// assign to variables to deactivate and then reactivate later upon gazing at the fire
		manager = GameObject.FindWithTag("Manager").GetComponent<Manager>();
		player = GameObject.Find("MixedRealityCamera");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col)
    {
    	//Debug.Log(col.gameObject.name);
    	// if fire collides with camera/player, failure sequence
        if(col.gameObject.name == "Fire Particle System" && manager.currentState != Manager.states.Success && manager.currentState != Manager.states.Fail)
        {
            manager.currentState = Manager.states.Fail2;
			if (GameObject.Find("FirePrefab(Clone)")){
				GameObject.Find("FirePrefab(Clone)").SetActive(false);
			}
        }
    }
}
