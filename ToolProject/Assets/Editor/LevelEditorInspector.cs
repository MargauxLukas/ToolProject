using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(LevelEditor))]
public class LevelEditorInspector : Editor
{
    LevelEditor currentLevel;

    SerializedProperty enemiesColor_s;
    SerializedProperty wallsColor_s;

    public int[,] buttonType = new int[LevelEditor.lines, LevelEditor.columns];
    public int button;
    public string levelName;

    private void OnEnable()
    {
        //levelOrigin = serializedObject.FindProperty(nameof(LevelEditor.levelOrigin));
        currentLevel = (target as LevelEditor);

        currentLevel.levelOrigin = Object.FindObjectOfType<LevelOriginPointer>().transform;
        currentLevel.AssignAssetsPositions();
        currentLevel.assetSpacing = 1.48f;

        enemiesColor_s = serializedObject.FindProperty(nameof(LevelEditor.enemiesColor));
        wallsColor_s = serializedObject.FindProperty(nameof(LevelEditor.wallsColor));

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
        float oldLabel = EditorGUIUtility.labelWidth;

        #region Draw Enemies/Walls Buttons
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Enemies"))
        {
            button = 2;
        }

        if (GUILayout.Button("Walls"))
        {
            button = 1;
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        #region Draw Enemies/Walls Colors
        //EditorGUIUtility.labelWidth /= 2000;
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PropertyField(enemiesColor_s, GUIContent.none) ;
        EditorGUILayout.PropertyField(wallsColor_s, GUIContent.none);
        EditorGUILayout.EndHorizontal();
        //EditorGUIUtility.labelWidth = oldLabel;
        #endregion

        #region Draw Erase Button
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Erase"))
        {
            button = 0;
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        #region Draw Level Editor Tab
        for (int i = 0 ; i < LevelEditor.lines; i++)
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
                            currentLevel.DeleteGameObject(i, j, button);
                            break;

                        case 1:
                            currentLevel.NullCheckWalls(i, j);
                            break;

                        case 2:
                            currentLevel.NullCheckEnemies(i, j);
                            break;
                    }

                    buttonType[i, j] = button;
                }
            }
            EditorGUILayout.EndHorizontal();
        }
        GUI.color = oldColor;
        #endregion

        #region Draw Level Origin Transform Field
        EditorGUILayout.BeginHorizontal();
        Transform lvlOriginTransform = EditorGUILayout.ObjectField("Set Level Origin", currentLevel.levelOrigin, typeof(Transform), true) as Transform;
        EditorGUILayout.EndHorizontal();
        #endregion

        #region Draw Level Name/Save Fields
        EditorGUILayout.BeginHorizontal();
        name = EditorGUILayout.TextField("Enter Level Name", name);

        if(GUILayout.Button("Save Level"))
        {
            currentLevel.SaveLevel(name);
        }
        EditorGUILayout.EndHorizontal();
        #endregion
    }

    private void OnDisable()
    {
        
    }
}
