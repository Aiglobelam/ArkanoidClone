using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public static int numBreakableBlocksInGame = 0;

	private int maxHits;
	private int timesHit;
	private LevelManager lm;
	public Sprite[] hitSprites;
	private bool isBreakable;

	public AudioClip crackSound;

	public GameObject smoke;

	// Use this for initialization
	void Start ()
	{
		this.lm = GameObject.FindObjectOfType<LevelManager> ();
		timesHit = 0;
		maxHits = hitSprites.Length + 1;
		this.isBreakable = this.tag == "Breakable";
		if (this.isBreakable) {
			numBreakableBlocksInGame++;
			//print("numBreakableBlocksInGame: " + numBreakableBlocksInGame);
		}
	}
	
	// Update is called once per frame
	//void Update () {
	//
	//}

	/*
	void OnTriggerEnter2D (Collider2D collider)
	{
		print("Brick.cs OnTriggerEnter2D");
	}
	*/

	void OnCollisionEnter2D (Collision2D collision)
	{
		// If we somehow failed attaching a cracksound to the brick or if the brick should NOT have a crack sound
		if (crackSound) {
			AudioSource.PlayClipAtPoint (crackSound, transform.position, 0.8f);
		} else {
			//Debug.Log("Brick does not have cracksound attached");
		}

		if (isBreakable) {
			HandleHits();
		}
	}

	void HandleHits ()
	{
		//print ("Brick.cs HandleHits");
		timesHit++;

		if (timesHit >= maxHits) {
			numBreakableBlocksInGame--;
			//print("numBreakableBlocksInGame: " + numBreakableBlocksInGame);
			PuffSmoke();
			Destroy (this.gameObject);
			lm.BrickDestroyedMessage();
		} else {
			//Change sprite to show it has been broken a little bit more
			LoadSprites();
		}
	}

	void PuffSmoke ()
	{
		GameObject smokePuff = Object.Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
		//smokePuff.particleSystem.startColor = GetComponent<SpriteRenderer>().color;
		smokePuff.GetComponent<ParticleSystem>().startColor = this.gameObject.GetComponent<SpriteRenderer>().color;
	}

	void LoadSprites ()
	{
		int spriteIndexToLoad = this.timesHit - 1;
		if (hitSprites [spriteIndexToLoad]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndexToLoad];
		} else {
			Debug.LogError("Brick is missing sprite at index: " + spriteIndexToLoad);
		}
	}
}
