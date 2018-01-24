﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

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
    private float offset = 100.0f + 45f;
     public VRTK_ControllerEvents cEvent;


     void Update()
     {
        Transform trackedObj = VRTK_DeviceFinder.GetControllerRightHand().transform.parent;
        bool rayHit = Physics.Raycast(trackedObj.transform.position, trackedObj.transform.forward, out hit, 100);

        if (rayHit && (hit.collider.gameObject.name.Contains("Trigger")) && (cEvent.triggerPressed))
        {            
            firstCorner = builderManager.getFirstCornerLocation();
            prevCorner = builderManager.getPrevLocation();
            prevWindowCorner = builderManager.getPrevWindowCorner();
            prevDoorCorner = builderManager.getPrevDoorCorner();
            GameObject ob = hit.collider.gameObject;
            position = ob.transform.localPosition;

            if (builderManager.getIsWindow())
            {
                if (builderManager.getWindowCorners() == 0)
                {
                    print("First window corner choosed");
                    builderManager.addWindowToList(position);
                }
                else if (builderManager.getWindowCorners() % 2 == 0)
                {
                    print("Nothing");
                }
                else
                {
                    string name = "window-" + builderManager.getWindowCorners().ToString();
                    GameObject window = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    window = GameObject.Find("Cube");
                    window.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
                    window.transform.name = name;
                    window.transform.parent = parent.transform;
                    window.transform.localPosition = new Vector3((prevWindowCorner.x + position.x + offset) / 2, (prevWindowCorner.y + position.y) / 2, position.z);
                    x = (prevWindowCorner.x - position.x != 0) ? prevWindowCorner.x - position.x : 5;
                    y = (prevWindowCorner.y - position.y != 0) ? prevWindowCorner.y - position.y : 5;
                    window.transform.localScale = new Vector3(x, y, 50);
                    builderManager.addWindowToList(position);
                }
                builderManager.setWindowCorners();
                builderManager.setPrevWindowCorner(position);

            }
            else if (builderManager.getIsDoor())
            {
                if (builderManager.getDoorCorners() == 0)
                {
                    print("First door corner choosed");
                    builderManager.addDoorToList(position);
                }
                else if (builderManager.getDoorCorners() % 2 == 0)
                {
                }
                else
                {
                    string name = "door-" + builderManager.getDoorCorners().ToString();
                    GameObject door = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    door = GameObject.Find("Cube");
                    door.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
                    door.transform.name = name;
                    door.transform.parent = parent.transform;
                    door.transform.localPosition = new Vector3((prevDoorCorner.x + position.x + offset) / 2, (prevDoorCorner.y + position.y) / 2, position.z);
                    x = (prevDoorCorner.x - position.x != 0) ? prevDoorCorner.x - position.x : 5;
                    y = (prevDoorCorner.y - position.y != 0) ? prevDoorCorner.y - position.y : 5;
                    door.transform.localScale = new Vector3(x, y, 50);
                    builderManager.addDoorToList(position);
                }
                builderManager.setDoorCorners();
                builderManager.setPrevDoorCorner(position);

            }
            else if (builderManager.getIsWall())
            {
                if (builderManager.getCorners() == 0)
                {
                    print("First wall corner choosed");
                    builderManager.setFirstCornerLocation(position);
                }
                else
                {
                    string name = "wall-" + builderManager.getCorners().ToString();
                    GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    wall = GameObject.Find("Cube");
                    wall.GetComponent<Renderer>().material.color = new Color(0, 0, 255);
                    wall.transform.name = name;
                    wall.transform.parent = parent.transform;
                    wall.transform.localPosition = new Vector3((prevCorner.x + position.x +  offset) / 2, (prevCorner.y + position.y) / 2, position.z);
                    x = (prevCorner.x - position.x != 0) ? prevCorner.x - position.x : 5;
                    y = (prevCorner.y - position.y != 0) ? prevCorner.y - position.y : 5;
                    wall.transform.localScale = new Vector3(x, y, 40);
                    print("VECTOR: " + builderManager.getWallCornerList().Count);
                }
                builderManager.setCorners();
                builderManager.setPrevLocation(position);
                builderManager.addWallToList(position);
            }
        }
				 
     }		
}
