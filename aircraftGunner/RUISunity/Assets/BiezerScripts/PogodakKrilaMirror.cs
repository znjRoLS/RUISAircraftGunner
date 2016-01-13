using UnityEngine;
using System.Collections;

public class PogodakKrilaMirror : MonoBehaviour {
	public GameObject explosionPrefab;
	public GameObject smokePrefab;
	private bool isDone = false;
	
	public float planeScore;
	
	private float planeWingSpeed = 1000f;
	private float planeSpeed = 10f;
	
	void OnTriggerEnter(Collider other){
		
		if (other.tag != "bullet") {
			
			Debug.Log ("nece dva krila");
			return;
		}

		if (!isDone) {	
			
			GameObject parent = transform.parent.gameObject;
			((Collider)(parent.transform.GetChild (1).gameObject.GetComponent(typeof(Collider)) as Collider)).isTrigger = false;
			((Collider)(parent.transform.GetChild (0).gameObject.GetComponent(typeof(Collider)) as Collider)).isTrigger = false;

			parent.transform.localScale+=new Vector3(-2*parent.transform.localScale.x,0,0);
			GameObject explosion = (GameObject)Instantiate (explosionPrefab, parent.transform.TransformPoint (Vector3.zero), transform.rotation);
			explosion.transform.parent = parent.transform;
			//explosion.transform.localScale *= 10f;
			explosion.GetComponent<ParticleSystem>().startSize *= 2f;
			Destroy (explosion, 2);
			

			//krilo
			GameObject child = parent.transform.GetChild (1).gameObject;

			child.AddComponent<Rigidbody> (); // Add the rigidbody.
			child.GetComponent<Rigidbody> ().mass = 1;
			child.GetComponent<Rigidbody>().useGravity=true;
			Vector3 direction =new Vector3(Random.Range(5,10),-child.transform.TransformPoint(Vector3.zero).y,Random.Range(-2,2));
			child.GetComponent<Rigidbody>().AddForceAtPosition(direction*15, child.transform.position);
			child.transform.Rotate(new Vector3(0, 0, Random.Range(50,70)));
			child.GetComponent<Rigidbody> ().AddTorque (child.transform.up * planeWingSpeed);

			//explosion on krilo
			GameObject explosion2 = (GameObject)Instantiate (explosionPrefab, child.transform.TransformPoint (Vector3.zero), transform.rotation);
			explosion2.transform.parent = child.transform;
			//explosion.transform.localScale *= 10f;
			explosion2.GetComponent<ParticleSystem>().startSize *= 1f;
			Destroy (explosion2, 2);

			//ostatak aviona
			parent.GetComponent<Rigidbody> ().mass = 1;
			parent.GetComponent<Rigidbody>().useGravity=true;
			parent.GetComponent<Rigidbody> ().AddTorque (child.transform.up * planeSpeed);
			
			isDone = true;
			
			GameObject.FindGameObjectWithTag("Scripts").GetComponent<PlayerHealth>().getScore(planeScore);
			
			if (this.GetComponentInParent<BombDropper>() != null)
				this.GetComponentInParent<BombDropper>().CancelInvoke ();
			
			
			GameObject smoke = (GameObject)Instantiate (smokePrefab, parent.transform.position, parent.transform.rotation);
			
			smoke.transform.Rotate(0, 180, 0);
			
			smoke.transform.parent = parent.transform;
			Debug.Log ("heyhey");

		}
	}
	public PogodakKrilaMirror ()
	{
	}
	

}
