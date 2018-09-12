using LAJEFighters.Scripts.Entity.Movement.Configurations;
using UnityEngine;

namespace LAJEFighters.Scripts.Entity.Movement {
    public static class MovementUtilities {
        public static bool IsJumpEllegible(this MovableEntity entity) {
            var config = entity.GetMotorConfigAs<TerrestrialMotorConfig>(false);
            if (config == null) {
                return false;
            }

            if (entity.CollisionStatus.Down) {
                return true;
            }

            var bounds = entity.Hitbox.bounds;
            var min = bounds.min;
            var max = bounds.max;
            max.y = min.y;
            min.x += config.JumpCheckPadding;
            max.x -= config.JumpCheckPadding;
            min.y -= config.JumpCheckLength;
            return Physics2D.OverlapArea(min, max);
        }
    }
}