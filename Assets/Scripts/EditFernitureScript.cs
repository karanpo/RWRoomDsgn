using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class EditFernitureScript : VRTK_InteractableObject
    {
    public GameObject EditMenu;
    bool menu = false;
        public override void StartUsing(VRTK_InteractUse usingObject)
        {
        Debug.Log("log trigger1");
        base.StartUsing(usingObject);
        Debug.Log("log trigger");
        menu = true;
        EditMenu.transform.Find("RadialMenuUI").gameObject.SetActive(true);
        EditMenu.GetComponent<EditFernitureMenuScript>().furniture = gameObject;
        //EditMenu.transform.Find("RadialMenuUI").transform.Find("Panel").GetComponent<VRTK_RadialMenu>().ShowMenu();

    }

        public override void StopUsing(VRTK_InteractUse usingObject)
        {
            base.StopUsing(usingObject);
        menu = false;
        EditMenu.transform.Find("RadialMenuUI").gameObject.SetActive(false);
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
            FernitureScript myscript = gameObject.GetComponentInChildren<FernitureScript>();
            myscript.ChangeTexture();
        }
    }
