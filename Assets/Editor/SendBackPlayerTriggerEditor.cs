using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SendPlayerBackTrigger))]
public class SendBackPlayerTriggerEditor : Editor
{
    SerializedProperty spawnpoint;

    private void OnEnable()
    {
        spawnpoint = serializedObject.FindProperty("spawnpoint");
    }

    public override void OnInspectorGUI()
    {
        SendPlayerBackTrigger trigger = target as SendPlayerBackTrigger;

        serializedObject.Update();

        EditorGUILayout.PropertyField(spawnpoint, new GUIContent("Spawnpoint"));
        
        if (GUILayout.Button("Create New Spawnpoint"))
        {
            GameObject newBlank = new GameObject();
            newBlank.name = trigger.gameObject.name + "_" + "Player Spawnpoint";

            GameObject spawnpointGroups = GameObject.Find("PlayerSpawnpoints");
            if(spawnpointGroups == null)
            {
                spawnpointGroups = new GameObject("PlayerSpawnpoints");
            }

            newBlank.transform.parent = spawnpointGroups.transform;
            newBlank.transform.localPosition = Vector3.zero;

            spawnpoint.objectReferenceValue = newBlank;
            
        }

        serializedObject.ApplyModifiedProperties();


    }
}
