using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DanieleFramework;

[CustomEditor(typeof(GridGeneration))]
public class GridEditor : Editor
{
   public override void OnInspectorGUI()
   {
        base.OnInspectorGUI();
        GridGeneration grid = (GridGeneration) target;
        if(GUILayout.Button("Generate grid"))
        {
            grid.GenerateGrid();
        }
        if(GUILayout.Button("Generate obstacles"))
        {
            grid.GenerateObstacles();
        }
        if(GUILayout.Button("Set goal"))
        {
            grid.SetGoal();
        }
        if (GUILayout.Button("Clear list"))
        {
            grid.ClearList();
        }
    }
}
