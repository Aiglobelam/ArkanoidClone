using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	//void Start () {
	//	
	//}
	
	// Update is called once per frame
	//void Update () {
	//
	//}

	public void LoadLevel(string name){
		//Debug.Log("LoadLevel name: " + name);
		//Obsolete use SceneManager.LoadScene instead...
		Application.LoadLevel(name);
	}

	public void QuitRequest (){
		Debug.Log("QuitRequest");
		Application.Quit();
	}

	public void DoNothing (){
		Debug.Log("Do nothing absolutely nothing!");
	}

	public void LoadNextLevel ()
	{
		//Load next level in "sequence" set in "Build Setting" => "Scenes In Build"
		Application.LoadLevel(Application.loadedLevel +1);
	}

	public void BrickDestroyedMessage ()
	{
		bool isLastBrickDestroyed = Brick.numBreakableBlocksInGame <= 0;
		if(isLastBrickDestroyed){
			//load next level
			LoadNextLevel();
		}
	}
}
