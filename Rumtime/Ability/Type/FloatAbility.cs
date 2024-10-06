using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(fileName = "FloatAbility", menuName = "SOA/Ability/FloatAbility")]
    public class FloatAbility : AbilityBase
    {
        private enum IncrementType
        {
            Additive,
            Multiplicative,
        }

        [SerializeField]
        private FloatVariable value;

        [SerializeField]
        private IncrementType incrementType;

        [SerializeField]
        private bool isPercent = false;

        [SerializeField]
        private GenericReference<float, FloatVariable> increment;

        public override void Apply()
        {
            if ( incrementType == IncrementType.Additive )
            {
                value.ApplyChange(increment.Value);
            }   
            else
            {
                var factor = isPercent ? 1 + increment.Value / 100.0f : increment.Value;
                value.ApplyChange(value.Value * factor);
            }   

            base.Apply();      
        }

        public override string GetDescription()
        {
            return string.Format(Description, increment.Value);
        }
    }
}