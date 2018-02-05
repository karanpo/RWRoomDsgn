using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System;

public class SceneManager : MonoBehaviour
{
    public GameObject floor;
    public GameObject floorParent;
    public GameObject ceiling;
    public GameObject ceilingParent;
    public GameObject wall;
    public GameObject wallParent;
    public GameObject window;
    public GameObject windowParent;
    public GameObject door;
    public GameObject doorParent;
    public GameObject light;
    public GameObject lightParent;
    public GameObject player;
    public GameObject cameraVR;
    public BuilderManager manager;

    private List<Vector3> wallCorners = new List<Vector3>();
    private List<Vector3> windowCorners = new List<Vector3>();
    private List<Vector3> doorCorners = new List<Vector3>();

    private float wallHeight = 3.0f;
    private float wallWidth = 1.0f;
    private float windowHeight = 1.2f;
    private float windowWidth = 1.0f;
    private float doorHeight = 2.2f;
    private float doorWidth = 0.9f;
    private float floorWidth = 0.1f;
    private float floorSide = 1.0f;
    private float sizeCoefficient = 50.0f;
    private float sizeOffset = 0.0f;

    void Start()
    {
        ReadCoordsFromFiles();

        wallCorners = AdjustList(wallCorners);
        windowCorners = AdjustList(windowCorners);
        doorCorners = AdjustList(doorCorners);

        BuildFloor();
        BuildCeiling();
        BuildWalls();
        BuildWindows();
        BuildDoors();
        PutLight();
        SetPlayerPosition();
    }

    void Update()
    {

    }

    private List<Vector3> AdjustList(List<Vector3> list)
    {
        var result = new List<Vector3>();

        for (int i = 0; i < list.Count; i++)
        {
            var item = list[i];

            item.x = (list[i].x + sizeOffset) / sizeCoefficient;
            item.z = (list[i].y + sizeOffset) / sizeCoefficient;
            item.y = 0.0f;

            result.Add(item);
        }

        return result;
    }

