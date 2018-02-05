using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureScript : MonoBehaviour
{
    public enum Type
    {
        chair,
        cabinet,
        table,
        sofa
    }
    public Type fType;
    public List<Material> materials;
    public float maxHeight { get; set; }
    public float minHeight { get; set; }
    public float maxWidth { get; set; }
    public float minWidth { get; set; }
    public float maxDepth { get; set; }
    public float minDepth { get; set; }
    public bool isSelected = false;
    public Material SelectionMaterial;

    public int currentTexIndex = 0;

    // Use this for initialization
    void Start()
    {
        switch (fType)
        {
            case Type.chair:
                maxHeight = 3.0f;
                minHeight = 0.5f;
                maxWidth = 5.5f;
                minWidth = 0.4f;
                maxDepth = 5.5f;
                minDepth = 0.4f;
                break;
            case Type.sofa:
                maxHeight = 3.0f;
                minHeight = 0.5f;
                maxWidth = 5.5f;
                minWidth = 0.4f;
                maxDepth = 5.5f;
                minDepth = 0.4f;
                break;
            case Type.cabinet:
                maxHeight = 3.0f;
                minHeight = 0.5f;
                maxWidth = 2.0f;
                minWidth = 0.4f;
                maxDepth = 4.0f;
                minDepth = 0.4f;
                break;
            case Type.table:
                maxHeight = 4.5f;
                minHeight = 0.5f;
                maxWidth = 5.0f;
                minWidth = 0.4f;
                maxDepth = 4.0f;
                minDepth = 0.4f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            SetSelectTexture();
        }
        else
        {
            SetTexture();
        }
        
    }

    public void ChangeTexture()
    {
        currentTexIndex++;
        if (currentTexIndex >= materials.Count)
        {
            currentTexIndex = 0;
        }
        if (fType == Type.chair)
        {
            Transform seat = transform.Find("seat");
            seat.GetComponent<Renderer>().material = materials[currentTexIndex];

        }
        else
        {
            setMaterial(transform, materials[currentTexIndex]);
        }

    }

    public void SetTexture()
    {
        Debug.Log("log set tex");

        if (fType == Type.chair)
        {
            Transform seat = transform.Find("seat");
            seat.GetComponent<Renderer>().material = materials[currentTexIndex];

        }
        else
        {
            setMaterial(transform, materials[currentTexIndex]);
        }

    }

    public void SetSelectTexture()
    {

        setMaterial(transform, SelectionMaterial);
    }

    public void setMaterial(Transform t, Material mat)
    {
        foreach (Transform child in t)
        {

            setMaterial(child, mat);
            child.GetComponent<Renderer>().material = mat;
        }
    }

}
