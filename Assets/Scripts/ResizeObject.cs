using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeObject : MonoBehaviour {

    Vector3 tempX, tempY;
    public float sizingFactor = 0.02f;
    private GameObject lastSpawn = null;
    private float startSize;
    private float startX;

    if (Input.GetMouseButtonDown (0))
    {
             float positionZ = 10.0f;
             Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionZ);
             startX = position.x;
             position = Camera.main.ScreenToWorldPoint(position);
             lastSpawn = Instantiate(cubePrefab, position, transform.rotation) as GameObject;
             startSize = lastSpawn.transform.localScale.z;
    }
 
         if (Input.GetMouseButton (0)) {
             Vector3 size = lastSpawn.transform.localScale;
            size.x = startSize + (Input.mousePosition.x - startX) * sizingFactor;
            lastSpawn.transform.localScale = size;
         }
     }

    void ResizeX()
    {
        tempX = transform.localScale;
        tempX.x += Time.deltaTime;
        transform.localScale = tempX;
    }

    void Resize()
    {
        temp = transform.localScale;
        temp.y += Time.deltaTime;
        transform.localScale = tempY;
    }

}
