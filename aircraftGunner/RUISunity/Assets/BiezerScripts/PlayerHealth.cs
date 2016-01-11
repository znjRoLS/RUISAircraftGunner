using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	private float health;
	private float score;
	public float defaultHealth;

	// Use this for initialization
	void Start () {
		health = defaultHealth;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void takeDamage(float damage)
	{
		health -= damage;
		if (health <= 0)
			gameOver ();
	}

	private void gameOver()
	{
		Debug.Log ("game over !!! your score " + score);
	}

	public void getScore(float _score)
	{

		score += _score;
		Debug.Log ("score updated");
	}
}
