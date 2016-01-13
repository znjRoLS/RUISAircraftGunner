using UnityEngine;
using System.Collections;

public class flyingPlanes : MonoBehaviour {
	
	public int maxPlaneH;
	public int defaultPlaneH;

	public int minInterval;
	public int maxInterval;

	public GameObject prefab;
	public GameObject gunner;
	public int speed;

	private float R = 300;
	private float R2 = 3;
	private float planeH;

	void Start () {
		planeH = defaultPlaneH;
		//startFire ();
	}
	
	void Update(){
		
	}

	public void startFire()
	{
		
		Invoke ("fire", Random.Range(minInterval,maxInterval));
	}

	public void stopFire()
	{
		CancelInvoke ("fire");
	}
	
	public void fire(){
		int alfa = Random.Range(-60, 60);
		Vector3 startPos=new Vector3(gunner.transform.TransformPoint(Vector3.zero).x+R*Mathf.Sin(Mathf.Deg2Rad*alfa), planeH,
		                        gunner.transform.TransformPoint(Vector3.zero).z+R*Mathf.Cos(Mathf.Deg2Rad*alfa));
		planeH++;
		if (planeH == maxPlaneH) 
			planeH = defaultPlaneH;
		Vector3 endPos=new Vector3(gunner.transform.TransformPoint(Vector3.zero).x+R2*Mathf.Sin(Mathf.Deg2Rad*alfa), planeH,
		                         gunner.transform.TransformPoint(Vector3.zero).z+R2*Mathf.Cos(Mathf.Deg2Rad*alfa));
		GameObject avion = (GameObject) Instantiate(prefab, startPos,transform.rotation);
		avion.transform.LookAt (endPos); //TODO isto malo random
		Vector3 direction = endPos - avion.transform.TransformPoint(Vector3.zero);
		avion.GetComponent<Rigidbody>().AddForceAtPosition(direction*speed, avion.transform.position);

		Destroy (avion, 30f);

		/*GameObject child = avion.transform.GetChild (0).gameObject;
		child.AddComponent<Rigidbody> (); // Add the rigidbody.
		child.GetComponent<Rigidbody>().AddForceAtPosition(direction*speed, avion.transform.position);
		child = avion.transform.GetChild (1).gameObject;
		child.AddComponent<Rigidbody> (); // Add the rigidbody.
		child.GetComponent<Rigidbody>().AddForceAtPosition(direction*speed, avion.transform.position);*/
		//avion.GetComponent<Rigidbody>().AddForceAtPosition(transform.forward * 10, transform.position);
		//avion.GetComponent<Rigidbody>().AddForceAtPosition (new Vector3(50,0, 0), kraj);
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
		Invoke ("fire", Random.Range(minInterval,maxInterval));
	}
	
	
}
