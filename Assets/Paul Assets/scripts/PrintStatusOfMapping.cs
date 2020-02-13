using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Used, attached to SpatialMapping to print status of activation

public class PrintStatusOfMapping : MonoBehaviour {

	GameObject debugText;

	// Use this for initialization
	void Start () {
		debugText = GameObject.FindWithTag("DebugText");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDisable() {
		debugText.GetComponent<TextMeshProUGUI>().SetText("Map Removed");
		Invoke("ClearText", 3);
		//ClearTextAfterTime(3f);
	}

	void OnEnable() {
		debugText = GameObject.FindWithTag("DebugText");
		debugText.GetComponent<TextMeshProUGUI>().SetText("Mapping Space");
		Invoke("ClearText", 3);
		//ClearTextAfterTime(3f);
	}

	IEnumerator ClearTextAfterTime(float time)
 	{
	    yield return new WaitForSeconds(time);
	 	
	    debugText.GetComponent<TextMeshProUGUI>().SetText("");
 	}

 	void ClearText() {
 		debugText.GetComponent<TextMeshProUGUI>().SetText("");
 	}
}
