using UnityEngine;
using Newtonsoft.Json;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(fileName = "New Float Variable", menuName = "SOA/Variable/FloatVariable")]
    public class FloatVariable : GenericVariable<float>
    {
        [JsonIgnore]
        public float minValue;

        [JsonIgnore]
        public GenericReference<float, FloatVariable> maxValue;

        public override float Value
        {
            get => base.Value;
            set => base.Value = Mathf.Clamp(value, minValue, maxValue.Value);
        }

        public override void SetValue(float newValue)
        {
            base.SetValue(Mathf.Clamp(newValue, minValue, maxValue.Value));
        }

        public override void ApplyChange(float amount)
        {
            SetValue(Value + amount);
        }

        public override float GetMax()
        {
            return maxValue.Value;
        }

        public override float GetMin()
        {
            return minValue;
        }
    }
}