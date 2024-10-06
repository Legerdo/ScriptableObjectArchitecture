using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(fileName = "NewIntVariable", menuName = "SOA/Variable/IntVariable")]
    public sealed class IntVariable : GenericVariable<int>
    {
        public int minValue;
        public int maxValue;

        // 각 ability의 modifier를 추적하는 딕셔너리
        private Dictionary<string, int> abilityModifiers = new Dictionary<string, int>();

        private int ClampedValue(int value)
        {
            return Mathf.Clamp(value, minValue, maxValue);
        }

        public override int Value
        {
            get => ClampedValue(base.value + GetTotalModifier());
            set => base.value = ClampedValue(value);
        }

        public override void SetValue(int newValue)
        {
            base.value = ClampedValue(newValue);
        }

        // 총 modifier 값을 계산
        public int GetTotalModifier()
        {
            int total = 0;
            foreach (var modifier in abilityModifiers.Values)
            {
                total += modifier;
            }
            return total;
        }

        // Ability의 modifier를 설정하거나 업데이트
        public void SetAbilityModifier(string abilityName, int modifierValue)
        {
            abilityModifiers[abilityName] = modifierValue;
        }

        // 특정 Ability의 modifier를 제거
        public void RemoveAbilityModifier(string abilityName)
        {
            if (abilityModifiers.ContainsKey(abilityName))
            {
                abilityModifiers.Remove(abilityName);
            }
        }

        protected override void CleanupRuntimeData()
        {
            base.CleanupRuntimeData();
            ClearAllModifiers();
        }

        // 모든 Ability의 modifier를 제거
        public void ClearAllModifiers()
        {
            abilityModifiers.Clear();
        }

        public override int GetMax()
        {
            return maxValue;
        }

        public override int GetMin()
        {
            return minValue;
        }

        #if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();

            if (initialValue < minValue)
            {
                initialValue = minValue;
            }

            if (value < minValue)
            {
                value = minValue;
            }
        }
        #endif
        
        public override void ApplyChange(int amount)
        {
            SetValue(Value + amount);
        }
    }
}