using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace gen_contacts
{
    class Program
    {
        static void Main(string[] args)
        {
            var L = Generator.Contacts(1, 33);
            Generator.Writer(L, 1);
        }
    }

    public class Generator
    {
        public static string name = "contact";
        public static string address = "@none.com";
        public static string contact = "";
        public static string OUTPUT_FILE = "contacts.txt";

        public static List<string> Contacts(int a, int b)
        {
            var L = new List<string>();

            for (int i = a; i <= b; i++)
            {
                contact = name + i.ToString("000") + address;
                L.Add(contact);
            }

            return L;
        }

        public static void Writer(List<string> lstContacts, int type)
        {

            int counter = 0;

            using (FileStream fs = new FileStream(OUTPUT_FILE, FileMode.Create))
            {
                using (TextWriter tw = new StreamWriter(fs))
                {
                    if (type == 0)
                    {
                        for (int i = 0; i <= lstContacts.Count - 1; i++)
                        {
                            counter += 1;
                            if (counter == lstContacts.Count)
                            {
                                tw.Write(lstContacts[i]);
                            }
                            else
                            {
                                tw.Write(lstContacts[i] + ",");
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= lstContacts.Count - 1; i++)
                        {
                            tw.WriteLine(lstContacts[i]);
                        }
                    }
                }
            }
        }
    }
}