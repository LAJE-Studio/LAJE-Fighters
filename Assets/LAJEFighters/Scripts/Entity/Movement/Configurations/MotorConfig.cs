using LAJEFighters.Scripts.Entity.Movement.States;
using UnityEngine;

namespace LAJEFighters.Scripts.Entity.Movement.Configurations {
    public abstract class MotorConfig : MonoBehaviour {
        public float MaxSpeed = 8;
    }

    public abstract class StateBasedMotorConfig : MotorConfig {
        private MovementState currentState;

        public MovementState GetCurrentState(StateMotor motor) {
            return currentState == null ? (currentState = motor.GetDefaultState()) : currentState;
        }

        public void SetMovementState(MovementState state) {
            currentState = state;
        }
    }
}