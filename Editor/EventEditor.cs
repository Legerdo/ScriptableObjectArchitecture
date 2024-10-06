using UnityEngine;
using UnityEditor;

namespace ScriptableObjectArchitecture
{
    [CustomEditor(typeof(NonGenericGameEvent), editorForChildClasses: true)]
    public class EventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            NonGenericGameEvent e = target as NonGenericGameEvent;
            if (GUILayout.Button("Raise"))
                e.Raise();
        }
    }
}