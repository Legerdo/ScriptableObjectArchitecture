using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [Serializable]
    public class GenericReference<T, V> where V : GenericVariable<T>
    {
        public bool UseConstant = true;
        public T ConstantValue;
        public V Variable;

        public T Value
        {
            get { return UseConstant ? ConstantValue : (Variable != null ? Variable.Value : default); }
            set
            {
                if (UseConstant)
                {
                    ConstantValue = value;
                }
                else
                {
                    Variable.Value = value;
                }
            }
        }

        public static implicit operator T(GenericReference<T, V> reference)
        {
            return reference.Value;
        }        
    }
}