    private float GetMostRight(List<Vector3> list)
    {
        if (list == null) return 0.0f;

        float right = list[0].x;

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].x > right) right = list[i].x;
        }

        return right;
    }

    private float GetMostLeft(List<Vector3> list)
    {
        if (list == null) return 0.0f;

        float left = list[0].x;

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].x < left) left = list[i].x;
        }

        return left;
    }

    private float GetMostFront(List<Vector3> list)
    {
        if (list == null) return 0.0f;

        float front = list[0].z;

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].z > front) front = list[i].z;
        }

        return front;
    }

    private float GetMostBack(List<Vector3> list)
    {
        if (list == null) return 0.0f;

        float back = list[0].z;

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].z < back) back = list[i].z;
        }

        return back;
    }

    public void BuildFloor()
    {
        for (float i = GetMostLeft(wallCorners); i < GetMostRight(wallCorners); i += 1)
        {
            for (float j = GetMostBack(wallCorners); j < GetMostFront(wallCorners); j += 1)
            {
                Vector3 middle = new Vector3(
                    i + floorSide / 2.0f,
                    0.0f,
                    j + floorSide / 2.0f);

                GameObject newFloor = Instantiate(
                    floor,
                    middle,
                    Quaternion.identity) as GameObject;
                newFloor.transform.localScale = new Vector3(floorWidth, 1.0f, floorWidth);
                newFloor.transform.SetParent(floorParent != null ? floorParent.transform : null);
            }
        }
    }

    public void BuildCeiling()
    {
        for (float i = GetMostLeft(wallCorners); i < GetMostRight(wallCorners); i += 1)
        {
            for (float j = GetMostBack(wallCorners); j < GetMostFront(wallCorners); j += 1)
            {
                Vector3 middle = new Vector3(
                    i + floorSide / 2.0f,
                    wallHeight,
                    j + floorSide / 2.0f);

                GameObject newCeiling = Instantiate(
                    ceiling,
                    middle,
                    Quaternion.Euler(new Vector3(0.0f, 0.0f, 180.0f)),
                    ceilingParent.transform) as GameObject;
                newCeiling.transform.localScale = new Vector3(floorWidth, 1.0f, floorWidth);
                newCeiling.transform.SetParent(ceilingParent != null ? ceilingParent.transform : null);
            }
        }
    }

    public void BuildWalls(List<Vector3> walls = null)
    {
        List<Vector3> corners = walls ?? wallCorners;

        if (corners != null)
        {
            for (int i = 0; i < corners.Count - 1; i++)
            {
                Vector3 firstCorner = corners[i];
                Vector3 secondCorner = corners[i + 1];

                Vector3 middle = new Vector3(
                    (firstCorner.x + secondCorner.x) / 2.0f,
                    wallHeight / 2.0f,
                    (firstCorner.z + secondCorner.z) / 2.0f);

                Vector3 direction = new Vector3(
                    Mathf.Abs(firstCorner.x - secondCorner.x),
                    Mathf.Abs(firstCorner.y - secondCorner.y),
                    Mathf.Abs(firstCorner.z - secondCorner.z));

                Vector3 rotation = new Vector3(0.0f, 0.0f, 0.0f);

                if (direction.x >= 0.01f)
                {
                    rotation.y = 90;
                }

                float distance = Mathf.Sqrt(
                    Mathf.Pow((firstCorner.x - secondCorner.x), 2) +
                    Mathf.Pow((firstCorner.z - secondCorner.z), 2)) * wallWidth;

                GameObject newWall = Instantiate(
                    wall,
                    middle,
                    Quaternion.Euler(rotation)) as GameObject;
                newWall.transform.localScale = new Vector3(0.02f, wallHeight, distance);
                newWall.transform.SetParent(wallParent != null ? wallParent.transform : null);
            }
        }
    }

    public void BuildWindows(List<Vector3> windows = null)
    {
        List<Vector3> corners = windows ?? windowCorners;

        if (corners != null)
        {
            for (int i = 0; i < corners.Count - 1; i += 2)
            {
                Vector3 firstCorner = corners[i];
                Vector3 secondCorner = corners[i + 1];

                Vector3 middle = new Vector3(
                    (firstCorner.x + secondCorner.x) / 2.0f,
                    windowHeight / 2.0f + 0.8f,
                    (firstCorner.z + secondCorner.z) / 2.0f);

                Vector3 direction = new Vector3(
                    Mathf.Abs(firstCorner.x - secondCorner.x),
                    Mathf.Abs(firstCorner.y - secondCorner.y),
                    Mathf.Abs(firstCorner.z - secondCorner.z));

                Vector3 rotation = new Vector3(0.0f, 0.0f, 0.0f);

                if (direction.x >= 0.01f)
                {
                    rotation.y = 90;
                }

                float distance = Mathf.Sqrt(
                    Mathf.Pow((firstCorner.x - secondCorner.x), 2) +
                    Mathf.Pow((firstCorner.z - secondCorner.z), 2));

                GameObject newWindow = Instantiate(
                    window,
                    middle,
                    Quaternion.Euler(rotation)) as GameObject;
                newWindow.transform.localScale = new Vector3(0.03f, windowHeight, windowWidth * distance);
                newWindow.transform.SetParent(windowParent != null ? windowParent.transform : null);
            }
        }
    }

    public void BuildDoors(List<Vector3> doors = null)
    {
        List<Vector3> corners = doors ?? doorCorners;

        if (corners != null)
        {
            for (int i = 0; i < corners.Count - 1; i += 2)
            {
                Vector3 firstCorner = corners[i];
                Vector3 secondCorner = corners[i + 1];

                Vector3 middle = new Vector3(
                    (firstCorner.x + secondCorner.x) / 2.0f,
                    doorHeight / 2.0f,
                    (firstCorner.z + secondCorner.z) / 2.0f);

                Vector3 direction = new Vector3(
                    Mathf.Abs(firstCorner.x - secondCorner.x),
                    Mathf.Abs(firstCorner.y - secondCorner.y),
                    Mathf.Abs(firstCorner.z - secondCorner.z));

                Vector3 rotation = new Vector3(0.0f, 0.0f, 0.0f);

                if (direction.x >= 0.01f)
                {
                    rotation.y = 90;
                }

                float distance = Mathf.Sqrt(
                    Mathf.Pow((firstCorner.x - secondCorner.x), 2) +
                    Mathf.Pow((firstCorner.z - secondCorner.z), 2));

                GameObject newDoor = Instantiate(
                    door,
                    middle,
                    Quaternion.Euler(rotation)) as GameObject;
                newDoor.transform.localScale = new Vector3(0.04f, doorHeight, doorWidth * distance);
                newDoor.transform.SetParent(doorParent != null ? doorParent.transform : null);
            }
        }
    }

    public void PutLight(List<Vector3> walls = null)
    {
        List<Vector3> corners = walls ?? wallCorners;

        if (corners != null)
        {
            for (int i = 0; i < corners.Count - 1; i++)
            {
                Vector3 firstCorner = new Vector3(
                    corners[i].x,
                    wallHeight - 0.8f,
                    corners[i].z);

                GameObject newLight = Instantiate(
                    light,
                    firstCorner,
                    Quaternion.identity) as GameObject;
                newLight.transform.SetParent(lightParent != null ? lightParent.transform : null);
            }
        }
    }

    public void SetPlayerPosition()
    {
        var playerPosition = new Vector3(0.0f, 0.0f, 0.0f);

        if (doorCorners.Count >= 2)
        {
            var x = Mathf.Abs(doorCorners[0].x + doorCorners[1].x) / 2.0f;
            var z = Mathf.Abs(doorCorners[0].z + doorCorners[1].z) / 2.0f;

            if (Mathf.Abs(x - GetMostRight(wallCorners)) > Mathf.Abs(x - GetMostLeft(wallCorners)))
            {
                x += wallWidth;
            }
            if (Mathf.Abs(x - GetMostRight(wallCorners)) < Mathf.Abs(x - GetMostLeft(wallCorners)))
            {
                x -= wallWidth;
            }
            if (Mathf.Abs(z - GetMostFront(wallCorners)) > Mathf.Abs(z - GetMostBack(wallCorners)))
            {
                z += wallWidth;
            }
            if (Mathf.Abs(z - GetMostFront(wallCorners)) < Mathf.Abs(z - GetMostBack(wallCorners)))
            {
                z -= wallWidth;
            }

            if (cameraVR != null)
            {
                x -= cameraVR.transform.position.x;
                z -= cameraVR.transform.position.z;
            }

            playerPosition.x = x;
            playerPosition.y = 0.0f;
            playerPosition.z = z;
        }
        else
        {
            playerPosition.x = Mathf.Abs(GetMostLeft(wallCorners) - GetMostRight(wallCorners)) / 2.0f;
            playerPosition.y = 0.0f;
            playerPosition.z = Mathf.Abs(GetMostBack(wallCorners) - GetMostFront(wallCorners)) / 2.0f;
        }

        player.transform.localPosition = playerPosition;
    }

    public void ReadCoordsFromFiles()
    {
        String DocumentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

        try
        {
            using (TextReader reader = File.OpenText(DocumentsPath + @"\WallCorners.txt"))
            {
                string text;
                while ((text = reader.ReadLine()) != null)
                {
                    string[] bits = text.Split(';');
                    float x = float.Parse(bits[0]);
                    float y = float.Parse(bits[1]);
                    float z = float.Parse(bits[1]);
                    wallCorners.Add(new Vector3(x, y, z));
                }
            }
        }
        catch (Exception e)
        {
            wallCorners = new List<Vector3> {
            new Vector3(0.0f, 0.0f, 0.0f) * sizeCoefficient,
            new Vector3(6.0f, 0.0f, 0.0f) * sizeCoefficient,
            new Vector3(6.0f, 3.0f, 0.0f) * sizeCoefficient,
            new Vector3(8.0f, 3.0f, 0.0f) * sizeCoefficient,
            new Vector3(8.0f, 9.0f, 0.0f) * sizeCoefficient,
            new Vector3(6.0f, 9.0f, 0.0f) * sizeCoefficient,
            new Vector3(6.0f, 12.0f, 0.0f) * sizeCoefficient,
            new Vector3(0.0f, 12.0f, 0.0f) * sizeCoefficient,
            new Vector3(0.0f, 0.0f, 0.0f) * sizeCoefficient };
        }

        try
        {
            using (TextReader reader = File.OpenText(DocumentsPath + @"\WindowCorners.txt"))
            {
                string text;
                while ((text = reader.ReadLine()) != null)
                {
                    string[] bits = text.Split(';');
                    float x = float.Parse(bits[0]);
                    float y = float.Parse(bits[1]);
                    float z = float.Parse(bits[1]);
                    windowCorners.Add(new Vector3(x, y, z));
                }

            }
        }
        catch (Exception e)
        {
            windowCorners = new List<Vector3> {
            new Vector3(0.0f, 0.0f, 0.0f) * sizeCoefficient,
            new Vector3(6.0f, 0.0f, 0.0f) * sizeCoefficient,
            new Vector3(6.0f, 3.0f, 0.0f) * sizeCoefficient,
            new Vector3(8.0f, 3.0f, 0.0f) * sizeCoefficient,
            new Vector3(8.0f, 9.0f, 0.0f) * sizeCoefficient,
            new Vector3(6.0f, 9.0f, 0.0f) * sizeCoefficient,
            new Vector3(6.0f, 12.0f, 0.0f) * sizeCoefficient,
            new Vector3(0.0f, 12.0f, 0.0f) * sizeCoefficient};
        }

        try
        {
            using (TextReader reader = File.OpenText(DocumentsPath + @"\DoorCorners.txt"))
            {
                string text;
                while ((text = reader.ReadLine()) != null)
                {
                    string[] bits = text.Split(';');
                    float x = float.Parse(bits[0]);
                    float y = float.Parse(bits[1]);
                    float z = float.Parse(bits[1]);
                    doorCorners.Add(new Vector3(x, y, z));
                }

            }
        }
        catch (Exception e)
        {
            doorCorners = new List<Vector3> {
            new Vector3(0.0f, 5.0f, 0.0f) * sizeCoefficient,
            new Vector3(0.0f, 7.0f, 0.0f) * sizeCoefficient };//manager.getDoorCornerList();
        }
    }
}
