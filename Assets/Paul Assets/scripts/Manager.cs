using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour {

	public enum states {Start, Fail, Fail2, Success, Rescue, Evac};
	public states currentState;
	private TextMeshProUGUI statusText;

	// Use this for initialization
	void Start () {
		currentState = states.Start;
		statusText = GameObject.FindWithTag("StatusText").GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentState == states.Start){
			statusText.SetText("VICTIM COLLAPSED NEAR FIRE!\nUSE THE TEMP GAUGE AND PATH TO FIND THE VICTIM!");
		}
		else if (currentState == states.Fail){
			statusText.SetText("YOU FAILED TO RESCUE THE VICTIM AND ESCAPE :(");
			if (GameObject.FindWithTag("WaypointArrow")){
				GameObject.FindWithTag("WaypointArrow").SetActive(false);
			}
			if (GameObject.FindWithTag("Cautions")){
				GameObject.FindWithTag("Cautions").SetActive(false);
			}
		}
		else if (currentState == states.Fail2){
			statusText.SetText("YOU TOUCHED THE FIRE AND FAILED :(");
			if (GameObject.FindWithTag("WaypointArrow")){
				GameObject.FindWithTag("WaypointArrow").SetActive(false);
			}
			if (GameObject.FindWithTag("Cautions")){
				GameObject.FindWithTag("Cautions").SetActive(false);
			}
		}
		else if (currentState == states.Success){
			statusText.SetText("YOU AND THE VICTIM ESCAPED THE FIRE!\nSUCCESS :)");
			if (GameObject.FindWithTag("WaypointArrow")){
				GameObject.FindWithTag("WaypointArrow").SetActive(false);
			}
			if (GameObject.FindWithTag("Cautions")){
				GameObject.FindWithTag("Cautions").SetActive(false);
			}
		}
		else if (currentState == states.Rescue){
			statusText.SetText("HIGH TEMPERATURES!\nRESCUE THE VICTIM!");
		}
		else if (currentState == states.Evac){
			statusText.SetText("ALERT!!\nFIRE INITIATED ROLLOVER!\nEVACUATE TO SAFETY!");
		}
	}
}
