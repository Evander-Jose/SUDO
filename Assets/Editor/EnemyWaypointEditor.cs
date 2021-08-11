using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WaypointPatrol))]
public class EnemyWaypointEditor : Editor
{
    SerializedProperty waypoints;
    SerializedProperty controller;
    SerializedProperty movementSpeed;
    private void OnEnable()
    {
        waypoints = serializedObject.FindProperty("waypoints");
        controller = serializedObject.FindProperty("controller");
        movementSpeed = serializedObject.FindProperty("movementSpeed");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        WaypointPatrol waypointPatrol = target as WaypointPatrol;

        EditorGUILayout.PropertyField(controller);
        EditorGUILayout.PropertyField(movementSpeed);
        EditorGUILayout.PropertyField(waypoints);

        if(GUILayout.Button("Create New Waypoint"))
        {
            waypointPatrol.AddWaypoint();    
        }

        
        serializedObject.ApplyModifiedProperties();
    }
}
