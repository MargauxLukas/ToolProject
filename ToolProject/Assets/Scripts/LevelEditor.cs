using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Level Asset", menuName = "Level Editor/New Level Asset", order = 9)]
public class LevelEditor : ScriptableObject
{
    public static int lines = 10;
    public static int columns = 6;

    public Transform levelOrigin;
    public Vector2[,] levelAssetPos = new Vector2[lines, columns];
    public float assetSpacing = 1.48f;

    public GameObject[,] wallsValues = new GameObject[lines, columns];
    public GameObject[,] enemiesValues = new GameObject[lines, columns];

    public Color enemiesColor;
    public Color wallsColor;

    public void CreateLevelWalls(int x, int y)
    {
        GameObject curWall = GameObject.Instantiate(Resources.Load("Wall", typeof(GameObject))) as GameObject;
        curWall.transform.position = new Vector3(levelAssetPos[x,y].x, levelAssetPos[x,y].y, 0);
        wallsValues[x, y] = curWall;
    }

    public void CreateLevelEnemies(int x, int y)
    {
        GameObject curEnemy = GameObject.Instantiate(Resources.Load("Enemy Spaceship", typeof(GameObject))) as GameObject;
        curEnemy.transform.position = new Vector3(levelAssetPos[x,y].x, levelAssetPos[x,y].y, 0);
        enemiesValues[x, y] = curEnemy;
    }

    public void SaveLevel(string name)
    {
        GameObject level = new GameObject();
        level.name = name;

        foreach(GameObject go in wallsValues)
        {
            if(go != null)
            {
                go.transform.SetParent(level.transform);
            }
        }

        string localPath = "Assets/Assets/Prefabs/" + level.name + ".prefab";
        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
        PrefabUtility.SaveAsPrefabAssetAndConnect(level, localPath, InteractionMode.UserAction);
    }

    public void NullCheckWalls(int x, int y)
    {
        if(wallsValues[x, y] != null)
        {
            return;
        }
        else
        {
            CreateLevelWalls(x,y);
        }
    }

    public void NullCheckEnemies(int x, int y)
    {
        if (enemiesValues[x, y] != null)
        {
            return;
        }
        else
        {
            CreateLevelEnemies(x, y);
        }
    }

    public void AssignAssetsPositions()
    {
        for (int i =0 ; i < lines; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                float assetPosy = levelOrigin.position.y + (lines - 1 - i) * assetSpacing;
                float assetPosx = levelOrigin.position.x + (j * assetSpacing);
                levelAssetPos[i, j] = new Vector3(assetPosx, assetPosy, 0);
            }
        }
    }

    public void DeleteGameObject(int x, int y, int buttonType)
    {
        if(buttonType == 1)
        {
            DestroyImmediate(wallsValues[x, y]);
        }
        else if(buttonType == 2)
        {
            DestroyImmediate(enemiesValues[x, y]);
        }
        else
        {
            return;
        }
    }
}
