using UnityEngine;
using System.Collections;

public class ExcampleClass : MonoBehaviour
{
    public GameObject furniture;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            MoveFernitureX(1);
        if (Input.GetKeyDown("a"))
            MoveFernitureY(1);
        if (Input.GetKeyDown("z"))
            MoveFernitureZ(1);
        if (Input.GetKeyDown("e"))
            ScaleFernitureX(1);
        if (Input.GetKeyDown("d"))
            ScaleFernitureY(1);
        if (Input.GetKeyDown("c"))
            ScaleFernitureZ(1);

        if (Input.GetKeyDown("w"))
            MoveFernitureX(-1);
        if (Input.GetKeyDown("s"))
            MoveFernitureY (-1);
        if (Input.GetKeyDown("x"))
            MoveFernitureZ(-1);
        if (Input.GetKeyDown("r"))
            ScaleFernitureX(-1);
        if (Input.GetKeyDown("f"))
            ScaleFernitureY(-1);
        if (Input.GetKeyDown("v"))
            ScaleFernitureZ(-1);
    }

        public void MoveFernitureX(int shift)
    {
        Vector3 tmp = furniture.transform.position;
        tmp.x += shift;
        furniture.transform.position = tmp;
    }

    public void MoveFernitureY(int shift)
    {
        Vector3 tmp = furniture.transform.position;
        tmp.y += shift;
        furniture.transform.position = tmp;
    }

    public void MoveFernitureZ(int shift)
    {
        Vector3 tmp = furniture.transform.position;
        tmp.z += shift;
        furniture.transform.position = tmp;
    }

    public void ScaleFernitureX(int scale)
    {
        Vector3 tmp = furniture.transform.localScale;
        tmp.x += scale;
        furniture.transform.localScale = tmp;
    }
    public void ScaleFernitureY(int scale)
    {
        Vector3 tmp = furniture.transform.localScale;
        tmp.y += scale;
        furniture.transform.localScale = tmp;
    }
    public void ScaleFernitureZ(int scale)
    {
        Vector3 tmp = furniture.transform.localScale;
        tmp.z += scale;
        furniture.transform.localScale = tmp;
        Vector3 tmp1 = furniture.transform.position;
        tmp.y += 0.5f;
        furniture.transform.position = tmp1;
    }

    
}
