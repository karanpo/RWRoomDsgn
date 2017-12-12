using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManuController : VRInteractableObject
{
    
    public RectTransform[] handIndicatorRects;
    public RectTransform canvasRect;
	protected int leftControllerIndex
	{
		get
		{
			//Get index of leftmost controller
			return SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);
		}
	}

    public override void RayStay(RaycastHit hit, vControllerScript controller = null)
	{
        //Get position of the raycast hit, relative to the Canvas
        Vector2 position = canvasRect.InverseTransformPoint(hit.point);

        //If there is a controller script, which meands that a controller is triggering
        if (controller)
        {
            //Get a controller index of either 0 or 1, 0 if the controller is leftmost, 1 otherwise
            if (controller.device.index == leftControllerIndex)
            {
                handIndicatorRects[0].anchoredPosition = position;
            }

        }
	}
}
