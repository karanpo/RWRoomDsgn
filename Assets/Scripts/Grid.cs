using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public struct Point
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    private int gridWidth = 1100;
    private int gridHeight = 1100;

    private int gridRows = 22;
    private int gridCols = 22;

    public Point[] gridNodes = new Point[22 * 22];
    
    void DesignGrid()
    {
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridCols; j++)
            {
                gridNodes[i * j].x = i * 50;
                gridNodes[i * j].y = j * 50;
            }
        }
    }

    // Use this for initialization
    void Start () {

        DesignGrid();        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetWall()
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
    }
    public void SetWindow() { }
    public void SetDoor() { }
    public void Save() { }
    public void Undo() { }
    public void Redo() { }
    public void Reset() { }
    public void Exit() { }
}
