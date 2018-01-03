using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManuControllerScript : MonoBehaviour {

    public GameObject PlaceFManu;
    public GameObject EditFManu;

    public void EnablePlaceFurnitureManu(GameObject florTile)
    {
        PlaceFManu.SetActive(true);
        PlaceFManu.GetComponent<PlaceFernitureManuScript>().floorTile = florTile;
    }

    public void EnableEditFurnitureManu(GameObject furniture)
    {
        EditFManu.SetActive(true);
        EditFManu.GetComponent<EditFernitureManuScript>().furniture = furniture;
    }

    public void DisablePlaceFurnitureManu(GameObject florTile)
    {
        PlaceFManu.SetActive(false);
    }

    public void DisableEditFurnitureManu(GameObject furniture)
    {
        EditFManu.SetActive(false);
    }
}
