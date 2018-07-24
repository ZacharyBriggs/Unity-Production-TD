using System.Linq;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

/// <summary>
/// The following Editor Window will display all GameEventArgs Objects
/// and allow the use to manually invoke those events
/// It also shows all active listeners 
/// </summary>
public class GameEventEditorWindow : EditorWindow
{
    private List<GameEvent> GameEvents = new List<GameEvent>();

    [MenuItem("Tools/GameEventEditorWindow")]
    private static void Init()
    {
        var w = GetWindow(typeof(GameEventEditorWindow));
        w.Show();

    }

    private void OnEnable()
    {
        var assets = AssetDatabase.FindAssets("t:GameEvent")
            .Select(AssetDatabase.GUIDToAssetPath)
            .Select(AssetDatabase.LoadAssetAtPath<GameEvent>)
            .Where(gameevent => gameevent).ToList();
        GameEvents = new List<GameEvent>(assets);
    }


    private void OnInspectorUpdate()
    {
        Repaint();
    }

    private void OnGUI()
    {
        EditorGUILayout.Space();

        EditorGUILayout.TextField("GameEventArgs");
        DrawObjectsView();

        if (GUI.changed)
            Repaint();
    }

    private void DrawObjectsView()
    {
        EditorGUILayout.BeginVertical();

        foreach (var Event in GameEvents)
        {
            EditorGUILayout.BeginHorizontal();
            var fieldinfo = Event.GetType().GetField("_listeners", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var listeners = fieldinfo.GetValue(Event) as List<GameEventListener>;
                //= Event.listeners.Select(x => x.gameObject).ToList();
            
            EditorGUILayout.ObjectField(Event, typeof(GameEvent), false, GUILayout.Width(250));
            if (GUILayout.Button("Raise", GUILayout.Width(250)))
            {
                Event.Raise();
            }
            EditorGUILayout.EndHorizontal();


            EditorGUILayout.BeginVertical();
            EditorGUI.indentLevel++;
            listeners.ForEach(listener => EditorGUILayout.ObjectField(listener.gameObject, typeof(GameObject), false, GUILayout.Width(250)));
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.EndVertical();
    }
}