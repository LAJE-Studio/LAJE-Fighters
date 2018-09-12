using LAJEFighters.Scripts.Combat;
using LAJEFighters.Scripts.Combat.Animation;
using LAJEFighters.Scripts.Utilities.Math;
using LAJEFighters.Scripts.Utilities.Properties;
using UnityEngine;

namespace LAJEFighters.Scripts.Entity {
    public class LivingEntity : Entity, ICombatant {
        [SerializeField]
        private CombatantAnimatorUpdater animatorUpdater;

        [SerializeField]
        private UInt32Property maxHealth = 20;

        [SerializeField]
        private uint health;

        public uint Health {
            get {
                return health;
            }
        }

        public UInt32Property MaxHealth {
            get {
                return maxHealth;
            }
        }

        public float HealthPercentage {
            get {
                return (float) health / maxHealth.Value;
            }
            set {
                var candidate = (uint) (value * maxHealth.Value);
                health = UnsignedMath.Clamp(candidate, 0, maxHealth.Value);
            }
        }

        public bool IsDead {
            get {
                return health == 0;
            }
        }

        public void Kill() {
            health = 0;
        }

        public void Damage(DamageContext context) {
            //TODO implement:
        }

        public CombatantAnimatorUpdater AnimatorUpdater {
            get {
                return animatorUpdater;
            }
        }
    }
}