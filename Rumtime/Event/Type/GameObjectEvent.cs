using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture      
{
    [CreateAssetMenu(fileName = "New Game Event", menuName = "SOA/Event/GameObjectEvent")]
    public class GameObjectEvent : GameEvent<GameObject>
    {

    }
}
