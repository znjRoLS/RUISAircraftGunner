using UnityEngine;
using System.Collections;

public class PogodakKrilaMirror : MonoBehaviour {
	public GameObject explosionPrefab;
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

			parent.transform.localScale+=new Vector3(-2*parent.transform.localScale.x,0,0);
			GameObject explosion = (GameObject)Instantiate (explosionPrefab, parent.transform.TransformPoint (Vector3.zero), transform.rotation);
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
			
			
			//ostatak aviona
			parent.GetComponent<Rigidbody> ().mass = 1;
			parent.GetComponent<Rigidbody>().useGravity=true;
			parent.GetComponent<Rigidbody> ().AddTorque (child.transform.up * planeSpeed);
			
			isDone = true;
			
			GameObject.FindGameObjectWithTag("Scripts").GetComponent<PlayerHealth>().getScore(planeScore);
		}
	}
	public PogodakKrilaMirror ()
	{
	}
	

}
