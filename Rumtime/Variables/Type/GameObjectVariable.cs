using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(fileName = "NewGameobjectVariable", menuName = "SOA/Variable/GameObjectVariable")]
    public sealed class GameObjectVariable : GenericVariable<GameObject>
    {
        public override void ApplyChange(GameObject newValue)
        {
            SetValue(newValue);
        }
    }
}
