using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointArrowScript : MonoBehaviour {

	public Transform _currentWaypoint = null;

	// Use this for initialization
	void Start () {
		
	}
	
	public void SetCurrentWaypoint(Transform Waypoint)
	{
	   _currentWaypoint = Waypoint;
	}


	void Update()
	{
	   if (_currentWaypoint != null)
	   {
	   	   // Vector3 newDir = Vector3.RotateTowards(transform.forward, _currentWaypoint.position - transform.position, Time.deltaTime, 0.0f);
	       // transform.LookAt(new Vector3(_currentWaypoint.position.x, _currentWaypoint.position.y, _currentWaypoint.position.x));
	       transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation((_currentWaypoint.position - GameObject.FindWithTag("MainCamera").transform.position).normalized), Time.deltaTime * 5.0f);
	   }  
	   if (_currentWaypoint.name == "Cylinder" && GameObject.FindWithTag("MainCamera").GetComponent<ShrunkInitiateRollover>().rescued)
	   {
	   		SetCurrentWaypoint(GameObject.FindWithTag("Waypoint").transform);
	   		GameObject.FindWithTag("Waypoint").GetComponent<WaypointStore>().nextWaypoint = GameObject.FindWithTag("EvacPoint").transform;
	   }	   
	}
}
