using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditFernitureMenuScript : MonoBehaviour {

    public GameObject furniture { get; set; }
    public GameObject EditMenu;
    public GameObject MoveMenu;
    public GameObject ScaleMenu;
    public GameObject ColourMenu;

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
        furniture.GetComponent<EditFernitureScript>().ChangeTexture();
    }

    public void OnExitButton()
    {
        MoveMenu.SetActive(false);
        ScaleMenu.SetActive(false);
        ColourMenu.SetActive(false);
        EditMenu.SetActive(true);
        gameObject.SetActive(false);
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
        Vector3 tmp = furniture.transform.localScale;
        tmp.x += scale;
        furniture.transform.localScale = tmp;
    }
    public void ScaleFernitureY(int scale)
    {
        Vector3 tmp = furniture.transform.localScale;
        tmp.y += scale;
        furniture.transform.localScale = tmp;
    }
    public void ScaleFernitureZ(int scale)
    {
        Vector3 tmp = furniture.transform.localScale;
        tmp.z += scale;
        furniture.transform.localScale = tmp;
        Vector3 tmp1 = furniture.transform.position;
        tmp.y += 0.5f;
        furniture.transform.position = tmp1;
    }



}
