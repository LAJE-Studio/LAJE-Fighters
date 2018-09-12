using LAJEFighters.Scripts.Animation;
using UnityEngine;

namespace LAJEFighters.Scripts.Combat.Animation {
    public abstract class CombatantAnimatorUpdater : AnimatorUpdater {
        [SerializeField]
        private Animator animator;

        public void TriggerDefaultAttack() {
            TriggerDefaultAttack(animator);
        }

        public void TriggerAttack(string attack) {
            TriggerAttack(animator, attack);
        }
        protected abstract void TriggerDefaultAttack(Animator animator);
        protected abstract void TriggerAttack(Animator animator, string attack);
    }
}