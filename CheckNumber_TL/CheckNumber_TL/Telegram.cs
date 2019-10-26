using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLSharp.Core;

namespace CheckNumber_TL
{
    public class Telegram
    {
        private readonly int apiID = 822992;
        private readonly string apiHash = "50c776aaf0e172d0f94060157802a050";
        private TelegramClient client;
        public bool isRegistered { get; set; }
        public Telegram()
        {
            isRegistered = false;
            client = new TelegramClient(apiID, apiHash);
            client.ConnectAsync(true);
        }

        public async Task<bool> IsAccountExist(string phoneNumber)
        {
            try
            {
                string code = await client.SendCodeRequestAsync(phoneNumber);
                if (code == null || code.Length == 0)
                    return false;
                else
                    return true;
                //return await client.IsPhoneRegisteredAsync(phoneNumber);
            }
            catch(Exception ex)
            {
                if(ex.HResult != -2146233079)
                    Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
