using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureScript : MonoBehaviour {
    public enum Type
    {
        chair,
        cabinet,
        table
    }
    public Type fType;
    public List<Material> materials;
    public float maxHeight { get; set; }
    public float minHeight { get; set; }
    public float maxWidth { get; set; }
    public float minWidth { get; set; }
    public float maxDepth { get; set; }
    public float minDepth { get; set; }
    

    int currentTexIndex = 0;

	// Use this for initialization
	void Start () {
		switch (fType){
            case Type.chair:
                maxHeight=100.0f;
                minHeight=0.5f;
                maxWidth=100.0f;
                minWidth=0.4f;
                maxDepth=100.0f;
                minDepth=0.4f;
                break;
            case Type.cabinet:
                maxHeight=100.0f;
                minHeight=0.5f;
                maxWidth=100.0f;
                minWidth=0.4f;
                maxDepth=100.0f;
                minDepth=0.4f;
                break;
            case Type.table:
                maxHeight=100.0f;
                minHeight=0.5f;
                maxWidth=100.0f;
                minWidth=0.4f;
                maxDepth=100.0f;
                minDepth=0.4f;
                break;
        }
        

	}
	
	// Update is called once per frame
	void Update () {
		
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

    public void setMaterial(Transform t, Material mat)
 {
     foreach (Transform child in t) {

         setMaterial(child, mat);
         child.GetComponent<Renderer>().material = mat;
     }
 }

}
