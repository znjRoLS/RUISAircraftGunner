using UnityEngine;
using System.Collections;

public class UIHeadTracker : MonoBehaviour {

	private GameObject head;
	private GameObject ui;

	// Use this for initialization
	void Start () {
		Debug.Log ("nesto");
		head = GameObject.FindGameObjectWithTag ("eyesight");
		ui = GameObject.FindGameObjectWithTag ("ui");

		Debug.Log ("mlatka" + head);
		Debug.Log ("mlatka" + ui);
	}
	
	// Update is called once per frame
	void Update () {
	
		Transform uiTrans = ui.transform;
		Transform headTrans = head.transform;

		uiTrans.position = headTrans.position + headTrans.forward * 5f;
		uiTrans.rotation = headTrans.rotation;

	}
}
