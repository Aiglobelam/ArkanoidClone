using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	private float relativeMousePositionInBlocks = 0;
	// Update is called once per frame
	void Update ()
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
			new Vector3 (Mathf.Clamp (relativeMousePositionInBlocks, 0.5f, 15.5f), 
			this.transform.position.y, 
			this.transform.position.z);
		

		
	}
}
