using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ScriptableObjectArchitecture
{
    public class ScriptableObjectPlayMode : ScriptableObject
    {
        [SerializeField] private string guid;
        public string Guid => guid;

#if UNITY_EDITOR
        [TextArea] public string editorDescription;
#endif

        protected virtual void OnEnable()
        {
#if UNITY_EDITOR
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
#endif
        }

        protected virtual void OnDisable()
        {
#if UNITY_EDITOR
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
#endif
        }

        protected virtual void OnDestroy()
        {
        }

#if UNITY_EDITOR
        private void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            switch (state)
            {
                case PlayModeStateChange.EnteredPlayMode:
                    InitializeRuntimeData();
                    break;
                case PlayModeStateChange.ExitingPlayMode:
                    CleanupRuntimeData();
                    break;
            }
        }
#endif

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            if (string.IsNullOrEmpty(guid))
            {
                try
                {
                    guid = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(this));
                }
                catch (Exception e)
                {
                    Debug.LogError($"Error generating GUID for asset {name}: {e.Message}");
                }
            }
        }
#endif

        /// <summary>
        /// 플레이 모드 진입 시 런타임 데이터를 초기화하는 메서드
        /// </summary>
        protected virtual void InitializeRuntimeData()
        {
        }

        /// <summary>
        /// 플레이 모드 종료 시 런타임 데이터를 정리하는 메서드
        /// </summary>
        protected virtual void CleanupRuntimeData()
        {
        }
    }
}