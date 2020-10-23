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
    public Transform[,] levelAssetPos = new Transform[lines, columns];
    public float assetSpacing = .1f;

    public GameObject[,] wallsValues = new GameObject[lines, columns];

    public void CreateLevelWalls(int x, int y)
    {
        GameObject curWall = GameObject.Instantiate(Resources.Load("Wall", typeof(GameObject))) as GameObject;
        Debug.Log(curWall.transform.position);
        curWall.transform.position = new Vector3(levelAssetPos[x,y].position.y, levelAssetPos[x, y].position.x, 0);
        wallsValues[x, y] = curWall;
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

    public void NullCheck(int x, int y)
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

    public void AssignAssetsPositions()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                float assetPosx = i + assetSpacing;
                Debug.Log("assetPosx : " + assetPosx);
                float assetPosy = j + assetSpacing;
                Debug.Log("assetPosy : " + assetPosy);
                levelAssetPos[i, j].position = levelOrigin.position + new Vector3(assetPosx, assetPosy, 0);
                Debug.Log("levelAssetPos : " + levelAssetPos[i, j].position);
            }
        }
    }
}
