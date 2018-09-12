namespace LAJEFighters.Scripts.Input {
    public sealed class InputAction {
        private readonly byte id;
        private readonly string name;

        public InputAction(byte id, string name) {
            this.id = id;
            this.name = name;
        }

        public byte ID {
            get {
                return id;
            }
        }

        public string Name {
            get {
                return name;
            }
        }
    }

    public static class InputActions {
        public static readonly InputAction Horizontal = new InputAction(0, "Horizontal");
        public static readonly InputAction Vertical = new InputAction(1, "Vertical");
        public static readonly InputAction Jump = new InputAction(2, "Jump");
        public static readonly InputAction Attack = new InputAction(3, "Attack");
    }
}