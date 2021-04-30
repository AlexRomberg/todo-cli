using System;
using System.Collections.Generic;

namespace todo_cli {
    class Program {
        private static CStorage Storage;
        private static COutput Output;

        static void Main(string[] args) {
            Storage = new CStorage();
            Output = new COutput();

            if (args.Length > 0) {
                //switch (args[0]) {
                //    case "add":
                //    case "-a":
                //    case "a":
                //        Storage.createElement("Hello");
                //        break;
                //    case "delete":
                //    case "del":
                //    case "-d":
                //    case "d":
                //        Storage.deleteElement(0);
                //        break;
                //    default:
                //        Output.writeList(Storage.getTodoList());
                //        break;
                //}
            } else {
                Output.writeList(Storage.getTodoList());
            }

        }
    }
}
