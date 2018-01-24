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
            Debug.Log("log trigger1");
            base.StartUsing(usingObject);
            Debug.Log("log trigger");
            menu = true;
            //if (gameObject.GetComponent<Renderer>())
            //{
             //   FurnitureScript myscript = gameObject.GetComponentInChildren<FurnitureScript>();
            //    myscript.SetTexture();
            //    gameObject.GetComponent<Renderer>().material = myscript.materials[myscript.currentTexIndex];
            //}
        
            EditMenu = GameObject.FindGameObjectWithTag("EditMenu");
            EditMenu.GetComponent<EditFurnitureMenuScript>().MenuOn();
            EditMenu.GetComponent<EditFurnitureMenuScript>().furniture = gameObject;
            //EditMenu.transform.Find("RadialMenuUI").transform.Find("Panel").GetComponent<VRTK_RadialMenu>().ShowMenu();

    }

        public override void StopUsing(VRTK_InteractUse usingObject)
        {
            base.StopUsing(usingObject);
            FurnitureScript myscript = gameObject.GetComponentInChildren<FurnitureScript>();
            myscript.SetTexture();
            gameObject.GetComponent<Renderer>().material = myscript.materials[myscript.currentTexIndex];
            menu = false;
            EditMenu.GetComponent<EditFurnitureMenuScript>().OnExitButton();
            //EditMenu.transform.Find("RadialMenuUI").gameObject.SetActive(false);
    }

        protected void Start()
        {
            ;
        }

        protected override void Update()
        {
            base.Update();
        
        }

        public void ChangeTexture()
        {
            FurnitureScript myscript = gameObject.GetComponentInChildren<FurnitureScript>();
            myscript.ChangeTexture();
        }
    }
