using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(fileName = "NewStringVariable", menuName = "SOA/Variable/StringVariable")]
    public sealed class StringVariable : GenericVariable<string>
    {
        public override void ApplyChange(string newString)
        {
            SetValue(newString);
        }
    }
}
