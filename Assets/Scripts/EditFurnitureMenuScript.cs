using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditFurnitureMenuScript : MonoBehaviour {

    public GameObject furniture { get; set; }
    public GameObject EditMenu;
    public GameObject MoveMenu;
    public GameObject ScaleMenu;
    public GameObject RotateMenu;
    public float floorYpos = 0;
    public float MoveForce = 2;
    private float scaleFactor = 0.25f;

    public void MenuOn()
    {
        EditMenu.SetActive(true);
        MoveMenu.SetActive(false);
        ScaleMenu.SetActive(false);
        RotateMenu.SetActive(false);
    }

    public void MenuOff()
    {
        EditMenu.SetActive(false);
        MoveMenu.SetActive(false);
        ScaleMenu.SetActive(false);
        RotateMenu.SetActive(false);
    }

    public void OnMoveButton()
    {
        ScaleMenu.SetActive(false);
        RotateMenu.SetActive(false);
        EditMenu.SetActive(false);
        MoveMenu.SetActive(true);
    }

    public void OnResizeButton()
    {

        MoveMenu.SetActive(false);
        RotateMenu.SetActive(false);
        EditMenu.SetActive(false);
        ScaleMenu.SetActive(true);
    }

    public void OnRotButton()
    {
        MoveMenu.SetActive(false);
        ScaleMenu.SetActive(false);
        EditMenu.SetActive(false);
        RotateMenu.SetActive(true);
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
        RotateMenu.SetActive(false);
        //gameObject.SetActive(false);
    }

    public void OnRetButton()
    {
        MoveMenu.SetActive(false);
        ScaleMenu.SetActive(false);
        RotateMenu.SetActive(false);
        EditMenu.SetActive(true);
        //gameObject.SetActive(false);
    }

    public void OnDelete()
    {
        Delete();
        OnExitButton();
    }
    
    public void Delete()
    {
        if (furniture != null)
        {
            Destroy(furniture);
        }
    }

    public void MoveFernitureX(float shift)
    {
        furniture.GetComponent<Rigidbody>().AddForce(shift * MoveForce, 0, 0, ForceMode.Impulse);
    }

    public void MoveFernitureY(float shift)
    {

        furniture.GetComponent<Rigidbody>().AddForce(0, shift * MoveForce, 0, ForceMode.Impulse);
    }

    public void MoveFernitureZ(float shift)
    {

        furniture.GetComponent<Rigidbody>().AddForce(0, 0, shift * MoveForce, ForceMode.Impulse);
    }

    public void ScaleFernitureX(float scale)
    {
        FurnitureScript myscript = furniture.GetComponentInChildren<FurnitureScript>();

        Vector3 tmp = furniture.transform.localScale;
        tmp.x += scale * scaleFactor;
        if (tmp.x < myscript.maxDepth && tmp.x > myscript.minDepth)
            furniture.transform.localScale = tmp;
    }
    public void ScaleFernitureY(float scale)
    {
        FurnitureScript myscript = furniture.GetComponentInChildren<FurnitureScript>();

        Vector3 tmp = furniture.transform.localScale;
        tmp.y += scale * scaleFactor;

        if (tmp.y < myscript.maxWidth && tmp.y > myscript.minWidth)
        {
            furniture.transform.localScale = tmp;
        }

    }
    public void ScaleFernitureZ(float scale)
    {
        FurnitureScript myscript = furniture.GetComponentInChildren<FurnitureScript>();

        Vector3 tmp = furniture.transform.localScale;
        tmp.z += scale * scaleFactor;
        
        if (tmp.z < myscript.maxHeight && tmp.z > myscript.minHeight)
        {
            furniture.transform.Translate(0, 0.1f, 0, Space.World);
            furniture.transform.localScale = tmp;
        }
    }

    public void RotFernitureY(float scale)
    {
        
        furniture.transform.Rotate(0, scale, 0);
        
    }
    public void RotFernitureZ(float scale)
    {
        furniture.transform.Rotate(0, 0, scale);
    }



}
