using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(fileName = "NewVector3Variable", menuName = "SOA/Variable/Vector3Variable")]
    public class Vector3Variable : GenericVariable<Vector3>
    {
        public override void ApplyChange(Vector3 newVector3)
        {
            SetValue(newVector3);
        }
    }
}