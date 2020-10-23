using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelsManager : MonoBehaviour
{
    public static LevelsManager instance;

    public GameObject[] levelsList;

    private void Awake()
    {
        Init();
    }

    public virtual void Init()
    {
        instance = this;
    }

    private void Start()
    {
        GetAllPrefabs();
    }

    static void GetAllPrefabs()
    {
        Debug.Log("GetPrefabs");
        var allPrefabs = AssetDatabase.FindAssets("t : GameObject");

        foreach (var pref in allPrefabs)
        {
            var path = AssetDatabase.GUIDToAssetPath(pref);
            Debug.Log(path);
        }
    }
}
