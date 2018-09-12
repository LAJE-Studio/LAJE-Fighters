using LAJEFighters.Scripts.Utilities;
using UnityEngine;

namespace LAJEFighters.Scripts.Data {
    [CreateAssetMenu(menuName = "LAJEFighters/GlobalResources/GameResources")]
    public class GameResources : SingletonScriptableObject<GameResources> {
        public LayerMask WorldMask;
        public LayerMask DamageableMask;
    }
}