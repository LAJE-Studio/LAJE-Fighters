using LAJEFighters.Scripts.Entity.Movement.Configurations;
using LAJEFighters.Scripts.Input;
using UnityEngine;

namespace LAJEFighters.Scripts.Entity.Movement.States {
    public class GroundedState : MovementState {
        public float OposingDirectinalForceMultiplier = 2;
        public override void OnEnter(MovableEntity entity) { }

        public override void OnMove(MovableEntity entity, ref Vector2 velocity) {
            var animator = entity.AnimatorUpdater;
            var provider = entity.InputProvider;
            var hasProvider = provider != null;
            var xInput = hasProvider ? provider.GetAxis(InputActions.Horizontal) : 0;
            var inputDir = System.Math.Sign(xInput);
            var config = entity.GetMotorConfigAs<TerrestrialMotorConfig>();
            //entity.Defending = hasProvider && provider.GetDefend();
            if (hasProvider && provider.GetButtonDown(InputActions.Attack)) {
                animator.TriggerDefaultAttack();
            }

            var shouldJump = hasProvider && provider.GetButtonDown(InputActions.Jump);
            if (shouldJump && entity.IsJumpEllegible()) {
                //Grounded and should jump
                velocity.y = config.JumpForce;
            }

            var velDir = System.Math.Sign(velocity.x);
            var curve = config.Acceleration;
            var speedMultiplier = entity.SpeedMultiplier.Value;
            var maxSpeed = config.MaxSpeed * speedMultiplier;
            var speedPercent = entity.SpeedPercentage;
            var rawAcceleration = curve.Evaluate(speedPercent) * speedMultiplier;
            var acceleration = rawAcceleration * inputDir;
            var speed = Mathf.Abs(velocity.x);
            //Check acceleration if (is stopped or (input is not empty and input is same dir as vel))
            if (velDir == 0 || velDir == inputDir && inputDir != 0) {
                velocity.x += acceleration;
            } else {
                var deacceleration = curve.Evaluate(1 - speedPercent);
                if (Mathf.Abs(xInput) > 0) {
                    //Changing direction, Double deacceleration
                    velocity.x += deacceleration * inputDir * OposingDirectinalForceMultiplier;
                } else {
                    //Not inputting
                    if (speed < rawAcceleration) {
                        velocity.x = 0;
                    } else {
                        velocity.x += deacceleration * -velDir;
                    }
                }
            }

            velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
        }

        public override void OnExit(MovableEntity entity) { }
    }
}