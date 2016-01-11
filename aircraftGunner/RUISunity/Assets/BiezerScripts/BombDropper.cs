using UnityEngine;
using System.Collections;

public class BombDropper : MonoBehaviour {

	public float minInterval;
	public float maxInterval;
	public float force;
	public GameObject bomb;

	// Use this for initialization
	void Start () {
		Invoke ("drop", Random.Range(minInterval,maxInterval));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void drop(){
		GameObject bombObject = (GameObject) Instantiate(bomb, this.transform.position + Vector3.down * 5f - this.transform.forward * 5f, transform.rotation);

		bombObject.GetComponentInChildren<Rigidbody> ().AddForce (this.transform.forward * force);

		Destroy (bombObject, 10f);
	}

}
