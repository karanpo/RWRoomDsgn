using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManuController : VRInteractableObject
{
    // http://academyofvr.com/intro-vive-development-raycast-examples/
    public RectTransform[] handIndicatorRects;
    public RectTransform canvasRect;
    protected SteamVR_TrackedObject trackedObj;
	protected int leftControllerIndex
	{
		get
		{
			//Get index of leftmost controller
			return SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);
		}
	}



    public void RayStay(RaycastHit hit, LaserPointer controller = null)
	{
        //Get position of the raycast hit, relative to the Canvas
        Vector2 position = canvasRect.InverseTransformPoint(hit.point);

        //If there is a controller script, which meands that a controller is triggering
        
            //Get a controller index of either 0 or 1, 0 if the controller is leftmost, 1 otherwise
        if (controller.Controller.index == leftControllerIndex)
            {
                handIndicatorRects[0].anchoredPosition = position;
                Debug.Log(gameObject.name + "ww Trigger Press");
            }

        
	}
}
