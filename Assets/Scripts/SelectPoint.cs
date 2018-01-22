using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPoint : MonoBehaviour {

	 Ray ray;
     RaycastHit hit;

	 public BuilderManager builderManager;
	 private Vector3 position;
	 private Vector3 firstCorner;
	 private Vector3 prevCorner;
	 private Vector3 prevWindowCorner;
	 private Vector3 prevDoorCorner;
	 public GameObject parent;
	 private float x;
	 private float y;

      
     void Update()
     {
		 if(Input.GetMouseButtonDown(0)){
			 ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			 if(Physics.Raycast(ray, out hit))
			 {
				firstCorner = builderManager.getFirstCornerLocation();
				prevCorner = builderManager.getPrevLocation();
				prevWindowCorner = builderManager.getPrevWindowCorner();
				prevDoorCorner = builderManager.getPrevDoorCorner();
			 	position = hit.collider.transform.localPosition;

				if(builderManager.getIsWindow()){
					if(builderManager.getWindowCorners() == 0)
					{
						print ( "First window corner choosed");
						builderManager.addWindowToList(position);
					} else if(builderManager.getWindowCorners() % 2 == 0){
						print ( "Nothing");
					} else {
						string name = "window-" + builderManager.getWindowCorners().ToString();
						GameObject window = GameObject.CreatePrimitive(PrimitiveType.Cube);
						window = GameObject.Find("Cube");
						window.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
						window.transform.name = name;
						window.transform.parent = parent.transform;
						window.transform.localPosition = new Vector3( (prevWindowCorner.x + position.x)/2, (prevWindowCorner.y + position.y)/2, position.z);
						x = (prevWindowCorner.x - position.x != 0) ? prevWindowCorner.x - position.x : 10;
						y = (prevWindowCorner.y - position.y != 0) ? prevWindowCorner.y - position.y : 10;
						window.transform.localScale = new Vector3(x, y, 15);
						builderManager.addWindowToList(position);
					}
					builderManager.setWindowCorners();
					builderManager.setPrevWindowCorner(position);

				} else if(builderManager.getIsDoor()){
					if(builderManager.getDoorCorners() == 0)
					{
						print ( "First door corner choosed");
						builderManager.addDoorToList(position);
					} else if(builderManager.getDoorCorners() % 2 == 0){
					} else {
						string name = "window-" + builderManager.getDoorCorners().ToString();
						GameObject door = GameObject.CreatePrimitive(PrimitiveType.Cube);
						door = GameObject.Find("Cube");
						door.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
						door.transform.name = name;
						door.transform.parent = parent.transform;
						door.transform.localPosition = new Vector3( (prevDoorCorner.x + position.x)/2, (prevDoorCorner.y + position.y)/2, position.z);
						x = (prevDoorCorner.x - position.x != 0) ? prevDoorCorner.x - position.x : 10;
						y = (prevDoorCorner.y - position.y != 0) ? prevDoorCorner.y - position.y : 10;
						door.transform.localScale = new Vector3(x, y, 15);
						builderManager.addDoorToList(position);
					}
					builderManager.setDoorCorners();
					builderManager.setPrevDoorCorner(position);

				} else if(builderManager.getIsWall()){
					if(builderManager.getCorners() == 0)
					{
						print ( "First wall corner choosed");
						builderManager.setFirstCornerLocation(position);
					} else {
						string name = "wall-" + builderManager.getCorners().ToString();
						GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
						wall = GameObject.Find("Cube");
						wall.GetComponent<Renderer>().material.color = new Color(0, 0, 255);
						wall.transform.name = name;
						wall.transform.parent = parent.transform;
						wall.transform.localPosition = new Vector3( (prevCorner.x + position.x)/2, (prevCorner.y + position.y)/2, position.z);
						x = (prevCorner.x - position.x != 0) ? prevCorner.x - position.x : 10;
						y = (prevCorner.y - position.y != 0) ? prevCorner.y - position.y : 10;
						wall.transform.localScale = new Vector3(x, y, 7);
						print ("VECTOR: " + builderManager.getWallCornerList().Count);
					}
					builderManager.setCorners();
					builderManager.setPrevLocation(position);
					builderManager.addWallToList(position);
				}

			 }
		 }
     }		
}
