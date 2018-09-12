using UnityEngine;

namespace LAJEFighters.Scripts.Entity.Movement {
    public abstract class Motor : ScriptableObject {
        protected abstract void OnEnter(MovableEntity entity);
        protected abstract void OnMove(MovableEntity entity, ref Vector2 finalVelocity);
        protected abstract void OnExit(MovableEntity entity);

        public void Move(MovableEntity movableEntity) {
            var vel = movableEntity.Rigidbody.velocity;
            OnMove(movableEntity, ref vel);
            movableEntity.Rigidbody.velocity = vel;
        }
    }
}