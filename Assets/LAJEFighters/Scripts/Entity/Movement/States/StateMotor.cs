using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LAJEFighters.Scripts.Entity.Movement.States {
    [CreateAssetMenu(menuName = "LAJEFighters/Motors/StateMotor")]
    public class StateMotor : Motor {
        [SerializeField]
        private List<MovementState> states;

        public List<MovementState> States {
            get {
                return states;
            }
        }

        protected override void OnEnter(MovableEntity entity) {
            foreach (var state in states) {
                state.OnEnter(entity);
            }
        }

        protected override void OnMove(MovableEntity entity, ref Vector2 finalVelocity) {
            foreach (var state in states) {
                state.OnMove(entity, ref finalVelocity);
            }
        }

        protected override void OnExit(MovableEntity entity) {
            foreach (var state in states) {
                state.OnExit(entity);
            }
        }

        public MovementState GetDefaultState() {
            return states.First();
        }

        public void AddState(MovementState state) {
            states.Add(state);
        }

        public void RemoveState(MovementState state) {
            states.Remove(state);
        }
    }

    public abstract class MovementState : ScriptableObject {
        public abstract void OnEnter(MovableEntity entity);
        public abstract void OnMove(MovableEntity entity, ref Vector2 velocity);
        public abstract void OnExit(MovableEntity entity);
    }
}