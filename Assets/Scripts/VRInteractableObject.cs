using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInteractableObject : MonoBehaviour {



    /// <summary>
    /// Called when either the head or a controller is pointed at an object
    /// </summary>
    /// <param name="controller">Leave null if ray is coming from head</param>
    public virtual void RayEnter(RaycastHit hit, vControllerScript controller = null)
    {
        //Empty. Overriden meothod only.
    }

    /// <summary>
    /// Called every frame the head or a controller is pointed at an object
    /// </summary>
    /// <param name="controller">Leave null if ray is coming from head</param>
    public virtual void RayStay(RaycastHit hit, vControllerScript controller = null)
    {
        //Empty. Overriden meothod only.
    }

    /// <summary>
    /// Called when either the head or a controller leaves the object
    /// </summary>
    /// <param name="controller">Leave null if ray is coming from head</param>
    public virtual void RayExit(vControllerScript controller = null)
    {
        //Empty. Overriden meothod only.
    }
}
