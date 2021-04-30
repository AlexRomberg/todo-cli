using System;

namespace todo_cli {
    class CInput {
        public string getNewItemText(string[] args) {
            if (args.Length > 1) {
                return getArgumentInput(args);
            } else {
                Console.Write("Please enter a text of the item: ");
                string itemText = Console.ReadLine();
                if (showDialog("Save text?", true)) {
                    return itemText;
                } else {
                    return null;
                }
            }
        }

        public int getRemoveId(string[] args, CStorage storage) {
            int id;
            if (args.Length > 1) {
                id = Convert.ToInt32(getArgumentInput(args));
            } else {
                Console.Write("Please enter the index of the item: ");
                id = Convert.ToInt32(Console.ReadLine());
            }

            if (showDialog("Realy delete: \"" + storage.getTodoList()[id].Text + "\"?", true)) {
                return id;
            } else {
                return -1;
            }
        }

        private string getArgumentInput(string[] args) {
            string text = "";
            for (int i = 1; i < args.Length; i++) {
                if (i > 1) {
                    text += " ";
                }
                text += args[i];
            }
            return text;
        }

        private bool showDialog(string question, bool defaultAnswer) {
            Console.Write("{0} {1}", question, (defaultAnswer ? "[Y/n]" : "[y/N]"));
            while (true) {
                switch (Console.ReadKey().Key) {
                    case ConsoleKey.N:
                        Console.WriteLine();
                        return false;
                    case ConsoleKey.Y:
                    case ConsoleKey.J:
                        Console.WriteLine();
                        return true;
                    case ConsoleKey.Enter:
                        Console.WriteLine();
                        return defaultAnswer;
                }
            }
        }
    }
}
