using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintToDebugText : MonoBehaviour {

	//Used for debugging purposes, attached to camera

	GameObject debugText;


	// Use this for initialization
	void Start () {
		debugText = GameObject.FindWithTag("DebugText");
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("FirePrefab(Clone)") != null){
			//debugText.GetComponent<TextMesh>().text = GameObject.Find("FirePrefab(Clone)").transform.position + "\n" + gameObject.transform.position;
		}
		else {
			//debugText.GetComponent<TextMesh>().text = "\n" + gameObject.transform.position;
		}
	}
}
