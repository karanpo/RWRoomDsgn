using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderManager : MonoBehaviour {

	private int corners;
	private int stepIndex = 0;
	private string[] steps;
	private Vector3 prevLocation;
	private Vector3 firstCornerLocation;
	private GameObject gameObject;
	private string objectName;

	public void setCorners(int corner) {
		corners++;
	}
	public int getCorners() {
		return corners;
	}
	public void setStep(string step) {
		steps[stepIndex] = step;
		stepIndex++;
	}
	public string getStep() {
		return steps[stepIndex-1];
	}
	public void setObjectName(string name) {
		objectName = name;
	}
	public string getObjectName() {
		return objectName;
	}

	public void setGameObject(GameObject gObject) {
		gameObject = gObject;
	}

	public GameObject getGameObject() {
		return gameObject;
	}

	public void setFirstCornerLocation(Vector3 location) {
		firstCornerLocation = location;
	}

	public Vector3 getFirstCornerLocation() {
		return firstCornerLocation;
	}

	public void setPrevLocation(Vector3 location) {
		prevLocation = location;
	}

	public Vector3 getPrevLocation() {
		return prevLocation;
	}

}
