using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(LevelEditor))]
public class LevelEditorInspector : Editor
{
    LevelEditor currentLevel;

    public Color[,] colorList = new Color[LevelEditor.lines, LevelEditor.columns];

    public bool enemiesButton = false;
    public bool wallsButton = false;
    public bool eraseButton = false;

    private void OnEnable()
    {
        currentLevel = (target as LevelEditor);

        for (int i = 0; i < LevelEditor.lines; i++)
        {
            for (int j = 0; j < LevelEditor.columns; j++)
            {
                colorList[i, j] = Color.white;
            }
        }
    }

    public override void OnInspectorGUI()
    {
        Color oldColor = GUI.color;

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Enemies"))
        {
            enemiesButton = true;
            wallsButton = false;
            eraseButton = false;
        }

        if (GUILayout.Button("Walls"))
        {
            wallsButton = true;
            enemiesButton = false;
            eraseButton = false;
        }

        if (GUILayout.Button("Erase"))
        {
            eraseButton = true;
            wallsButton = false;
            enemiesButton = false;
        }
        EditorGUILayout.EndHorizontal();

        for (int i = 0; i < LevelEditor.lines; i++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int j = 0; j < LevelEditor.columns; j++)
            {
                GUI.color = colorList[i, j];

                if (GUILayout.Button(""))
                {
                    if(colorList[i,j] == Color.white)
                    {
                        if (wallsButton)
                        {
                            colorList[i, j] = Color.black;
                            currentLevel.CreateLevelWalls(i, j);
                        }

                        if (enemiesButton)
                        {
                            colorList[i, j] = Color.red;
                        }

                        if (eraseButton)
                        {
                            colorList[i, j] = Color.white;
                        }
                    }
                    else
                    {
                        if (wallsButton && colorList[i, j] == Color.black)
                        {
                            colorList[i, j] = Color.white;
                        }
                        else if (wallsButton && colorList[i, j] != Color.black)
                        {
                            colorList[i, j] = Color.black;
                            currentLevel.CreateLevelWalls(i, j);
                        }

                        if (enemiesButton && colorList[i, j] == Color.red)
                        {
                            colorList[i, j] = Color.white;
                        }
                        else if (enemiesButton && colorList[i, j] != Color.red)
                        {
                            colorList[i, j] = Color.red;
                        }

                        if (eraseButton)
                        {
                            colorList[i, j] = Color.white;
                        }
                    }
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.EndHorizontal();
    }

    private void OnDisable()
    {
        
    }
}
