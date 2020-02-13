using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowFire : MonoBehaviour {

	private float sizexNum;
	private float sizezNum;
	private float er;
	private GameObject camera;
	private InitiateRollover ir;
	private BoxCollider bc;

	// Use this for initialization
	void Start () {
		sizexNum = 1.0f;
		sizezNum = 1.0f;
		er = 10.0f;
		camera = GameObject.Find("MixedRealityCamera");
		ir = camera.GetComponent<InitiateRollover>();
		gameObject.transform.Rotate(0.0f, 0.0f, 90.0f);
		bc = gameObject.GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if (ir.growFire){
			if (sizezNum <= 2.0f){
				bc.size = new Vector3(bc.size.x, bc.size.y, bc.size.z+0.00025f);
				sizezNum+=.01f;
			}
			else {
				bc.size = new Vector3(bc.size.x+.00024f, bc.size.y, bc.size.z);
			}
			sizexNum+=.008f;
			er+=.1f;
		}
		var sh = gameObject.GetComponent<ParticleSystem>().shape;
		sh.scale = new Vector3(sizexNum, 0.01f, sizezNum);

		var em = gameObject.GetComponent<ParticleSystem>().emission;
		em.rate = new ParticleSystem.MinMaxCurve(0.0f, er);
	}
}