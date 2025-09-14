using System;
using System.Collections.Generic;

namespace UserManagement
{
    // Класс пользователя
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public User(string name, string email, string role)
        {
            Name = name;
            Email = email;
            Role = role;
        }

        public override string ToString()
        {
            return $"{Name} ({Email}) - {Role}";
        }
    }

    // Менеджер пользователей
    public class UserManager
    {
        private List<User> users = new List<User>();

        public void AddUser(string name, string email, string role)
        {
            users.Add(new User(name, email, role));
        }

        public void RemoveUser(string email)
        {
            users.RemoveAll(u => u.Email == email);
        }

        public void UpdateUser(string email, string newName, string newRole)
        {
            var user = users.Find(u => u.Email == email);
            if (user != null)
            {
                user.Name = newName;
                user.Role = newRole;
            }
        }

        public void PrintAllUsers()
        {
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            UserManager manager = new UserManager();

            // Добавляем пользователей
            manager.AddUser("Alice", "alice@mail.com", "Admin");
            manager.AddUser("Bob", "bob@mail.com", "User");

            Console.WriteLine("Все пользователи:");
            manager.PrintAllUsers();

            // Обновляем пользователя
            manager.UpdateUser("bob@mail.com", "Bobby", "Admin");

            Console.WriteLine("\nПосле обновления:");
            manager.PrintAllUsers();

            // Удаляем пользователя
            manager.RemoveUser("alice@mail.com");

            Console.WriteLine("\nПосле удаления:");
            manager.PrintAllUsers();
        }
    }
}

// Вывод

// YAGNI – реализованы только AddUser, RemoveUser, UpdateUser и вывод. Никаких лишних абстракций без интерфейсов или сложных фильтров.

// KISS – простой List<User> и линейная логика без сложных вложений.

// DRY – логика работы с пользователями сосредоточена в UserManager, без повтора.