using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLSharp.Core;

namespace CheckNumber_TL
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Do();
        }

        static async Task Do()
        {
            
            Data datas = new Data();
            Telegram tg = new Telegram();
            Console.Write("Write the path to txt file: ");
            string path = Console.ReadLine();
            datas.ReadPhones(path);
            if (datas.phoneNumbers != null)
            {
                List<string> registeredPhone = new List<string>();
                foreach (var phone in datas.phoneNumbers)
                {
                    if (await tg.IsAccountExist(phone))
                        registeredPhone.Add(phone);
                }
                Console.Write("Write the path and name file to save registered phones: ");
                path = Console.ReadLine();
                datas.WriteRegisteredPhones(path, registeredPhone);
            }
        }
    }
}
