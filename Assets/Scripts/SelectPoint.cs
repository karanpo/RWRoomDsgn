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
	 private float x = 5;
	 private float y = 5;
     private float offset = 145.0f;
    //private Vector3 cameraPosition = new Vector3(0.0f, 0.0f, 0.0f);
    //private Vector3 cameraRotation = new Vector3(0.0f, 180.0f, 0.0f);


    void Update()
     {
		 if(Input.GetMouseButtonDown(0)){

            //Camera.main.transform.localPosition = cameraPosition;
            //Camera.main.transform.localRotation = Quaternion.Euler(cameraRotation);

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			 if(Physics.Raycast(ray, out hit))
			 {
                firstCorner = builderManager.getFirstCornerLocation();
                prevCorner = builderManager.getPrevLocation();
                prevWindowCorner = builderManager.getPrevWindowCorner();
                prevDoorCorner = builderManager.getPrevDoorCorner();
			 	position = hit.collider.transform.localPosition;

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

                        if (prevWindowCorner.x - position.x != 0) {
                            x =  prevWindowCorner.x - position.x;
                            x = (x < 0) ? x * (-1) : x;
                            y = 5;
                        } else {
                            y =  prevWindowCorner.y - position.y;
                            y = (y < 0) ? y * (-1) : y;
                            x = 5;
                        } 
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

                            if (prevDoorCorner.x - position.x != 0) {
                                x =  prevDoorCorner.x - position.x;
                                x = (x < 0) ? x * (-1) : x;
                                y = 5;
                            } else {
                                y =  prevDoorCorner.y - position.y;
                                y = (y < 0) ? y * (-1) : y;
                                x = 5;
                            } 

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
                        builderManager.setCorners();
                        builderManager.setPrevLocation(position);
                        builderManager.addWallToList(position);
                    }
                    else
                    {
                        if ((prevCorner.x - position.x != 0) && (prevCorner.y - position.y != 0)) {

                        } else {
                            string name = "wall-" + builderManager.getCorners().ToString();
                            GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            wall = GameObject.Find("Cube");
                            wall.GetComponent<Renderer>().material.color = new Color(0, 0, 255);
                            wall.transform.name = name;
                            wall.transform.parent = parent.transform;

                            if (prevCorner.x - position.x != 0) {
                                x =  prevCorner.x - position.x;
                                x = (x < 0) ? x * (-1) : x;
                                y = 5;
                            } else if (prevCorner.y - position.y != 0) {
                                y =  prevCorner.y - position.y;
                                y = (y < 0) ? y * (-1) : y;
                                x = 5;
                            } 

                            wall.transform.localPosition = new Vector3((prevCorner.x + position.x +  offset) / 2, (prevCorner.y + position.y) / 2, position.z);
                            wall.transform.localScale = new Vector3(x, y, 40);
                            print("VECTOR: " + builderManager.getWallCornerList().Count);

                            builderManager.setCorners();
                            builderManager.setPrevLocation(position);
                            builderManager.addWallToList(position);
                        }
                    }

                }
             }
        }
				 
     }		
} 