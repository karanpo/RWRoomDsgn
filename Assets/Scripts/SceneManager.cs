using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject floorParent;
    public GameObject ceilingParent;
    public GameObject floor;
    public GameObject ceiling;
    public GameObject wall;
    public GameObject window;
    public GameObject door;
    public GameObject light;
    public GameObject player;
    public BuilderManager manager;
    private float wallHeight = 3.0f;
    private float windowHeight = 1.2f;
    private float windowWidth = 1.0f;
    private float doorHeight = 2.2f;
    private float doorWidth = 0.9f;
    public float floorSide = 20.0f;
    private float floorSize = 0.5f;
    private float sizeCoefficient = 50.0f;
    private float sizeOffset = 0.0f;

    void Start()
    {
        List<Vector3> wallCorners = manager.getWallCornerList();
        List<Vector3> windowCorners = manager.getWindowCornerList();
        List<Vector3> doorCorners = manager.getDoorCornerList();

        BuildFloor();
        BuildCeiling();
        BuildWalls(wallCorners);
        BuildWindows(windowCorners);
        BuildDoors(doorCorners);
        PutLight(wallCorners);
    }

    void Update()
    {

    }

    public void BuildFloor()
    {
        for (float i = 0; i < floorSide / floorSize; i += 1)
        {
            for (float j = 0; j < floorSide / floorSize; j += 1)
            {
                Vector3 middle = new Vector3(
                    i * floorSize - floorSide / 2.0f,
                    0.0f,
                    j * floorSize - floorSide / 2.0f);

                GameObject newFloor = Instantiate(floor, new Vector3(middle.x, middle.y, middle.z), Quaternion.identity, floorParent.transform) as GameObject;
            }
        }
    }

    public void BuildCeiling()
    {
        for (float i = 0; i < floorSide / floorSize; i += 1)
        {
            for (float j = 0; j < floorSide / floorSize; j += 1)
            {
                Vector3 middle = new Vector3(
                    i * floorSize - floorSide / 2.0f,
                    wallHeight,
                    j * floorSize - floorSide / 2.0f);

                GameObject newFloor = Instantiate(
                    ceiling,
                    new Vector3(middle.x, middle.y, middle.z),
                    Quaternion.Euler(new Vector3(0.0f, 0.0f, 180.0f)),
                    ceilingParent.transform) as GameObject;
            }
        }
    }

    public void BuildWalls(List<Vector3> wallCorners)
    {
        if (wallCorners != null)
        {
            for (int i = 0; i < wallCorners.Count - 1; i++)
            {
                Vector3 firstCorner = new Vector3(
                    (wallCorners[i].x + sizeOffset) / sizeCoefficient,
                    (wallCorners[i].y + sizeOffset) / sizeCoefficient,
                    wallCorners[i].z);
                Vector3 secondCorner = new Vector3(
                    (wallCorners[i + 1].x + sizeOffset) / sizeCoefficient,
                    (wallCorners[i + 1].y + sizeOffset) / sizeCoefficient,
                    wallCorners[i + 1].z);

                Vector3 middle = new Vector3(
                    (firstCorner.x + secondCorner.x) / 2.0f,
                    wallHeight / 2.0f,
                    (firstCorner.y + secondCorner.y) / 2.0f);

                Vector3 direction = new Vector3(
                    Mathf.Abs(firstCorner.x - secondCorner.x),
                    Mathf.Abs(firstCorner.z - secondCorner.z),
                    Mathf.Abs(firstCorner.y - secondCorner.y));

                Vector3 rotation = new Vector3(0.0f, 0.0f, 0.0f);

                if (direction.x >= 0.01f)
                {
                    rotation.y = 90;
                }

                float distance = Mathf.Sqrt(
                    Mathf.Pow((firstCorner.x - secondCorner.x), 2) +
                    Mathf.Pow((firstCorner.y - secondCorner.y), 2));

                GameObject newWall = Instantiate(wall, new Vector3(middle.x, middle.y, middle.z), Quaternion.Euler(rotation)) as GameObject;
                newWall.transform.localScale = new Vector3(0.02f, wallHeight, distance);
            }
        }
    }

    public void BuildWindows(List<Vector3> windowCorners)
    {
        if (windowCorners != null)
        {
            for (int i = 0; i < windowCorners.Count - 1; i += 2)
            {
                Vector3 firstCorner = new Vector3(
                    (windowCorners[i].x + sizeOffset) / sizeCoefficient,
                    (windowCorners[i].y + sizeOffset) / sizeCoefficient,
                    windowCorners[i].z);
                Vector3 secondCorner = new Vector3(
                    (windowCorners[i + 1].x + sizeOffset) / sizeCoefficient,
                    (windowCorners[i + 1].y + sizeOffset) / sizeCoefficient,
                    windowCorners[i + 1].z);

                Vector3 middle = new Vector3(
                    (firstCorner.x + secondCorner.x) / 2.0f,
                    windowHeight / 2.0f + 0.8f,
                    (firstCorner.y + secondCorner.y) / 2.0f);

                Vector3 direction = new Vector3(
                    Mathf.Abs(firstCorner.x - secondCorner.x),
                    Mathf.Abs(firstCorner.z - secondCorner.z),
                    Mathf.Abs(firstCorner.y - secondCorner.y));

                Vector3 rotation = new Vector3(0.0f, 0.0f, 0.0f);

                if (direction.x >= 0.01f)
                {
                    rotation.y = 90;
                }

                float distance = Mathf.Sqrt(
                    Mathf.Pow((firstCorner.x - secondCorner.x), 2) +
                    Mathf.Pow((firstCorner.y - secondCorner.y), 2));

                GameObject newWindow = Instantiate(window, new Vector3(middle.x, middle.y, middle.z), Quaternion.Euler(rotation)) as GameObject;
                newWindow.transform.localScale = new Vector3(0.04f, windowHeight, windowWidth * distance);
            }
        }
    }

    public void BuildDoors(List<Vector3> doorCorners)
    {
        if (doorCorners != null)
        {
            for (int i = 0; i < doorCorners.Count - 1; i += 2)
            {
                Vector3 firstCorner = new Vector3(
                    (doorCorners[i].x + sizeOffset) / sizeCoefficient,
                    (doorCorners[i].y + sizeOffset) / sizeCoefficient,
                    doorCorners[i].z);
                Vector3 secondCorner = new Vector3(
                    (doorCorners[i + 1].x + sizeOffset) / sizeCoefficient,
                    (doorCorners[i + 1].y + sizeOffset) / sizeCoefficient,
                    doorCorners[i + 1].z);

                Vector3 middle = new Vector3(
                    (firstCorner.x + secondCorner.x) / 2.0f,
                    doorHeight / 2.0f,
                    (firstCorner.y + secondCorner.y) / 2.0f);

                Vector3 direction = new Vector3(
                    Mathf.Abs(firstCorner.x - secondCorner.x),
                    Mathf.Abs(firstCorner.z - secondCorner.z),
                    Mathf.Abs(firstCorner.y - secondCorner.y));

                Vector3 rotation = new Vector3(0.0f, 0.0f, 0.0f);

                if (direction.x >= 0.01f)
                {
                    rotation.y = 90;
                }

                float distance = Mathf.Sqrt(
                    Mathf.Pow((firstCorner.x - secondCorner.x), 2) +
                    Mathf.Pow((firstCorner.y - secondCorner.y), 2));

                GameObject newDoor = Instantiate(door, new Vector3(middle.x, middle.y, middle.z), Quaternion.Euler(rotation)) as GameObject;
                newDoor.transform.localScale = new Vector3(0.04f, doorHeight, doorWidth * distance);

                player.transform.localPosition = new Vector3(middle.x, 0.0f, middle.z);
            }

        }
    }

    public void PutLight(List<Vector3> wallCorners)
    {
        if (wallCorners != null)
        {
            for (int i = 0; i < wallCorners.Count; i++)
            {
                Vector3 firstCorner = new Vector3(
                    (wallCorners[i].x + sizeOffset) / sizeCoefficient,
                    wallHeight - 0.2f,
                    (wallCorners[i].y + sizeOffset) / sizeCoefficient);

                GameObject newLight = Instantiate(light, firstCorner, Quaternion.identity) as GameObject;
            }
        }
    }
}
