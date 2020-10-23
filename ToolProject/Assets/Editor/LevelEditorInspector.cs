using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(LevelEditor))]
public class LevelEditorInspector : Editor
{
    LevelEditor currentLevel;

    public int[,] buttonType = new int[LevelEditor.lines, LevelEditor.columns];
    public int button;
    public string levelName;

    private void OnEnable()
    {
        //levelOrigin = serializedObject.FindProperty(nameof(LevelEditor.levelOrigin));
        currentLevel = (target as LevelEditor);

        currentLevel.levelOrigin = Object.FindObjectOfType<LevelOriginPointer>().transform;
        currentLevel.AssignAssetsPositions();

        for (int i = 0; i < LevelEditor.lines; i++)
        {
            for (int j = 0; j < LevelEditor.columns; j++)
            {
                buttonType[i, j] = 0;
            }
        }
    }

    public override void OnInspectorGUI()
    {
        Color oldColor = GUI.color;

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Enemies"))
        {
            button = 2;
        }

        if (GUILayout.Button("Walls"))
        {
            button = 1;
        }

        if (GUILayout.Button("Erase"))
        {
            button = 0;
        }
        EditorGUILayout.EndHorizontal();

        for (int i = LevelEditor.lines - 1; i >= 0; i--)
        {
            EditorGUILayout.BeginHorizontal();
            for (int j = 0; j < LevelEditor.columns; j++)
            {
                switch (buttonType[i,j])
                {
                    case 0:
                        GUI.color = Color.white;
                        break;

                    case 1:
                        GUI.color = Color.black;
                        break;

                    case 2:
                        GUI.color = Color.red;
                        break;
                }

                if (GUILayout.Button(""))
                {
                    switch (button)
                    {
                        case 0:
                            break;

                        case 1:
                            currentLevel.NullCheck(i, j);
                            break;

                        case 2:
                            break;
                    }

                    buttonType[i, j] = button;
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.BeginHorizontal();

        Transform lvlOriginTransform = EditorGUILayout.ObjectField("Set Level Origin", currentLevel.levelOrigin, typeof(Transform), true) as Transform;

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();

        name = EditorGUILayout.TextField("Enter Level Name", name);

        if(GUILayout.Button("Save Level"))
        {
            currentLevel.SaveLevel(name);
        }

        EditorGUILayout.EndHorizontal();
    }

    private void OnDisable()
    {
        
    }
}
