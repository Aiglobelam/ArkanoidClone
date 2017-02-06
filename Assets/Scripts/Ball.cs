using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private bool hasStarted = false;
	//public Paddle paddle;
	private Paddle paddle;
	private Rigidbody2D rb2D;

	// The vector describes the diffrence in position x,y,z between the center of the paddle and
	// the center of the ball...
	private Vector3 paddleToBallVector;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = (this.transform.position - paddle.transform.position);
		// This will find and return a refference to a RigidBody if it exist one on the Game Object
		// that this very Script (Ball.cs) is attached to.
		rb2D = GetComponent<Rigidbody2D> ();
		audioSource = GetComponent<AudioSource>();
	}

	void OnCollisionEnter2D (Collision2D collision2d)
	{
		//Ball does not trigger soun when brick is destroyed
		//Not 100% sure but it is possibly because the brick isnt there anymore...??
		if (this.hasStarted) {
			audioSource.Play();	
			Vector2 tweek = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
			//print(tweek);
			rb2D.velocity += tweek; 
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (!hasStarted) {
			//print("game has not started");
			// The ball should be att the position of the paddle, even when the paddle moves around.
			this.transform.position = paddle.transform.position + paddleToBallVector;

			if (Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1)) {
				hasStarted = true;
				//print("MouseButton 0 pressed, game started");
				rb2D.velocity = new Vector2(2f, 10f);
			}
		}
	}
}
