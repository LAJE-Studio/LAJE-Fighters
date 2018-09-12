using UnityEngine;

namespace LAJEFighters.Scripts.Utilities.Properties {
    public abstract class Property { }

    public abstract class Property<T> : Property {
        private PropertyModifier<T> modifiers;

        public abstract T BaseValue {
            get;
        }

        public abstract T Value {
            get;
        }
    }

    public abstract class PropertyModifier<T> { }
}