using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditFurnitureMenuScript : MonoBehaviour {

    public GameObject furniture { get; set; }
    public GameObject EditMenu;
    public GameObject MoveMenu;
    public GameObject ScaleMenu;
    public float floorYpos = 0;

    public void OnMoveButton()
    {
        EditMenu.SetActive(false);
        MoveMenu.SetActive(true);
    }

    public void OnResizeButton()
    {
        EditMenu.SetActive(false);
        ScaleMenu.SetActive(true);
    }

    public void OnColorButton()
    {
        furniture.GetComponent<EditFurnitureScript>().ChangeTexture();
    }

    public void OnExitButton()
    {
        MoveMenu.SetActive(false);
        ScaleMenu.SetActive(false);
        EditMenu.SetActive(false);
        //gameObject.SetActive(false);
    }

    public void OnRetButton()
    {
        MoveMenu.SetActive(false);
        ScaleMenu.SetActive(false);
        EditMenu.SetActive(true);
        //gameObject.SetActive(false);
    }


    public void MoveFernitureX(int shift)
    {
        Vector3 tmp = furniture.transform.position;
        tmp.x += shift;
        furniture.transform.position = tmp;
    }

    public void MoveFernitureY(int shift)
    {
        Vector3 tmp = furniture.transform.position;
        tmp.y += shift;
        if (tmp.y > floorYpos)
            furniture.transform.position = tmp;
    }

    public void MoveFernitureZ(int shift)
    {
        Vector3 tmp = furniture.transform.position;
        tmp.z += shift;
        furniture.transform.position = tmp;
    }

    public void ScaleFernitureX(int scale)
    {
        FurnitureScript myscript = furniture.GetComponentInChildren<FurnitureScript>();

        Vector3 tmp = furniture.transform.localScale;
        tmp.x += scale;
        if (tmp.x < myscript.maxDepth && tmp.x > myscript.minDepth)
            furniture.transform.localScale = tmp;
    }
    public void ScaleFernitureY(int scale)
    {
        FurnitureScript myscript = furniture.GetComponentInChildren<FurnitureScript>();

        Vector3 tmp = furniture.transform.localScale;
        tmp.y += scale;

        if (tmp.y < myscript.maxWidth && tmp.y > myscript.minWidth)
            furniture.transform.localScale = tmp;
    }
    public void ScaleFernitureZ(int scale)
    {
        FurnitureScript myscript = furniture.GetComponentInChildren<FurnitureScript>();

        Vector3 tmp = furniture.transform.localScale;
        tmp.z += scale;
        
        if (tmp.z < myscript.maxHeight && tmp.z > myscript.minHeight)
        {
            furniture.transform.localScale = tmp;
        }
    }



}
