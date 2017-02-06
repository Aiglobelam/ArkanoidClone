using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	public static MusicPlayer musicPlayerInstance = null;

	void Awake () {
		Debug.Log("MusicPlayer Awake: ID: " + GetInstanceID());
		if (musicPlayerInstance != null) {
			Destroy (this.gameObject);
			Debug.Log ("MusicPlayer Destroyed: ID: " + GetInstanceID());	
		} else {
			musicPlayerInstance = this;
			//this.gameObject
			// A script is allways connected to a "gameObject"
			// That is "gameObject" is the thing this scipt is attached to.
			// This will make the music play even after a "Scene Switch" in game
			GameObject.DontDestroyOnLoad(this.gameObject);
		}
	}

	// Use this for initialization
	void Start ()
	{
		Debug.Log("MusicPlayer Start: ID: " + GetInstanceID());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
