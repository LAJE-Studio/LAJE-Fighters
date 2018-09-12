using LAJEFighters.Scripts.Combat.Animation;
using LAJEFighters.Scripts.Utilities.Properties;
using UnityEngine;
using UnityUtilities.Misc;

namespace LAJEFighters.Scripts.Combat {
    public interface IDamageSource {
        uint Damage {
            get;
        }
    }

    public interface IDamageDealer {
        FloatProperty DamageMultiplier {
            get;
        }
    }

    public interface IDamageable {
        Transform Transform {
            get;
        }

        uint Health {
            get;
        }

        UInt32Property MaxHealth {
            get;
        }

        float HealthPercentage {
            get;
            set;
        }

        bool IsDead {
            get;
        }

        bool Invulnerable {
            get;
        }

        void Kill();
        void Damage(DamageContext context);
    }

    public interface ICombatant : IDamageable, IDamageDealer {
        Direction CurrentDirection {
            get;
            set;
        }

        CombatantAnimatorUpdater AnimatorUpdater {
            get;
        }
    }

    public sealed class DamageContext {
        private IDamageable damageable;
        private IDamageDealer dealer;
        private IDamageSource source;
        public DamageContext(IDamageable damageable, IDamageDealer dealer, IDamageSource source) {
            this.damageable = damageable;
            this.dealer = dealer;
            this.source = source;
        }

        public uint FinalDamage {
            get {
                return (uint) (source.Damage * dealer.DamageMultiplier.Value);
            }
        }

        public DamageResult ProcessResult() {
            return new DamageResult();
        }
    }

    public struct DamageResult { }
}