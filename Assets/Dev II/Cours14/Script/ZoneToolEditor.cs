
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
    private int _draggedIndex = -1;
    private bool _isDragging = false;


    //Called when the ZoneTool inpector window is showned
    private void OnEnable()
    {
        //return the "target" , (The Zone tool script that was clicked on)
        _zoneTool = (ZoneTool)target;
        // Get The current scene view and adjust it's parameters
        SceneView view = SceneView.lastActiveSceneView;
        //set the scene view to 2D
        view.in2DMode = true;

        if (view != null)
        {
            //set the sceneView camera to orthographic
            view.orthographic = true;
        }
        _zoneTool.Init();
        //Set the size of the scene View.
        SceneView.lastActiveSceneView.size = 45;
    }

    //Called when the ZoneTool inpector window is closed
    private void OnDisable()
    {
        // Reset the scene view swttings
        SceneView view = SceneView.lastActiveSceneView;
        if (view != null)
        {
            view.orthographic = false;
        }
        view.in2DMode = false;
        HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Keyboard));
    }

    private int GetClosestIndex(Vector3 mousePos)
    {
        var points = _zoneTool.GetAllPointList()[_zoneTool.GetCurrentZoneIndex()];

        float minDist = 2.0f; // same as your collapse range
        int closest = -1;

        for (int i = 0; i < points.Count; i++)
        {
            float d = Vector3.Distance(points[i], mousePos);
            if (d < minDist)
            {
                minDist = d;
                closest = i;
            }
        }

        return closest;
    }


    //Called everytime something change in the scene view (the equivalent of the editor update)
    private void OnSceneGUI()
    {
        List<List<Vector3>> list = _zoneTool.GetAllPointList();
        HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));

        Vector3 Pos = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition).origin;
        Vector3 MouseWorldPos = new(Pos.x, Pos.y, 0);

        // --- RIGHT CLICK: remove closest point ---
        if (Event.current.type == EventType.MouseDown && Event.current.button == 1)
        {
            var points = _zoneTool.GetAllPointList()[_zoneTool.GetCurrentZoneIndex()];

            if (points.Count > 0)
            {
                float minDist = Mathf.Infinity;
                int closestIndex = -1;

                // Find closest point to mouse
                for (int i = 0; i < points.Count; i++)
                {
                    float d = Vector3.Distance(points[i], MouseWorldPos);
                    if (d < minDist)
                    {
                        minDist = d;
                        closestIndex = i;
                    }
                }

                // Remove it
                if (closestIndex != -1)
                {
                    points.RemoveAt(closestIndex);
                    _zoneTool.SetDirty();
                }
            }

            Event.current.Use(); // prevent SceneView context menu
        }




        // Left click → add point
        if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
        {
            _zoneTool.AddPointToZone(MouseWorldPos);
            _zoneTool.SetDirty();
        }

        Event e = Event.current;

        // --- START DRAG (Middle Mouse Button) ---
        if (e.type == EventType.MouseDown && e.button == 2)
        {
            // ⭐ THIS WAS MISSING ⭐
            _draggedIndex = GetClosestIndex(MouseWorldPos);

            if (_draggedIndex != -1)
            {
                _isDragging = true;
                e.Use();   // stop SceneView panning
            }
            else
            {
                _zoneTool.SetDirty();
            }
        }

        // --- DRAGGING ---
        if (_isDragging && e.type == EventType.MouseDrag && e.button == 2)
        {
            _zoneTool.MoveToClosestIncrement(MouseWorldPos);
            _zoneTool.SetDirty();
            e.Use();   // stop SceneView panning
        }

        // --- END DRAG ---
        if (e.type == EventType.MouseUp && e.button == 2)
        {
            _isDragging = false;
            _draggedIndex = -1;
        }

        DrawAllZone(list);
    }


    private void DrawAllZone(List<List<Vector3>> pointList)
    {
        for (int j = 0; j < pointList.Count; j++)
        {
            List<Vector3> list = pointList[j];
            bool isCurrent = _zoneTool.GetCurrentZoneIndex() == j;

            // Draw all consecutive lines
            for (int i = 0; i < list.Count - 1; i++)
            {
                DrawLineBetweenNod(list[i], list[i + 1], isCurrent);
            }

            // Draw last → first (closing the loop)
            if (list.Count > 1)
            {
                DrawLineBetweenNod(list[list.Count - 1], list[0], isCurrent);
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
        //Generate a Int input field ,  you can listen to the entered Value with it's return value
        int newValue = EditorGUILayout.IntField(_zoneTool._zoneIndex, GUILayout.Width(150));
        _zoneTool._zoneIndex = newValue;
        GUILayout.EndVertical();
        GUI.color = basicColor;
        // Draw all the element of the base inspector in that case of ZoneTool
        DrawDefaultInspector();
    }


}
