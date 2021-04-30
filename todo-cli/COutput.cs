using System;

namespace todo_cli {
    class COutput {
        public void writeList(TodoElement[] todoList) {
            string line = getTextLine();
            int index = 0;

            Console.WriteLine("  Id ╷ Status    ╷ Text\n" +
                              "─────┼───────────┼{0}─", line);

            foreach (TodoElement element in todoList) {
                if (index > 0) {
                    Console.WriteLine("─────┼───────────┼{0}─", line);
                }

                Console.WriteLine(" {0} │ {1} │ {2}", index.ToString().PadLeft(3), getStatusItem(element.State), getFormatedTextItem(element.Text));

                index++;
            }

            Console.WriteLine("─────┴───────────┴{0}─", line);
        }

        private string getFormatedTextItem(string text) {
            int maxWidth = Console.WindowWidth - 21;
            if (text.Length < maxWidth) {
                return text;
            } else {
                return text.Substring(0, maxWidth - 3) + "...";
            }
        }

        private string getTextLine() {
            int width = Console.WindowWidth - 19;
            return "".PadLeft(width, '─');
        }

        private string getStatusItem(ElementState state) {
            return ("[" + state + "]").PadRight(9);
        }
    }
}
