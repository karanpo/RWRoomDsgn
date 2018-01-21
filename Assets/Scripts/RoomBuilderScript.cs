using UnityEngine;
using System.Collections.Generic;

public class RoomBuilderScript : MonoBehaviour
{
    public GameObject wall;
    public GameObject window;
    public GameObject door;
    private float wallHeight = 3.0f;
    private float windowHeight = 1.5f;
    private float doorHeight = 2.5f;

    public void BuildRoom(List<Vector3> wallCorners, List<Vector3> windowCorners, List<Vector3> doorCorners)
    {
        BuildWalls(wallCorners);
        BuildWindows(windowCorners);
        BuildDoors(doorCorners);
    }

    public void BuildWalls(List<Vector3> wallCorners)
    {
        if (wallCorners != null)
        {
            for (int i = 0; i < wallCorners.Count - 1; i++)
            {
                Vector3 firstCorner = wallCorners[i];
                Vector3 secondCorner = wallCorners[i + 1];

                Vector3 middle = new Vector3(
                    (firstCorner.x + secondCorner.x) / 2.0f,
                    wallHeight / 2.0f,
                    (firstCorner.y + secondCorner.y) / 2.0f);

                Vector3 direction = new Vector3(
                    Mathf.Abs(firstCorner.x - secondCorner.x),
                    Mathf.Abs(firstCorner.z - secondCorner.z),
                    Mathf.Abs(firstCorner.y - secondCorner.y));

                Vector3 rotation = new Vector3(0.0f, 0.0f, 0.0f);

                if (direction.x > 0.0f)
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
        if (windowCorners == null)
        {
            for (int i = 0; i < windowCorners.Count - 1; i += 2)
            {
                Vector3 firstCorner = windowCorners[i];
                Vector3 secondCorner = windowCorners[i + 1];

                Vector3 middle = new Vector3(
                    (firstCorner.x + secondCorner.x) / 2.0f,
                    windowHeight / 2.0f + 1.0f,
                    (firstCorner.y + secondCorner.y) / 2.0f);

                Vector3 direction = new Vector3(
                    Mathf.Abs(firstCorner.x - secondCorner.x),
                    Mathf.Abs(firstCorner.z - secondCorner.z),
                    Mathf.Abs(firstCorner.y - secondCorner.y));

                Vector3 rotation = new Vector3(0.0f, 0.0f, 0.0f);

                if (direction.x > 0.0f)
                {
                    rotation.y = 90;
                    middle.x += 0.001f;
                }
                else
                {
                    middle.z += 0.001f;
                }

                float distance = Mathf.Sqrt(
                    Mathf.Pow((firstCorner.x - secondCorner.x), 2) +
                    Mathf.Pow((firstCorner.y - secondCorner.y), 2));

                GameObject newWindow = Instantiate(window, new Vector3(middle.x, middle.y, middle.z), Quaternion.Euler(rotation)) as GameObject;
                newWindow.transform.localScale = new Vector3(0.02f, windowHeight, distance);
            }
        }
    }

    public void BuildDoors(List<Vector3> doorCorners)
    {
        if (doorCorners == null)
        {
            for (int i = 0; i < doorCorners.Count - 1; i += 2)
            {
                Vector3 firstCorner = doorCorners[i];
                Vector3 secondCorner = doorCorners[i + 1];

                Vector3 middle = new Vector3(
                    (firstCorner.x + secondCorner.x) / 2.0f,
                    doorHeight / 2.0f,
                    (firstCorner.y + secondCorner.y) / 2.0f);

                Vector3 direction = new Vector3(
                    Mathf.Abs(firstCorner.x - secondCorner.x),
                    Mathf.Abs(firstCorner.z - secondCorner.z),
                    Mathf.Abs(firstCorner.y - secondCorner.y));

                Vector3 rotation = new Vector3(0.0f, 0.0f, 0.0f);

                if (direction.x > 0.0f)
                {
                    rotation.y = 90;
                    middle.x += 0.001f;
                }
                else
                {
                    middle.z += 0.001f;
                }

                float distance = Mathf.Sqrt(
                    Mathf.Pow((firstCorner.x - secondCorner.x), 2) +
                    Mathf.Pow((firstCorner.y - secondCorner.y), 2));

                GameObject newWindow = Instantiate(door, new Vector3(middle.x, middle.y, middle.z), Quaternion.Euler(rotation)) as GameObject;
                newWindow.transform.localScale = new Vector3(0.02f, doorHeight, distance);
            }
        }
    }
}
