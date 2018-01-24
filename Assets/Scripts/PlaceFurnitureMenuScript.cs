using UnityEngine;
using UnityEditor;
using VRTK;

public class PlaceFurnitureMenuScript : MonoBehaviour
{
    public GameObject chair;
    public GameObject table;
    public GameObject cabinet;
    public GameObject chairs;
    public GameObject tables;
    public GameObject cabinets;
    public GameObject EditMenu;

    public void OnPlaceChair()
    {
        Transform trackedObj = VRTK_DeviceFinder.GetControllerLeftHand().transform.parent;

        RaycastHit hit;
        bool rayHit = Physics.Raycast(trackedObj.transform.position, trackedObj.transform.forward, out hit, 100);

        Vector3 middle = new Vector3(0.0f, 0.0f, 0.0f);

        if (rayHit && hit.collider.gameObject.tag.Contains("Floor"))
        {
            middle = hit.transform.position;
            middle.y = 1.2f;

            GameObject newChair = Instantiate(chair, new Vector3(middle.x, middle.y, middle.z), Quaternion.Euler(new Vector3(-90.0f, 0.0f, -90.0f)), chairs.transform) as GameObject;
        }
    }

    public void OnPlaceTable()
    {
        Transform trackedObj = VRTK_DeviceFinder.GetControllerLeftHand().transform.parent;

        RaycastHit hit;
        bool rayHit = Physics.Raycast(trackedObj.transform.position, trackedObj.transform.forward, out hit, 100);

        Vector3 middle = new Vector3(0.0f, 0.0f, 0.0f);

        if (rayHit && hit.collider.gameObject.tag.Contains("Floor"))
        {
            middle = hit.transform.position;
            middle.y = 1.2f;

            GameObject newTable = Instantiate(table, new Vector3(middle.x, middle.y, middle.z), Quaternion.Euler(new Vector3(-90.0f, 0.0f, 0.0f)), tables.transform) as GameObject;
        }
    }

    public void OnPlaceCabinet()
    {
        Transform trackedObj = VRTK_DeviceFinder.GetControllerLeftHand().transform.parent;

        RaycastHit hit;
        bool rayHit = Physics.Raycast(trackedObj.transform.position, trackedObj.transform.forward, out hit, 100);

        Vector3 middle = new Vector3(0.0f, 0.0f, 0.0f);

        if (rayHit && hit.collider.gameObject.tag.Contains("Floor"))
        {
            middle = hit.transform.position;
            middle.y = 1.2f;

            GameObject newCabinet = Instantiate(cabinet, new Vector3(middle.x, middle.y, middle.z), Quaternion.Euler(new Vector3(-90.0f, 0.0f, 0.0f)), cabinets.transform) as GameObject;
        }
    }
}