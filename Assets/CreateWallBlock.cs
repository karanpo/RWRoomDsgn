using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWallBlock : MonoBehaviour {

	public Transform Spawnpoint;
	ObjectsManager objectsManager = new ObjectsManager();
	BuilderManager builderManager = new BuilderManager();
	GameObject Prefab;


	GameObject GetObject(string Object){
		switch (Object)	{
			case "Door":
				Prefab = objectsManager.Prefabs[0];
                Debug.Log(Prefab.name);
                break;
			case "Wall":
				Prefab = objectsManager.Prefabs[1];
                Debug.Log(Prefab.name);
                break;
			case "Window":
				Prefab = objectsManager.Prefabs[2];
                Debug.Log(Prefab.name);
                break;
			default:
				Prefab = null;
				break;
		}
		return Prefab;
	}

	void OnTriggerEnter () {
        //Prefab = GetObject(builderManager.getObjectName());
        //builderManager.setGameObject(Prefab);

        //Debug.Log(Prefab.name);

        //if (Prefab != null && builderManager.getObjectName() == "Wall") {
		//	if (builderManager.getCorners() == 0) {
        //        Debug.Log("IF");
                builderManager.setFirstCornerLocation(Spawnpoint.transform.localPosition);
				builderManager.setPrevLocation(Spawnpoint.transform.localPosition);
                Instantiate(Resources.Load("Wall"), Spawnpoint.position, Spawnpoint.rotation);
                Debug.Log("LOADED");
        //       Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);
        //
        //	} else {
        //        Debug.Log("ELSE");
        //        Vector3 prevPos = builderManager.getPrevLocation();
        //		Vector3 actPos = Spawnpoint.transform.localPosition;
        //		Vector3 difference = actPos - prevPos;

        //		if ((difference.x == 0 && difference.y != 0) || (difference.x != 0 && difference.y == 0)) {
        //            Debug.Log("ELSE IF");
        //            Vector3 temp = Prefab.transform.localScale;
        //			temp.x += difference.x;
        //			temp.y += difference.y;
        //			Prefab.transform.localScale = temp;
        //			builderManager.setCorners(builderManager.getCorners() + 1);
        //
        //		}
        //	}
        //}
    }

}
