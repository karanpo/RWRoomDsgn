using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

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
        builderManager.setClean(true);
        
		Application.LoadLevel(Application.loadedLevelName);
	}

    public void Close()
    {
        Application.Quit();
    }

    public void Save()
    {
        Debug.Log("Save Button");
        builderManager.setIsDoor(false);
        builderManager.setIsWall(false);
        builderManager.setIsWindow(false);
        List<Vector3> walls = builderManager.getWallCornerList();
        int length = walls.Count;
        List<Vector3> doors = builderManager.getDoorCornerList();
        int lengthDoor = doors.Count;

        if ((builderManager.getFirstCornerLocation() == walls[length - 1]) && (lengthDoor > 0))
        {
            Application.LoadLevel("RoomDesigner");            
        }
    }
}

