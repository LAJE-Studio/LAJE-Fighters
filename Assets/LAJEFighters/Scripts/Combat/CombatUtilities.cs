namespace LAJEFighters.Scripts.Combat {
    public static class CombatUtilities {
        public static DamageResult ApplyDamage(this IDamageable damageable, DamageContext context) {
            damageable.Damage(context);
            return context.ProcessResult();
        }
        public static bool ShouldAttack(this ICombatant combatant, ICombatant target) {
            if (combatant == null || target == null) {
                return false;
            }

            return !target.IsDead && !target.Invulnerable;
        }
    }
}