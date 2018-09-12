namespace LAJEFighters.Scripts.Input {
    public class NativeInputProvider : InputProvider {
        public override float GetAxis(InputAction action) {
            return UnityEngine.Input.GetAxisRaw(action.Name);
        }

        public override bool GetButton(InputAction action) {
            return UnityEngine.Input.GetButton(action.Name);
        }

        public override bool GetButtonDown(InputAction action) {
            return UnityEngine.Input.GetButtonDown(action.Name);
        }

        public override bool GetButtonUp(InputAction action) {
            return UnityEngine.Input.GetButtonUp(action.Name);
        }
    }
}