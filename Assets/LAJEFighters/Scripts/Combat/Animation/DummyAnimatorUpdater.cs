using UnityEngine;

namespace LAJEFighters.Scripts.Combat.Animation {
    public class DummyAnimatorUpdater : CombatantAnimatorUpdater {

        protected override void TriggerDefaultAttack(Animator animator) {
        }

        protected override void TriggerAttack(Animator animator, string attack) { }
    }
}