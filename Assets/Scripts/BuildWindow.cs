using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildWindow : MonoBehaviour {

	public BuilderManager builderManager;
	private bool isWindow = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startBuilding(){
		isWindow = builderManager.getIsWindow();
		Debug.Log("Build Window Trigger: " + isWindow.ToString());
	}
}
