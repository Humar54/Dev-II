
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// ZoneToolEditor is a customEditor of ZoneTool
[CustomEditor(typeof(ZoneTool))]

//Must inherit from editor in order to access all the editor functionnalities
public class ZoneToolEditor : Editor
{
    //We create a reference to the script for which we want a custom editor
    private ZoneTool _zoneTool;

    //Called when the ZoneTool inpector window is showned
    private void OnEnable()
    {
        //return the "target" , (The Zone tool script that was clicked on)
        _zoneTool = (ZoneTool)target;
        // Get The current scene view and adjust it's parameters
        SceneView test = SceneView.lastActiveSceneView;
        //set the scene view to 2D
        test.in2DMode = true;

        if (test != null)
        {
            //set the sceneView camera to orthographic
            test.orthographic = true;
        }
        _zoneTool.Init();
        //Set the size of the scene View.
        SceneView.lastActiveSceneView.size = 45;
    }

    //Called when the ZoneTool inpector window is closed
    private void OnDisable()
    {
        // Reset the scene view swttings
        SceneView test = SceneView.lastActiveSceneView;
        if (test != null)
        {
            test.orthographic = false;
        }
        test.in2DMode = false;
        HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Keyboard));
    }

    //Called everytime something change in the scene view (the equivalent of the editor update)
    private void OnSceneGUI()
    {
        //Get the list of all points from the zone tool
        List<List<Vector3>> list = _zoneTool.GetAllPointList();
        HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));
        //Get The current Mouse position in the scene view
        Vector3 Pos = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition).origin;
        Vector3 MouseWorldPos = new(Pos.x, Pos.y, 0);

        // Listen for left click mouse event
        if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
        {
            _zoneTool.AddPointToZone(MouseWorldPos);
            _zoneTool.SetDirty();
        }
        DrawAllZone(list);
    }


    private void DrawAllZone(List<List<Vector3>> pointList)
    {
        for (int j = 0; j < pointList.Count; j++)
        {
            List<Vector3> list = pointList[j];

            for (int i = 0; i < list.Count - 1; i++)
            {
                DrawLineBetweenNod(list[i], list[i + 1], _zoneTool.GetCurrentZoneIndex() == j);
            }
        }
    }

    private void DrawLineBetweenNod(Vector3 Pos1, Vector3 Pos2, bool isCurrentZone)
    {
        if (isCurrentZone)
        {
            Handles.DrawBezier(Pos1, Pos2, Pos1, Pos2, Color.blue, null, 20);
        }
        else
        {
            Handles.DrawBezier(Pos1, Pos2, Pos1, Pos2, Color.blue, null, 5);
        }
    }


    //Replace the current ZoneTool inspector window with a new One
    public override void OnInspectorGUI()
    {
        //stock the UI base color in a variable
        Color basicColor = GUI.color;
        //Begin a Vertical Layout (all visual element in between the Begin and the End will be align vertically)
        GUILayout.BeginVertical();
        //Change the color of the UI element
        GUI.color = Color.red;

        //If the point list contains something display a destroy Current zone button
        if (_zoneTool.GetAllPointList().Count > 0)
        {
            //Create a button in the editor the button will call the function located inside the if statement
            if (GUILayout.Button("Clear Current Zone"))
            {
                _zoneTool.ClearCurrentZone();
            }
        }

        GUI.color = Color.green;
        if (GUILayout.Button("Create A New Zone "))
        {
            _zoneTool.CreateNewZone();
        }


        GUI.color = Color.grey;

        if (GUILayout.Button("Next Zone "))
        {
            _zoneTool.NextZone();
        }

        if (GUILayout.Button("Previous Zone "))
        {
            _zoneTool.PrevZone();
        }

        GUILayout.BeginHorizontal();
        //Generate a text field with a specified dimension
        GUILayout.TextField("Left Mouse Click", GUILayout.Width(150));
        GUILayout.TextField("-> Add Point", GUILayout.Width(150));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        //Generate a text field with a specified dimension
        GUILayout.TextField("Arrow key", GUILayout.Width(150));
        GUILayout.TextField("-> Move Camera Around", GUILayout.Width(150));

        GUILayout.EndHorizontal();

        int newValue = EditorGUILayout.IntField(_zoneTool._zoneIndex, GUILayout.Width(150));
        _zoneTool._zoneIndex = newValue;
        GUILayout.EndVertical();
        GUI.color = basicColor;
        // Draw all the element of the base inspector in that case of ZoneTool
        //DrawDefaultInspector();
    }


}
