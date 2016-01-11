using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using VesnaSanja;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class RightKinectHand : MonoBehaviour {
	
	//public GameObject myo = null;
	//private ThalmicMyo tMyo;

	public GameObject rocket;
	public GameObject rocketLight;
	public GameObject hand;
	public GameObject foreArm;
	public GameObject leftHand;

	public GameObject gunner;
	public GameObject gunnerTop;
	private bool startedUsing = true;
	private float speed = 70f;
	private float minDistance = 0.3f;

	private int numberShoot;
	private int frameRate = 20;
	private int numberOfShoot=5;
	private Vector3 lastPos;
	private Vector3 lastP;
	void Start () {
		//tMyo = myo.GetComponent<ThalmicMyo> ();
		numberShoot = frameRate;
		lastPos = new Vector3 (0, 0, 0);
		lastP = new Vector3 (0, 0, 0);
	}

	void Update ()
	{
		Vector3 handPosition = hand.transform.TransformPoint(Vector3.zero);
		Vector3 foreArmPosition = foreArm.transform.TransformPoint(Vector3.zero);
		//float angle = Vector3.Angle(handPosition - foreArmPosition, Vector3.right);
		Vector3 p = handPosition - foreArmPosition;
		if(p.y < 0) p.y = 0;
		Vector3 pp = (p + lastP+18*lastPos) / 20;
		gunner.transform.LookAt(gunner.transform.TransformPoint(Vector3.zero)+pp);
		lastPos=p;
		lastP=pp;

			numberShoot --;
			if (numberShoot == 0) {
				numberShoot = frameRate;
				if(Vector3.Distance(leftHand.transform.TransformPoint(Vector3.zero),foreArmPosition) < minDistance){
				numberOfShoot--;
				if(numberOfShoot==0)
				{
					numberOfShoot=5;
					shoot(rocketLight,gunner.transform.TransformPoint(Vector3.zero),gunnerTop.transform.TransformPoint(Vector3.zero), speed);
				}
				else
					shoot(rocket,gunner.transform.TransformPoint(Vector3.zero),gunnerTop.transform.TransformPoint(Vector3.zero), speed);

				}
			}


	}
	/*
	void Update () {
	//	Debug.Log (tMyo.pose);
		if (tMyo.pose == Pose.DoubleTap) {
			// fist means you started managing the gun
			startedUsing = true;
			Debug.Log(startedUsing);
		}else{
			if(startedUsing)
			{
				Vector3 handPosition = hand.transform.TransformPoint(Vector3.zero);
				Vector3 foreArmPosition = foreArm.transform.TransformPoint(Vector3.zero);
				//float angle = Vector3.Angle(handPosition - foreArmPosition, Vector3.right);
				Vector3 p=handPosition-foreArmPosition;
				if(p.y<0) p.y=0;
				Vector3 pp=(p+lastP+lastPos)/3;
				gunner.transform.LookAt(gunner.transform.TransformPoint(Vector3.zero)+pp);
				lastPos=p;
				lastP=pp;
				if(startedUsing && tMyo.pose == Pose.Fist){
				// rest - start shooting
					numberShoot --;
					if (numberShoot == 0) {
						numberShoot = frameRate;
					
						shoot(rocket,gunner.transform.TransformPoint(Vector3.zero),gunnerTop.transform.TransformPoint(Vector3.zero), speed);
					}
				}
			}
		}
	}*/
	
	public static void shoot(GameObject rocket, Vector3 pointOne, Vector3 pointTwo, float speed){
		GameObject newRocket = (GameObject)Instantiate (rocket, pointTwo, Quaternion.identity);
		newRocket.GetComponent<Rigidbody>().velocity = (pointTwo - pointOne).normalized * speed;
		newRocket.transform.LookAt (2*pointTwo-pointOne);	
		Destroy (newRocket, 5);
	}
}



