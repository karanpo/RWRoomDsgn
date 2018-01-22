using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildWalls : MonoBehaviour {

	public BuilderManager builderManager;
	private bool isWall = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startBuilding(){
		isWall = builderManager.getIsWall();
		Debug.Log("Build Walls Trigger: " + isWall.ToString());
	}
}
