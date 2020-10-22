using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Level Asset", menuName = "Level Editor/New Level Asset", order = 9)]
public class LevelEditor : ScriptableObject
{
    public static int lines = 10;
    public static int columns = 6;

    public GameObject[,] wallsValues = new GameObject[lines, columns];

    public void CreateLevelWalls(int x, int y)
    {
        GameObject curWall = GameObject.Instantiate(Resources.Load("Wall", typeof(GameObject))) as GameObject;
        curWall.transform.position = new Vector2(y, x);
        wallsValues[x, y] = curWall;
    }
}
