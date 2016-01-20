using UnityEngine;
using System.Collections;

public class PropelerRotation : MonoBehaviour {

	public float propelerSpeed;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float passedTime = Time.deltaTime;

		this.transform.Rotate (Vector3.forward * propelerSpeed * passedTime);
		//this.transform.Rotate ((Vector3.forward * propelerSpeed * passedTime));// + (Vector3.up * 0.1f * propelerSpeed*passedTime));

	}
}
