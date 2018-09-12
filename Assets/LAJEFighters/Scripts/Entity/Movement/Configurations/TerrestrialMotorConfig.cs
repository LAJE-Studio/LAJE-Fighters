using UnityEngine;

namespace LAJEFighters.Scripts.Entity.Movement.Configurations {
    public sealed class TerrestrialMotorConfig : StateBasedMotorConfig {
        public float JumpCheckLength = 0.25F;
        public float JumpCheckPadding = 0.1F;
        public float JumpForce = 10;
        public AnimationCurve Acceleration = AnimationCurve.Constant(0, 1, 8);
    }
}