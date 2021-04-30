namespace todo_cli {
    enum ElementState {
        Open,
        Working,
        Waiting,
        Done
    }

    class TodoElement {
        public string Text { get; set; }
        public ElementState State { get; set; }

        public TodoElement(string text, ElementState state) {
            Text = text;
            State = state;
        }
    }
}
