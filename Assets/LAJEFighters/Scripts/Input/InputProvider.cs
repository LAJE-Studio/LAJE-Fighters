using UnityEngine;

namespace LAJEFighters.Scripts.Input {
    public abstract class InputProvider : MonoBehaviour {
        public abstract float GetAxis(InputAction action);
        public abstract bool GetButton(InputAction action);
        public abstract bool GetButtonDown(InputAction action);
        public abstract bool GetButtonUp(InputAction action);
    }
}