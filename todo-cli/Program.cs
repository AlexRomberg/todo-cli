using System;
using System.Collections.Generic;

namespace todo_cli {
    class Program {
        private static CStorage Storage;
        static void Main(string[] args) {
            Storage = new CStorage();

            foreach (TodoElement element in Storage.getTodoList()) {
                Console.WriteLine(element.Text);
            }
        }
    }
}
