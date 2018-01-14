namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using System.Collections;

    public class UI_BuilderInteractions : MonoBehaviour
    {

		BuilderManager builderManager = new BuilderManager();
		public Transform window;
        public void Undo()
        {
            Debug.Log("Undo Clicked");
        }
        public void Redo()
        {
            Debug.Log("Redo Clicked");
        }
        public void Reset()
        {
            Debug.Log("Reset Clicked");
        }
        public void Save()
        {
            Debug.Log("Save Clicked");
        }
        public void Exit()
        {
            Debug.Log("Exit Clicked");
        }
        public void Build_Wall()
        {
			builderManager.setObjectName("Wall");
            Debug.Log("Build Wall Clicked");
        }

        public void Build_Window()
        {
			builderManager.setObjectName("Window");
            Debug.Log("Mount Window Clicked");
        }

        public void Build_Door()
        {
			builderManager.setObjectName("Door");
            Debug.Log("Mount Door Clicked");
        }
    }
}
