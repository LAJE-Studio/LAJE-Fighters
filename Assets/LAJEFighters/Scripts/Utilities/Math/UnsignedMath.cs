namespace LAJEFighters.Scripts.Utilities.Math {
    public static class UnsignedMath {
        public static uint Clamp(uint value, uint min, uint max) {
            if (value < min) {
                return min;
            }

            if (value > max) {
                return max;
            }

            return value;
        }
    }
}