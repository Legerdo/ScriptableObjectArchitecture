using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(fileName = "NewBoolVariable", menuName = "SOA/Variable/BoolVariable")]
    public sealed class BoolVariable : GenericVariable<bool>
    {
        public override void ApplyChange(bool newValue)
        {
            SetValue(newValue);
        }
    }
}
