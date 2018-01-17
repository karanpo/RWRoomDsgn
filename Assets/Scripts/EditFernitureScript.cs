using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class EditFernitureScript : VRTK_InteractableObject
    {
    public GameObject EditMenu;

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
            EditMenu.SetActive(true);
            EditMenu.GetComponent<EditFernitureMenuScript>().furniture = gameObject;
        }

        public override void StopUsing(VRTK_InteractUse usingObject)
        {
            base.StopUsing(usingObject);
            EditMenu.SetActive(false);
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
