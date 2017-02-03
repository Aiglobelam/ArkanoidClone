using UnityEngine;
using System.Collections;

public class LooseCollider : MonoBehaviour {

	private LevelManager lm;

	// Use this for initialization
	void Start () {
		lm = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		//print("LooseCollider.cs OnTriggerEnter2D load new level");
		lm.LoadLevel("Loose Screen");
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		//print("LooseCollider.cs OnCollisionEnter2D");
	}


}
