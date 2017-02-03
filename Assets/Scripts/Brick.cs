using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public static int numBreakableBlocksInGame = 0;

	private int maxHits;
	private int timesHit;
	private LevelManager lm;
	public Sprite[] hitSprites;
	private bool isBreakable;

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
	void Update () {
	
	}

	/*
	void OnTriggerEnter2D (Collider2D collider)
	{
		print("Brick.cs OnTriggerEnter2D");
	
	}
	*/

	void OnCollisionEnter2D (Collision2D collision)
	{

		if (isBreakable) {
			HandleHits();
		}
		//SimulateWin();
	}

	void HandleHits ()
	{
		//print ("Brick.cs HandleHits");
		timesHit++;

		if (timesHit >= maxHits) {
			numBreakableBlocksInGame--;
			//print("numBreakableBlocksInGame: " + numBreakableBlocksInGame);
			Destroy (this.gameObject);
			lm.BrickDestroyedMessage();
		} else {
			//Change sprite to show it has been broken a little bit more
			LoadSprites();
		}
	}

	//TODO REMOVE THIS METHOD WHEN WE CAN IN
	void SimulateWin ()
	{
		lm.LoadNextLevel();
	}

	void LoadSprites ()
	{
		int spriteIndexToLoad = this.timesHit - 1;
		if (hitSprites [spriteIndexToLoad]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndexToLoad];
		}
	}
}
