using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EpamLesson1Dz1
{
    /// <summary>
    /// There is a basic interface for contacts.
    /// </summary>
    interface IContact
    {
        string Name { get; set; }

        string Number { get; set; }

        string GetInfo();
    }

    /// <summary>
    /// Class contains basic elements for everyone contacts.
    /// </summary>
    abstract class Contact:IContact
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public Contact(string name, string number)
        {
            Name = name;
            Number = number;
        }

        public abstract string GetInfo();
    }

    /// <summary>
    /// It is for contacts from work.
    /// </summary>
    class WorkContact : Contact
    {

        public string Post { get; set; }

        public WorkContact(string name,string number, string post):base(name,number)
        { 
            Post = post;
        }

        public override string GetInfo()
        {
            return $"Work => Name={Name}, Number={Number}, Post={Post}";
        }
    }

    /// <summary>
    /// It is for contacts from family.
    /// </summary>
    class FamilyContact : Contact
    {
        public string Relations { get; set; }

        public FamilyContact(string name, string number, string relations):base(name,number)
        {
            Relations = relations;
        }

        public override string GetInfo()
        {
            return $"Family => Name={Name}, Number={Number}, Rekations={Relations}";
        }
    }

    class Program
    {
        private static List<Contact> _contacts;

        static void Main(string[] args)
        {
            _contacts = new List<Contact>();
            int action = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Contacts:");
                foreach (var n in GetNames())
                    Console.WriteLine(n + "\t");
                Console.WriteLine("\nActions:\n" +
                                    "0-Exit\n" +
                                    "1-Add\n" +
                                    "2-Show information\n" +
                                    "3-Remove\n" +
                                    "4-Update\n");
                action = int.Parse(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Show();
                        break;
                    case 3:
                        Remove();
                        break;
                    case 4:
                        Update();
                        break;
                }
            } while (action != 0);
        }

        private static IEnumerable<string> GetNames()
        {
            return from c in _contacts
                   select c.Name;
        }

        static Contact Create()
        {
            Console.Clear();
            Console.Write("Type (1-family, 2-work): ");
            int type = Int32.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Phone: ");
            string number = Console.ReadLine();
            if (type == 1)
                Console.Write("Relation: ");
            else
                Console.Write("Post: ");
            string additional = Console.ReadLine();
            if (type == 1)
                return new FamilyContact(name, number, additional);
            else
                return new WorkContact(name, number, additional);
        }
        
        static int TakeIndex()
        {
            Console.Clear();
            Console.Write("Index: ");
            int t=Int32.Parse(Console.ReadLine());
            return t;
        }

        static void Show()
        {
            int t = TakeIndex();
            Console.WriteLine(_contacts[t].GetInfo());
            Console.ReadKey();
        }

        static void Remove()
        {
            int t = TakeIndex();
            _contacts.RemoveAt(t);
        }

        static void Add()
        {
            _contacts.Add(Create());
        }

        static void Update()
        {
            int t = TakeIndex();
            _contacts[t] = Create();
        }

    }
}
