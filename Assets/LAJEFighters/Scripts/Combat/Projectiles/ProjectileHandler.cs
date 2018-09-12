using UnityEngine;

namespace LAJEFighters.Scripts.Combat.Projectiles {
    public abstract class ProjectileHandler : MonoBehaviour {
        public abstract void HandleCollision(Projectile projectile, Collision2D collision);
    }
}