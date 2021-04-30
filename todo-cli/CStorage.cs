using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Text;

namespace todo_cli {
    class CStorage {
        private List<TodoElement> TodoElements = new List<TodoElement>();
        string StoragePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ARO-Studios", "todo-cli", "todoList.json");

        public CStorage() {
            loadList();
        }

        private void saveList() {
            if (!Directory.Exists(Path.GetDirectoryName(StoragePath))) {
                Directory.CreateDirectory(Path.GetDirectoryName(StoragePath));
            }

            string json = JsonSerializer.Serialize(TodoElements);
            File.WriteAllText(StoragePath, json, Encoding.UTF8);

        }

        private void loadList() {
            if (File.Exists(StoragePath)) {
                string json = File.ReadAllText(StoragePath);
                TodoElements = new List<TodoElement>(JsonSerializer.Deserialize<TodoElement[]>(json));
            } else {
                TodoElements = new List<TodoElement>();
                saveList();
            }
        }

        public void createElement(string text) {
            TodoElement todoElement = new TodoElement(text, ElementState.Open);
            TodoElements.Add(todoElement);
            saveList();
        }

        public void deleteElement(int index) {
            try {
                TodoElements.RemoveAt(index);
                saveList();
            } catch {
                Console.WriteLine("Index out of range!");
            }
        }

        public void updateElementText(int index, string text) {
            try {
                TodoElements[index].Text = text;
                saveList();
            } catch {
                Console.WriteLine("Index out of range!");
            }
        }

        public void updateElementState(int index, ElementState state) {
            try {
                TodoElements[index].State = state;
                saveList();
            } catch {
                Console.WriteLine("Index out of range!");
            }
        }

        public TodoElement[] getTodoList() {
            loadList();
            return TodoElements.ToArray();
        }
    }
}
