using UnityEngine;
using VRTK;

public class BuilderController : VRInteractableObject
{
    public VRTK_ControllerEvents controllerEvents;
    public GameObject builder;

    bool builderState = false;

    void OnEnable()
    {
        controllerEvents.ButtonTwoReleased += ControllerEvents_ButtonTwoReleased;
    }

    void OnDisable()
    {
        controllerEvents.ButtonTwoReleased -= ControllerEvents_ButtonTwoReleased;
    }

    private void ControllerEvents_ButtonTwoReleased(object sender, ControllerInteractionEventArgs e)
    {
        builderState = !builderState;
        builder.SetActive(builderState);
    }
}