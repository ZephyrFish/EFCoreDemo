using EFCoreDataLibrary.DataAccess;
using EFCoreDataLibrary.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;

namespace EFCoreDemoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using PeopleContext db = new();
            Console.WriteLine("Create sample data: ...");

            if (!db.People.Any())
            {
                var res = MakeSampleData(db);
                Console.WriteLine($"{res} rows was inserted!");
            }

            var users = db.People.ToList();
            ShowPersonInfo(db);

            Console.WriteLine("Update data:");

            var toUpdate = users.FirstOrDefault();
            toUpdate.Addresses[0].StreetAddress = "ул. Новая, д. 27, кв. 8";
            db.People.Update(toUpdate);
            db.SaveChanges();
            Console.WriteLine("Data was succesfully updated!");

            ShowPersonInfo(db);

            Console.WriteLine("Delete data:");
            var toDelete = users.FirstOrDefault().Emails[0];
            db.Emails.Remove(toDelete);
            db.SaveChanges();
            Console.WriteLine("Data was succesfully deleted!");

            ShowPersonInfo(db);
            db.Database.ExecuteSqlRaw("delete dbo.Emails;delete dbo.Addresses;delete dbo.People;");
        }

        public static void ShowPersonInfo(PeopleContext db)
        {
            var users = db.People
                .Include(p => p.Addresses)
                .Include(p => p.Emails)
                .ToList();
            Console.WriteLine("Read data: ");
            foreach (var u in users)
            {
                Console.WriteLine($"Id {u.Id}. {u.FirstName}-{u.LastName} with {u.Age} age");
                Console.WriteLine($"Addresses:");
                foreach (var address in u.Addresses)
                {
                    Console.Write($"\t{address.StreetAddress}({address.ZipCode}) / ");
                }
                Console.WriteLine($"\nEmails:");
                foreach (var address in u.Emails)
                {
                    Console.Write($"\t{address.Id}.{address.EmailAddess} / ");
                }
                Console.WriteLine();
            }
        }

        public static int MakeSampleData(PeopleContext context)
        {
            Email email1 = new()
            {
                EmailAddess = "sample@sample.com"
            };

            Email email2 = new()
            {
                EmailAddess = "mail@sample.com"
            };

            Person person = new()
            {
                FirstName = "Петя",
                LastName = "Сидоров",
                Age = 10,
                Addresses = new()
                {
                    new Address()
                    {
                        StreetAddress = "ул. Домашняя, 27, кв.8",
                        City = "Екатеринбург",
                        ZipCode = "345222"
                    }
                },
                Emails = new() { email1, email2 }
            };

            context.People.Add(person);
            return context.SaveChanges();
        }
    }
}
