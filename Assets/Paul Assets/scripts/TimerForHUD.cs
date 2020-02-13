using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Used, attached to AirTank to manage fill amount of child image based on timer

public class TimerForHUD : MonoBehaviour {

	//component attribute for how filled the radial image of the gauge is
	Image fillImg;
	// timer in seconds for air supply
	public float timeAmt = 300;
	// time
	float time;
	// text alert for failure
	private TextMeshProUGUI text;
	private Manager manager;

	// Use this for initialization
	void Start () {
		fillImg = this.GetComponent<Image>();
		time = timeAmt;
		// we assign it to a variable before setting it to inactive so we can activate it upon failure
		manager = GameObject.FindWithTag("Manager").GetComponent<Manager>();
		text = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update () {
		// timer should stop running once user succeeds
		if (manager.currentState != Manager.states.Success && manager.currentState != Manager.states.Fail && manager.currentState != Manager.states.Fail2){
			// assuming there's still time, execute
			if (time > 0)
			{
				// drain image based on elapsed time
				time -= Time.deltaTime;
				fillImg.fillAmount = time / timeAmt; 
				text.SetText("Air Tank\n" + Mathf.RoundToInt(time/timeAmt * 100) + "%");
			}
			// if time runs out
			else {
				manager.currentState = Manager.states.Fail;
				if (GameObject.Find("FirePrefab(Clone)")){
					GameObject.Find("FirePrefab(Clone)").SetActive(false);
				}
				
			}

			if (System.Math.Round(time/timeAmt, 2) == .75){
				GameObject.FindWithTag("DebugText").GetComponent<TextMeshProUGUI>().SetText("WARNING! Airtank is at 75%, find and plan your exit!");
			}
			if (System.Math.Round(time/timeAmt, 2) == .5){
				GameObject.FindWithTag("DebugText").GetComponent<TextMeshProUGUI>().SetText("WARNING! Airtank is at 50%, start exiting!");
			}
			if (System.Math.Round(time/timeAmt, 2) == .25){
				GameObject.FindWithTag("DebugText").GetComponent<TextMeshProUGUI>().SetText("WARNING! Airtank is at 25%, you better be almost out!");
			}
			if (System.Math.Round(time/timeAmt, 2) == .70 || System.Math.Round(time/timeAmt, 2) == .45 || System.Math.Round(time/timeAmt, 2) == .20){
				ClearText();
			}
			else {
				//Debug.Log(System.Math.Round(time/timeAmt, 2));
			}
		}
	}

	void ClearText()
 	{
	    GameObject.FindWithTag("DebugText").GetComponent<TextMeshProUGUI>().SetText("");
 	}
}
