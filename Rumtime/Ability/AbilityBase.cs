using UnityEngine;

namespace ScriptableObjectArchitecture
{
    public abstract class AbilityBase : ScriptableObjectPlayMode
    {
        
        [SerializeField]
        protected string abilityName = "";

        [SerializeField]
        protected string description = "Enter a description for the ability.";

        public string Description => description;

        public int ApplyCount
        {
            get;
            protected set;
        }

        public virtual void Apply()
        {
            ApplyCount++;
        }

        protected override void CleanupRuntimeData()
        {
            Reset();
        }

        protected override void InitializeRuntimeData()
        {
            Reset();
        }

        public abstract string GetDescription();

        public virtual void Reset()
        {
            ApplyCount = 0;
        }

    }
}