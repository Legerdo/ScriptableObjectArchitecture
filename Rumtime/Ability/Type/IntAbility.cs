using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(fileName = "IntAbility", menuName = "SOA/Ability/IntAbility")]
    public class IntAbility : AbilityBase
    {
        private enum IncrementType
        {
            Additive,
            Multiplicative
        }

        [SerializeField]
        private IntVariable value;

        [SerializeField]
        private IncrementType incrementType;

        [SerializeField]
        private bool isPercent = false;

        [SerializeField]
        private GenericReference<int, IntVariable> increment;

        public override void Apply()
        {
            if (value == null)
            {
                Debug.LogError($"{nameof(IntAbility)}: 'value' is not assigned.");
                return;
            }

            if (increment == null)
            {
                Debug.LogError($"{nameof(IntAbility)}: 'increment' is not assigned.");
                return;
            }

            base.Apply();

            int baseValue = value.Value - value.GetTotalModifier();
            int changeValue;

            switch (incrementType)
            {
                case IncrementType.Additive:
                    changeValue = increment.Value * ApplyCount;
                    break;
                case IncrementType.Multiplicative:
                    float factor = isPercent ? 1 + (increment.Value / 100.0f) : increment.Value;
                    float multipliedValue = baseValue * Mathf.Pow(factor, ApplyCount);
                    changeValue = Mathf.RoundToInt(multipliedValue - baseValue);
                    break;
                default:
                    Debug.LogWarning($"{nameof(IntAbility)}: Unsupported IncrementType.");
                    changeValue = 0;
                    break;
            }

            value.SetAbilityModifier(abilityName, changeValue);
        }

        public override void Reset()
        {
            base.Reset();
            
            if (value != null)
            {
                value.RemoveAbilityModifier(abilityName);
            }
        }

        public override string GetDescription()
        {
            return string.Format(Description, increment != null ? increment.Value.ToString() : "");
        }
    }
}