using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointStore : MonoBehaviour {

	public Transform nextWaypoint = null; // Can drag the next waypoint from the scene editor.

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(GameObject.FindWithTag("MainCamera").transform.position);
		if (GameObject.FindWithTag("MainCamera").transform.position.z < 4.5f && GameObject.FindWithTag("MainCamera").transform.position.z > 1.5f){
			if (GameObject.FindWithTag("MainCamera").transform.position.x > -1.5f && GameObject.FindWithTag("MainCamera").transform.position.x < 1.5f){
				if (GameObject.FindWithTag("WaypointArrow")){
					GameObject.FindWithTag("WaypointArrow").GetComponent<WaypointArrowScript>().SetCurrentWaypoint(nextWaypoint);
				}
				
			}
		}
	}

	void OnCollisionEnter (Collision TheCollider)
	{

	}
}
