using UnityEngine;
using UnityEditor;
using VRTK;
using System.IO;
using System.Collections.Generic;

public class PlaceFurnitureMenuScript : MonoBehaviour
{
    public GameObject chairs;
    public GameObject tables;
    public GameObject cabinets;
    public GameObject PlaceFurnitureMenu;
    public GameObject ChooseChairMenu;
    public GameObject ChooseTableMenu;
    public GameObject ChooseCabinetMenu;
    private List<GameObject> chairsList;
    private List<GameObject> tablesList;
    private List<GameObject> cabinetsList;

    protected void Start()
    {
        chairsList = new List<GameObject>();
        tablesList = new List<GameObject>();
        cabinetsList = new List<GameObject>();

        string folderPath = Application.dataPath + @"/Prefabs/Furniture/";

        string[] chairsPaths = Directory.GetFiles(folderPath + "Chairs");
        string[] tablesPaths = Directory.GetFiles(folderPath + "Tables");
        string[] cabinetsPaths = Directory.GetFiles(folderPath + "Cabinets");

        foreach (string filePath in chairsPaths)
        {
            if (!filePath.Contains(".meta"))
            {
                string assetPath = filePath.Substring(Application.dataPath.Length - 6);
                Object asset = AssetDatabase.LoadAssetAtPath(assetPath, typeof(Object));

                chairsList.Add(asset as GameObject);
            }
        }

        foreach (string filePath in tablesPaths)
        {
            if (!filePath.Contains(".meta"))
            {
                string assetPath = filePath.Substring(Application.dataPath.Length - 6);
                Object asset = AssetDatabase.LoadAssetAtPath(assetPath, typeof(Object));

                tablesList.Add(asset as GameObject);
            }
        }

        foreach (string filePath in cabinetsPaths)
        {
            if (!filePath.Contains(".meta"))
            {
                string assetPath = filePath.Substring(Application.dataPath.Length - 6);
                Object asset = AssetDatabase.LoadAssetAtPath(assetPath, typeof(Object));

                cabinetsList.Add(asset as GameObject);
            }
        }
        
        ReturnToPlaceFurnitureMenu();
    }

    public void OnChangeChairButton()
    {
        PlaceFurnitureMenu.SetActive(false);
        ChooseChairMenu.SetActive(true);
        ChooseTableMenu.SetActive(false);
        ChooseCabinetMenu.SetActive(false);
    }

    public void OnChangeTableButton()
    {
        PlaceFurnitureMenu.SetActive(false);
        ChooseChairMenu.SetActive(false);
        ChooseTableMenu.SetActive(true);
        ChooseCabinetMenu.SetActive(false);
    }

    public void OnChangeCabinetButton()
    {
        PlaceFurnitureMenu.SetActive(false);
        ChooseChairMenu.SetActive(false);
        ChooseTableMenu.SetActive(false);
        ChooseCabinetMenu.SetActive(true);
    }

    public void ReturnToPlaceFurnitureMenu()
    {
        PlaceFurnitureMenu.SetActive(true);
        ChooseChairMenu.SetActive(false);
        ChooseTableMenu.SetActive(false);
        ChooseCabinetMenu.SetActive(false);
    }

    public void OnPlaceChair(int id)
    {
        Transform trackedObj = VRTK_DeviceFinder.GetControllerLeftHand().transform.parent;

        RaycastHit hit;
        bool rayHit = Physics.Raycast(trackedObj.transform.position, trackedObj.transform.forward, out hit, 100);

        Vector3 middle = new Vector3(0.0f, 0.0f, 0.0f);

        if (rayHit && hit.collider.gameObject.tag.Contains("Floor"))
        {
            middle = hit.transform.position;

            GameObject newChair = Instantiate(chairsList[id], new Vector3(middle.x, middle.y, middle.z), Quaternion.Euler(new Vector3(-90.0f, 0.0f, -90.0f)), chairs.transform) as GameObject;
        }

        ReturnToPlaceFurnitureMenu();
    }

    public void OnPlaceTable(int id)
    {
        Transform trackedObj = VRTK_DeviceFinder.GetControllerLeftHand().transform.parent;

        RaycastHit hit;
        bool rayHit = Physics.Raycast(trackedObj.transform.position, trackedObj.transform.forward, out hit, 100);

        Vector3 middle = new Vector3(0.0f, 0.0f, 0.0f);

        if (rayHit && hit.collider.gameObject.tag.Contains("Floor"))
        {
            middle = hit.transform.position;

            GameObject newTable = Instantiate(tablesList[id], new Vector3(middle.x, middle.y, middle.z), Quaternion.Euler(new Vector3(-90.0f, 0.0f, 0.0f)), tables.transform) as GameObject;
        }

        ReturnToPlaceFurnitureMenu();
    }

    public void OnPlaceCabinet(int id)
    {
        Transform trackedObj = VRTK_DeviceFinder.GetControllerLeftHand().transform.parent;

        RaycastHit hit;
        bool rayHit = Physics.Raycast(trackedObj.transform.position, trackedObj.transform.forward, out hit, 100);

        Vector3 middle = new Vector3(0.0f, 0.0f, 0.0f);

        if (rayHit && hit.collider.gameObject.tag.Contains("Floor"))
        {
            middle = hit.transform.position;

            GameObject newCabinet = Instantiate(cabinetsList[id], new Vector3(middle.x, middle.y, middle.z), Quaternion.Euler(new Vector3(-90.0f, 0.0f, 0.0f)), cabinets.transform) as GameObject;
        }

        ReturnToPlaceFurnitureMenu();
    }

}