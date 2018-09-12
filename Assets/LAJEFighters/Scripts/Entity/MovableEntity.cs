using System;
using LAJEFighters.Scripts.Entity.Movement;
using LAJEFighters.Scripts.Entity.Movement.Configurations;
using LAJEFighters.Scripts.Utilities;
using LAJEFighters.Scripts.Utilities.Properties;
using UnityEngine;
using UnityUtilities;

namespace LAJEFighters.Scripts.Entity {
    [Serializable]
    public sealed class MovementMeta {
        public MotorConfig Config;
        public GameObject ConfigHost;
    }

    public class MovableEntity : LivingEntity {
        public Rigidbody2D Rigidbody;
        public MovementMeta MovementMetadata;
        public CollisionStatus CollisionStatus;
        public FloatProperty SpeedMultiplier = 1;
        public Motor Motor;

        private void Update() {
            Motor.Move(this);
        }

        public float SpeedPercentage {
            get {
                return Rigidbody.velocity.magnitude / MovementMetadata.Config.MaxSpeed;
            }
        }

        public T GetMotorConfigAs<T>(bool replaceIfInvalid = true) where T : MotorConfig {
            var config = MovementMetadata.Config;
            var hasConfig = config != null;
            if (hasConfig && config is T) {
                return (T) config;
            }

            if (hasConfig && replaceIfInvalid) {
                Destroy(config);
            }

            if (!replaceIfInvalid) {
                return null;
            }

            var obj = MovementMetadata.ConfigHost.RequirePresent();
            return (T) (MovementMetadata.Config = obj.GetOrAddComponent<T>());
        }

        public void EnsureMotorConfigIs<T>() where T : MotorConfig {
            GetMotorConfigAs<T>();
        }
    }
}