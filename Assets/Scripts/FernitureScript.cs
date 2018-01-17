using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FernitureScript : MonoBehaviour {
    public enum Type
    {
        chair,
        cabinet,
        table
    }
    public Type fType;
    public List<Material> materials;

    

    int currentTexIndex = 0;

	// Use this for initialization
	void Start () {
		
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
