using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(fileName = "NewVector2Variable", menuName = "SOA/Variable/Vector2Variable")]
    public class Vector2Variable : GenericVariable<Vector2>
    {
        public override void ApplyChange(Vector2 newVector2)
        {
            SetValue(newVector2);
        }
    }
}