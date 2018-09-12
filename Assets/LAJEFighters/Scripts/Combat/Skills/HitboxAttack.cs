using System.Collections;
using LAJEFighters.Scripts.Data;
using Shiroi.FX.Effects;
using Shiroi.FX.Features;
using Shiroi.FX.Utilities;
using UnityEngine;
using UnityUtilities;
using UnityUtilities.Misc;

namespace LAJEFighters.Scripts.Combat.Skills {
    //TODO: Implement
    [CreateAssetMenu(menuName = "LAJEFighters/Skills/Attacks/HitboxAttack")]
    public sealed class HitboxAttack : Attack {
        [SerializeField]
        private uint damage;

        public Bounds2D Hitbox;

        public Effect HitEffect;
        public byte TotalFrames = 5;

        public override void Execute(ICombatant entity) {
            entity.AnimatorUpdater.StartCoroutine(ExecuteAttack(entity));
        }

        private bool DoAttack(ICombatant entity) {
            var hb = Hitbox;
            var xDir = entity.CurrentDirection.X;
            if (xDir != 0) {
                hb.Center.x *= xDir;
            }

            hb.Center += (Vector2) entity.Transform.position;
            var success = false;
            var found = Physics2D.OverlapBoxAll(hb.Center, hb.Size, 0, GameResources.Instance.DamageableMask);
            foreach (var hit in found) {
                var d = hit.GetComponentInParent<IDamageable>();
                if (d == null || d.Invulnerable) {
                    continue;
                }

                var e = d as ICombatant;
                if (e != null && !entity.ShouldAttack(e)) {
                    continue;
                }

                var info = new DamageContext(d, e, this);
                success = true;
                d.Damage(info);
                HitEffect.PlayIfPresent(new EffectContext(
                    (MonoBehaviour) entity,
                    new PositionFeature(d.Transform.position)
                    ));
            }

            ;
            return success;
        }

        private IEnumerator ExecuteAttack(ICombatant entity) {
            for (byte i = 0; i < TotalFrames; i++) {
                if (DoAttack(entity)) {
                    yield break;
                }

                yield return null;
            }
        }

        public override uint Damage {
            get {
                return damage;
            }
        }
    }
}