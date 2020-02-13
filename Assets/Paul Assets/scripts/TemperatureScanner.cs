using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Used, attached to Temperature to increment fill amount of child image based on distance

public class TemperatureScanner : MonoBehaviour {

	private GameObject player;
	private GameObject fire;
	public float temp = 0;
	// position of the player/camera
	private Vector3 pos1;
	// position of the fire
	private Vector3 pos2;
	private Vector3 pos3;
	// distance between positions
	private float dist;
	private GameObject fireText;
	// variable for image fill attribute of temperature gauge component
	Image fillImg;
	private bool fireInstantiated = false;
	private float dist2;
	private TextMeshProUGUI text;

	// Use this for initialization
	void Start () {
		//remove floor quad
		Destroy(GameObject.Find("FloorQuad(Clone)"));

		player = GameObject.Find("MixedRealityCamera");
		// assign to variable to deactivate and activate later upon distance requirements
		fireText = GameObject.FindWithTag("FireText");
		fireText.SetActive(false);
		// get camera position (variable)
		pos1 = player.transform.position;
		// get fire position (static)
		pos2 = new Vector3(4.0f, 0.1f, 12.0f);
		pos3 = new Vector3(22.93f, -3.05f, 12.5f);
		dist = 1;
		dist2 = 1;
		fillImg = this.GetComponent<Image>();
		text = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindWithTag("FailureText2") == null)
		{
			// update player/camera position every frame
			pos1 = player.transform.position;
			// update distance between player/camera and fire every frame
			dist = Vector3.Distance(pos1, pos2);
			//Debug.Log(dist2 + " meters");
			//Debug.Log(temp + " degrees");
			
			if (!fireInstantiated)
			{
				dist2 = Vector3.Distance(pos1, pos3);
				
			}
			else 
			{
				Vector3 bxSize = GameObject.Find("FirePrefab(Clone)").transform.GetChild(0).transform.GetChild(0).GetComponent<BoxCollider>().size;
				//Debug.Log(bxSize);
				dist2 = Vector3.Distance(pos1, new Vector3(pos3.x, pos3.y, pos3.z - bxSize.z/2));
			}
			if (player.GetComponent<InitiateRollover>().growFire){
				pos3 = new Vector3(pos3.x - .01f, pos3.y, pos3.z);
			}

			// temperature is some number - distance so that it gets hotter as the user gets closer
			temp = 800 - dist2*dist2;

			// if the user is close enough to the fire and hasn't failed yet
			if (dist2 < 20 && GameObject.FindWithTag("FailureText") == null && GameObject.FindWithTag("FailureText2") == null){
				// the fire appears!
				if (!fireInstantiated){
					Instantiate(GameObject.Find("FirePrefab"), pos3, Quaternion.identity);
					fireInstantiated = true;
					GameObject.FindWithTag("InstructionsText").SetActive(false);
					fireText.SetActive(true);
				}
			}
			// as long as the temperature does not reach 300 (distance is 0, or you're in the fire)
			if (temp < 1000 && temp > 100)
			{
				// temperature gauge fill amount update
				fillImg.fillAmount = temp / 1000; 
				text.SetText("Temperature\n" + Mathf.RoundToInt(temp) + "°F");
				
			}
		}
		
	}
}