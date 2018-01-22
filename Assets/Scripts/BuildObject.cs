using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildObject : MonoBehaviour {

	public BuilderManager builderManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BuildWall()
	{
		Debug.Log("Build Wall Button");
		builderManager.setIsWall(true);
		builderManager.setIsWindow(false);
		builderManager.setIsDoor(false);
	}

	public void BuildWindow()
	{
		Debug.Log("Build Window Button");
		builderManager.setIsWindow(true);
		builderManager.setIsWall(false);
		builderManager.setIsDoor(false);
	}
	public void BuildDoor()
	{
		Debug.Log("Build Door Button");
		builderManager.setIsDoor(true);
		builderManager.setIsWall(false);
		builderManager.setIsWindow(false);
	}

	public void Reset()
	{
		Debug.Log("Reset Button");
		builderManager.setIsDoor(false);
		builderManager.setIsWall(false);
		builderManager.setIsWindow(false);
		Application.LoadLevel(Application.loadedLevelName);

	}
}
