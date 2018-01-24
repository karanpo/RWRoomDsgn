using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderManager : MonoBehaviour
{

    private static bool isWall;
    private static bool isWindow;
    private static bool isDoor;
    private static int corners = 0;
    private static int stepIndex = 0;
    private static string[] steps;
    private static Vector3 prevLocation;
    private static Vector3 firstCornerLocation;
    private static Vector3 prevWindowLocaton;
    private static Vector3 prevDoorLocaton;
    private static int windowCornersCount = 0;
    private static int doorCornersCount = 0;
    private static List<Vector3> wallCorners = new List<Vector3>();
    private static List<Vector3> windowCorners = new List<Vector3>();
    private static List<Vector3> doorCorners = new List<Vector3>();

    private bool clean;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void setClean(bool cle)
    {
        clean = cle;
    }

    public void addWallToList(Vector3 corner)
    {
        if (clean)
        {
            wallCorners = new List<Vector3>();
            windowCorners = new List<Vector3>();
            doorCorners = new List<Vector3>();
            prevLocation = new Vector3();
            firstCornerLocation = new Vector3();
            prevWindowLocaton = new Vector3();
            prevDoorLocaton = new Vector3();
            doorCornersCount = 0;
            windowCornersCount = 0;
            corners = 0;
            setClean(false);
        }

        if (wallCorners.Count > 0)
        {
            if (!wallCorners[wallCorners.Count - 1].Equals(corner))
            {
                wallCorners.Add(corner);
            }
        }
        else
        {
            wallCorners.Add(corner);
        }
    }

    public List<Vector3> getWallCornerList()
    {
        return wallCorners;
    }
    public void addWindowToList(Vector3 corner)
    {
        if (windowCorners.Count > 0) {
            if (!windowCorners[windowCorners.Count - 1].Equals(corner))
            {
                windowCorners.Add(corner);
            }
        }
        else
        {
            windowCorners.Add(corner);
        }
    }

    public List<Vector3> getWindowCornerList()
    {
        return windowCorners;
    }
    public void addDoorToList(Vector3 corner)
    {
        if (doorCorners.Count > 0)
        {
            if (!doorCorners[doorCorners.Count - 1].Equals(corner))
            {
                doorCorners.Add(corner);
            }
        }
        else
        {
            doorCorners.Add(corner);
        }
    }

    public List<Vector3> getDoorCornerList()
    {
        return doorCorners;
    }

    public void setIsWall(bool state)
    {
        Debug.Log("Wall setted");
        isWall = state;
    }
    public bool getIsWall()
    {
        Debug.Log("Get wall: " + isWall.ToString());
        return isWall;
    }
    public void setIsDoor(bool state)
    {
        isDoor = state;
    }
    public bool getIsDoor()
    {
        return isDoor;
    }
    public void setIsWindow(bool state)
    {
        Debug.Log("Window setted");
        isWindow = state;
    }

    public bool getIsWindow()
    {
        Debug.Log("Get window: " + isWindow.ToString());
        return isWindow;
    }

    public void setCorners()
    {
        corners++;
    }
    public int getCorners()
    {
        return corners;
    }

    public void setWindowCorners()
    {
        windowCornersCount++;
    }
    public int getWindowCorners()
    {
        return windowCornersCount;
    }
    public void setDoorCorners()
    {
        doorCornersCount++;
    }
    public int getDoorCorners()
    {
        return doorCornersCount;
    }
    public void setStep(string step)
    {
        steps[stepIndex] = step;
        stepIndex++;
    }
    public string getStep()
    {
        return steps[stepIndex - 1];
    }
    public void setFirstCornerLocation(Vector3 location)
    {
        firstCornerLocation = location;
    }

    public Vector3 getFirstCornerLocation()
    {
        return firstCornerLocation;
    }

    public void setPrevLocation(Vector3 location)
    {
        prevLocation = location;
    }

    public Vector3 getPrevLocation()
    {
        return prevLocation;
    }

    public void setPrevWindowCorner(Vector3 location)
    {
        prevWindowLocaton = location;
    }
    public Vector3 getPrevWindowCorner()
    {
        return prevWindowLocaton;
    }
    public void setPrevDoorCorner(Vector3 location)
    {
        prevDoorLocaton = location;
    }
    public Vector3 getPrevDoorCorner()
    {
        return prevDoorLocaton;
    }

}
