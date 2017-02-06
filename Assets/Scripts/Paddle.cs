using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	private Ball ball;
	private float maxLeft = 0.5f; //World units
	private float maxRight = 15.5f;//World units
	private float relativeMousePositionInBlocks = 0;

	// Use this for initialization
	void Start () {
		this.ball = GameObject.FindObjectOfType<Ball>();
		//print(this.ball);
	}

	// Update is called once per frame
	void Update ()
	{
		if (this.autoPlay == false) {
			MoveWithMouse ();
		} else {
			AutoPlay ();
		}
	}

	void AutoPlay ()
	{
		// 600
		//(y)
		// |
		// |
		// |
		// |
		// |
		// |
		// +-------------------------(x) 800
		//Move the paddle to the Y posiont of the ball
		// x => ???
		// y => Use the current position in Y for the paddle
		// z => we dont care we are in 2D not 3D
		Vector3 newPaddlePostion = new Vector3(0.5f, this.transform.position.y, 0f);
		Vector3 ballTransformPositon = this.ball.transform.position;
		newPaddlePostion.x = Mathf.Clamp(ballTransformPositon.x, this.maxLeft, this.maxRight);
		this.transform.position = newPaddlePostion;
	}

	void MoveWithMouse ()
	{
		// x => 0-800
		// Screen.width => current screen width
		// x / Screen.width => 0 - 1
		// Our world are in UNITS, 16 Units as a matter of fact
		// If we multiply by 16 we will get the x value in world units
		// Where the mouse is situated.
		relativeMousePositionInBlocks = Input.mousePosition.x / Screen.width * 16;	
		//print(relativeMousePositionInBlocks);

		//Vector3 v3 = new Vector3(8f, this.transform.position.y, this.transform.position.z);
		//this.transform.position = v3;
		this.transform.position = 
			new Vector3 (Mathf.Clamp (relativeMousePositionInBlocks, this.maxLeft, this.maxRight), 
			this.transform.position.y, 
			this.transform.position.z);
	}
}
