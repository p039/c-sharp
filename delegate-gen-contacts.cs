using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace delegate_gen_contacts
{

    public struct Contact
    {
        public string Name;

        public Contact(string name)
        {
            Name = name;
        }
    }

    public delegate void ProcessContactDelegate(Contact contact);

    public class ContactDB
    {
        ArrayList list = new ArrayList();

        public void AddContact(string name, string domain, int begin, int end)
        {
            for (int i = begin; i < end; i++)
            {
                list.Add(new Contact(name + i.ToString("000") + domain));
            }
        }

        public void ProcessContact(ProcessContactDelegate processContact)
        {
            foreach (Contact c in list)
            {
                processContact(c);
            }
        }
    }

    class WriteFile
    {
        public static string OUTPUT_FILE = "contact.txt";

        internal void Writer(Contact con)
        {

            using (FileStream fs = new FileStream(OUTPUT_FILE, FileMode.Append))
            {
                using (TextWriter tw = new StreamWriter(fs))
                {
                    tw.WriteLine(con.Name);
                }
            }
        }
    }

    class Program
    {     
        static void Main(string[] args)
        {
            ContactDB cdb = new ContactDB();
            WriteFile wf = new WriteFile();
            cdb.AddContact("contact", "@domain.com", 1, 100);

            cdb.ProcessContact(new ProcessContactDelegate(wf.Writer));
        }
    }
}
