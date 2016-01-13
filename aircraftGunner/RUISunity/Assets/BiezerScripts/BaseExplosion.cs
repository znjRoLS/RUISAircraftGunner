using UnityEngine;
using System.Collections;

public class BaseExplosion : MonoBehaviour {

	public GameObject explosionPrefab;
	public float bombDamage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){
		//Debug.Log("blaaa");

		if (other.tag != "bomb")
			return;

		GameObject explosion = (GameObject)Instantiate (explosionPrefab, other.transform.position, transform.rotation);
		explosion.transform.localScale *= 3f;
			Destroy (explosion, 2);
			
		GameObject.FindGameObjectWithTag("Scripts").GetComponent<PlayerHealth> ().takeDamage (bombDamage);
	}
}
