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
	private Vector3 previousTransformPostion;
	private int almostEqualsNumberOfTimes = 0;

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

	bool isAlmostEqual(float previous, float now){
		//            |                    |                |       
		// --*--------|--------*-----------|---*------------|-------*---------> (x)
		//   |        p-0.1f   |           p   |            p+0.1f  |
		//   n=false           n=true          n=true               n=false
		//
		if (now >= (previous-0.1f) && now <= (previous + 0.1f)) {
			return true;
		} else {
			return false;
		}
	}

	void OnCollisionEnter2D (Collision2D collision2d)
	{
		//Ball does not trigger soun when brick is destroyed
		//Not 100% sure but it is possibly because the brick isnt there anymore...??
		if (this.hasStarted) {
			audioSource.Play();	
			//Vector2 tweek = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f));
			//print(tweek);
			//rb2D.velocity += tweek; 

			if (collision2d.collider.name == "Paddle") {
				print ("Ball hit the Paddle!!!!");
				rb2D.AddForce(new Vector2(0f, 0.5f));

			}

			if(isAlmostEqual(previousTransformPostion.x, this.transform.position.x)){
				print ("Almost equal");
				almostEqualsNumberOfTimes++;
			} else {
				print("Not Equal");
				almostEqualsNumberOfTimes = 0;
			}

			if (almostEqualsNumberOfTimes >= 3) {
				print ("Hmmm we seem stuck in a loop apply random force");
				rb2D.velocity += new Vector2 (Random.Range (1f, 2f), 0);
			}

			previousTransformPostion = this.transform.position;
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
