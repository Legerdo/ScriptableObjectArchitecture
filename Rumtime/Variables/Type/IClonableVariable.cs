using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
    public interface IClonableVariable
    {
        public void Clone();
        public void DestroyInstance();
    }
}