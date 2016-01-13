using UnityEngine;
using System.Collections;

public class OnCollisionExplosion : MonoBehaviour {

	public GameObject explosionPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		GameObject other = collision.gameObject;

		if (other.tag != "bomb")
			return;

		Debug.Log ("collision !!!!");

		GameObject explosion = (GameObject)Instantiate (explosionPrefab, other.transform.position, transform.rotation);
		//explosion.transform.localScale *= 2f;
		explosion.GetComponent<ParticleSystem> ().startSize *= 2.5f;
		Destroy (explosion, 2);
		Destroy (other);
		Destroy (this);
	}
}
