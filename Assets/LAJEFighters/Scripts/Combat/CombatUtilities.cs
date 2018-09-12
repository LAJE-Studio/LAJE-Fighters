namespace LAJEFighters.Scripts.Combat {
    public static class CombatUtilities {
        public static DamageResult ApplyDamage(this IDamageable damageable, DamageContext context) {
            damageable.Damage(context);
            return context.ProcessResult();
        }
    }
}