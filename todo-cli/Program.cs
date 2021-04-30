using System;
using System.Collections.Generic;

namespace todo_cli {
    class Program {
        private static CStorage Storage;
        private static COutput Output;
        private static CInput Input;

        static void Main(string[] args) {
            Storage = new CStorage();
            Output = new COutput();
            Input = new CInput();

            if (args.Length > 0) {
                switch (args[0].Replace("-", "")) {
                    case "add":
                    case "a":
                    case "new":
                    case "n":
                        string itemText = Input.getNewItemText(args);
                        if (itemText != null) {
                            Storage.createElement(itemText);
                            Output.writeList(Storage.getTodoList());
                        }
                        break;
                    case "delete":
                    case "del":
                    case "d":
                        int removeId = Input.getRemoveId(args, Storage);
                        if (removeId >= 0) {
                            Storage.deleteElement(removeId);
                            Output.writeList(Storage.getTodoList());
                        }
                        break;
                    default:
                        Output.writeList(Storage.getTodoList());
                        break;
                }
            } else {
                Output.writeList(Storage.getTodoList());
            }

        }
    }
}
