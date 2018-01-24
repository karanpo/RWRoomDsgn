using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PlaceFurnitureScript : VRTK_InteractableObject
{
    public GameObject EditMenu;

    public override void StartUsing(VRTK_InteractUse usingObject)
    {
        base.StartUsing(usingObject);
        EditMenu.transform.Find("RadialMenuUI").gameObject.SetActive(true);
    }

    public override void StopUsing(VRTK_InteractUse usingObject)
    {
        base.StopUsing(usingObject);
        EditMenu.transform.Find("RadialMenuUI").gameObject.SetActive(false);
    }

    protected void Start()
    {
    }

    protected override void Update()
    {
        base.Update();
    }
}
