using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class EditFurnitureScript : VRTK_InteractableObject
{
    public GameObject EditMenu;
    bool menu = false;
    public override void StartUsing(VRTK_InteractUse usingObject)
    {
        base.StartUsing(usingObject);

        
        gameObject.GetComponentInChildren<FurnitureScript>().SetTexture();

        EditMenu = GameObject.FindGameObjectWithTag("EditMenu");
        EditMenu.GetComponent<EditFurnitureMenuScript>().MenuOn();
        EditMenu.GetComponent<EditFurnitureMenuScript>().furniture = gameObject;
        //EditMenu.transform.Find("RadialMenuUI").transform.Find("Panel").GetComponent<VRTK_RadialMenu>().ShowMenu();
        gameObject.GetComponentInChildren<FurnitureScript>().isSelected = true;
        if (GameManager.instance.selectedObject != null)
        {
            GameObject prevSelObject = GameManager.instance.selectedObject;
            GameManager.instance.selectedObject = null;
            prevSelObject.GetComponent<EditFurnitureScript>().StopUsing(prevSelObject);

        }
        GameManager.instance.selectedObject = gameObject;
    }

    public override void StopUsing(VRTK_InteractUse usingObject)
    {
        base.StopUsing(usingObject);
        gameObject.GetComponentInChildren<FurnitureScript>().SetTexture();

        //EditMenu.GetComponent<EditFurnitureMenuScript>().OnExitButton();
        //EditMenu.transform.Find("RadialMenuUI").gameObject.SetActive(false);
        gameObject.GetComponentInChildren<FurnitureScript>().isSelected = false;
        Debug.Log("log stop u");

    }

    protected void Start()
    {
        ;
    }

    protected override void Update()
    {
        base.Update();
        gameObject.GetComponentInChildren<FurnitureScript>().SetTexture();
    }

    public void ChangeTexture()
    {
        FurnitureScript myscript = gameObject.GetComponentInChildren<FurnitureScript>();
        myscript.ChangeTexture();
    }
}
