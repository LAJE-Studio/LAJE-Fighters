using UnityEngine;

namespace LAJEFighters.Scripts.Combat.Skills {
    public abstract class ActiveSkill : ScriptableObject {
        public abstract void Execute(ICombatant combatant);
    }

    public abstract class Attack : ActiveSkill, IDamageSource {
        public abstract uint Damage {
            get;
        }
    }
}