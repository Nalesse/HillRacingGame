using UnityEngine;
using System.Collections;
using Spawnables;
using UnityEditor;
namespace Editor
{
    [CustomEditor(typeof(Spawnable))]
    public class SpawnablesCustomEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
           
            Spawnable spawnableScript = (Spawnable)target;
            
            // Restores normal display for the rest of the vars
            EditorGUIUtility.labelWidth = 45;
            spawnableScript.prefab = (GameObject)EditorGUILayout.ObjectField("Prefab",spawnableScript.prefab, 
                typeof(GameObject), true, GUILayout.MaxWidth(150));
            EditorGUIUtility.labelWidth = 95;
            spawnableScript.positionOffset =
                EditorGUILayout.Vector3Field("Position Offset", spawnableScript.positionOffset);
            EditorGUIUtility.labelWidth = 120;
            spawnableScript.chanceToSpawn = EditorGUILayout.FloatField("Chance To Spawn",spawnableScript.chanceToSpawn,
                GUILayout.MaxWidth(180));
            
            GUILayout.Space(10);

            // Puts the random x,y and z vars next to each other 
            // X layout
            EditorGUILayout.LabelField("Randomness", EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();
            EditorGUIUtility.labelWidth = 45;
            spawnableScript.minX = EditorGUILayout.FloatField("Min X",spawnableScript.minX);
            spawnableScript.maxX = EditorGUILayout.FloatField("Max X",spawnableScript.maxX);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            
            // Cant use these variables until I find a way to make the object match the slope angel in every situation 
            
            // GUILayout.Space(3);
            // Y layout
            /*GUILayout.BeginHorizontal();
            EditorGUIUtility.labelWidth = 45;
            spawnableScript.minY = EditorGUILayout.FloatField("Min Y",spawnableScript.minY);
            spawnableScript.maxY = EditorGUILayout.FloatField("Max Y",spawnableScript.maxY);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            
            GUILayout.Space(3);
            // Z layout
            GUILayout.BeginHorizontal();
            EditorGUIUtility.labelWidth = 45;
            spawnableScript.minZ = EditorGUILayout.FloatField("Min Z",spawnableScript.minZ);
            spawnableScript.maxZ = EditorGUILayout.FloatField("Max Z",spawnableScript.maxZ);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();*/

        }
    }
}
