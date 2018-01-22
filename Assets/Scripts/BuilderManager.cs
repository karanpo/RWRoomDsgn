using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderManager : MonoBehaviour {

	private bool isWall;
	private bool isWindow;
	private bool isDoor;
	private int corners = 0;
	private int stepIndex = 0;
	private string[] steps;
	private Vector3 prevLocation;
	private Vector3 firstCornerLocation;
	private int windowCornersCount = 0;
	private int doorCornersCount = 0;
	private Vector3 prevWindowLocaton;
	private Vector3 prevDoorLocaton;
	private List<Vector3> wallCorners = new List<Vector3>();
	private List<Vector3> windowCorners = new List<Vector3>();
	private List<Vector3> doorCorners = new List<Vector3>();

	public void addWallToList(Vector3 corner){
		wallCorners.Add(corner);
	}

	public List<Vector3> getWallCornerList() {
		return wallCorners;
	}
	public void addWindowToList(Vector3 corner){
		windowCorners.Add(corner);
	}

	public List<Vector3> getWindowCornerList() {
		return windowCorners;
	}
	public void addDoorToList(Vector3 corner){
		doorCorners.Add(corner);
	}

	public List<Vector3> getDoorCornerList() {
		return doorCorners;
	}

	public void setIsWall(bool state){
		Debug.Log("Wall setted");
		isWall = state;
	}
	public bool getIsWall() {
		Debug.Log("Get wall: " + isWall.ToString());
		return isWall;
	}
	public void setIsDoor(bool state){
		isDoor = state;
	}
	public bool getIsDoor() {
		return isDoor;
	}
	public void setIsWindow(bool state){
		Debug.Log("Window setted");
		isWindow = state;
	}

	public bool getIsWindow(){
		Debug.Log("Get window: " + isWindow.ToString());
		return isWindow;
	}

	public void setCorners() {
		corners++;
	}
	public int getCorners() {
		return corners;
	}

	public void setWindowCorners() {
		windowCornersCount++;
	}
	public int getWindowCorners() {
		return windowCornersCount;
	}
	public void setDoorCorners() {
		doorCornersCount++;
	}
	public int getDoorCorners() {
		return doorCornersCount;
	}
	public void setStep(string step) {
		steps[stepIndex] = step;
		stepIndex++;
	}
	public string getStep() {
		return steps[stepIndex-1];
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

	public void setPrevWindowCorner(Vector3 location) {
		prevWindowLocaton = location;
	}
	public Vector3 getPrevWindowCorner() {
		return prevWindowLocaton;
	}
	public void setPrevDoorCorner(Vector3 location) {
		prevDoorLocaton = location;
	}
	public Vector3 getPrevDoorCorner() {
		return prevDoorLocaton;
	}

}
