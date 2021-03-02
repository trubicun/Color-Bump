using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Spawner spawner = (Spawner)target;

        if (spawner.SpawnInEditor) spawner.Spawn();

        if (GUILayout.Button("Spawn"))
        {
            spawner.Spawn();
        }
    }
}
