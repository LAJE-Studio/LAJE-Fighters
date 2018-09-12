using System;
using UnityEngine;

namespace LAJEFighters.Scripts.Utilities.Properties {
    [Serializable]
    public class FloatProperty : Property<float> {
        [SerializeField]
        private float baseValue;


        public FloatProperty(float baseValue) {
            this.baseValue = baseValue;
        }

        public static implicit operator FloatProperty(float value) {
            return new FloatProperty(value);
        }

        public override float BaseValue {
            get {
                return baseValue;
            }
        }

        public override float Value {
            get {
                //TODO: FIX
                return baseValue;
            }
        }
    }

    [Serializable]
    public class UInt32Property : Property<uint> {
        [SerializeField]
        private uint baseValue;


        public UInt32Property(uint baseValue) {
            this.baseValue = baseValue;
        }

        public static implicit operator UInt32Property(uint value) {
            return new UInt32Property(value);
        }

        public override uint BaseValue {
            get {
                return baseValue;
            }
        }

        public override uint Value {
            get {
                //TODO: FIX
                return baseValue;
            }
        }
    }
}