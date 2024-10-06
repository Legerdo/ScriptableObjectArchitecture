using UnityEngine;
using System.Collections.Generic;
using ScriptableObjectArchitecture;

namespace ScriptableObjectArchitecture
{
    [DisallowMultipleComponent]
    public class GameObjectEventManager : GameEventManager<GameObject>
    {
        protected override GameObject GetEventData()
        {
            return this.gameObject;
        }
    }
}