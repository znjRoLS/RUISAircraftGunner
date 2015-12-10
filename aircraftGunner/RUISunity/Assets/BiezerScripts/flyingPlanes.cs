using UnityEngine;
using System.Collections;

public class flyingPlanes : MonoBehaviour {

	public GameObject prefab;

	void Start () {
		Invoke ("fire", Random.Range(1, 5));
	}
	
	void Update(){
		
	}
	
	public void fire(){
		Vector3 poc = new Vector3 (0, 20, 300);	//TODO Random tacka treba da bude
		GameObject avion = (GameObject) Instantiate(prefab, poc,transform.rotation);
		avion.transform.LookAt (new Vector3 (0, avion.transform.position.y, 0)); //TODO isto malo random
		avion.GetComponent<Rigidbody>().AddForce (transform.forward * -50, ForceMode.VelocityChange);
		/*
		float g = -Physics.gravity.y;
		
		Vector3 start = transform.position - new Vector3 (0, transform.position.y, 0);
		//Debug.Log (start);
		Vector3 end = target.position - new Vector3 (0,target.position.y, 0);
		//Debug.Log (end);
		//end += new Vector3 ((float)Random.Range (-150, 150) / 10, (float)Random.Range (0, 50) / 100, 0);
		float distance = Vector3.Distance (start, end);
		//distance += Random.Range (50, 100) / 100;
		//Debug.Log (distance);
		float radians = angle * 2 * Mathf.PI / 360;
		float speed = Mathf.Sqrt (distance * g / Mathf.Sin (2 * radians));
		
		
		GameObject projectile = (GameObject)Instantiate (prefabs[Random.Range(0, prefabs.Length)], transform.position, Quaternion.identity);
		projectile.transform.GetChild(0).GetComponent<Rigidbody> ().AddForce (transform.forward * speed, ForceMode.VelocityChange);
		Destroy (projectile, 10);*/
		Debug.Log ("DRTGRT");
		Invoke ("fire", Random.Range(2,8));
	}
	
	
}
