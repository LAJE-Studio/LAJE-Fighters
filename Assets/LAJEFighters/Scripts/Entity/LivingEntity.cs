using LAJEFighters.Scripts.Combat;
using LAJEFighters.Scripts.Combat.Animation;
using LAJEFighters.Scripts.Utilities.Math;
using LAJEFighters.Scripts.Utilities.Properties;
using UnityEngine;
using UnityUtilities.Misc;

namespace LAJEFighters.Scripts.Entity {
    public class LivingEntity : Entity, ICombatant {
        [SerializeField]
        private CombatantAnimatorUpdater animatorUpdater;

        [SerializeField]
        private UInt32Property maxHealth = 20;

        [SerializeField]
        private uint health;

        [SerializeField]
        private bool invulnerable;

        [SerializeField]
        private FloatProperty damageMultiplier;

        public Transform Transform {
            get {
                return transform;
            }
        }

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

        public bool Invulnerable {
            get {
                return invulnerable;
            }
        }

        public void Kill() {
            health = 0;
        }

        public void Damage(DamageContext context) {
            //TODO implement:
        }

        public Direction CurrentDirection {
            get;
            set;
        }

        public CombatantAnimatorUpdater AnimatorUpdater {
            get {
                return animatorUpdater;
            }
        }

        public FloatProperty DamageMultiplier {
            get {
                return damageMultiplier;
            }
        }
    }
}