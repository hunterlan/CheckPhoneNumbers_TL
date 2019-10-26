using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckNumber_TL
{
    class Data
    {
        public List<string> phoneNumbers;

        public Data()
        {
            phoneNumbers = new List<string>();
        }

        public void ReadPhones(string pathToFiles)
        {
            try
            {
                using (StreamReader sr = new StreamReader(pathToFiles))
                {
                    while(!sr.EndOfStream)
                    {
                        string phone = sr.ReadLine();
                        phoneNumbers.Add(phone);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                phoneNumbers = null;
            }
        }

        public void WriteRegisteredPhones(string pathToFiles, List<string> registeredPhones)
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(pathToFiles))
                {
                    foreach(string phone in registeredPhones)
                    {
                        sw.WriteLine(phone);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
