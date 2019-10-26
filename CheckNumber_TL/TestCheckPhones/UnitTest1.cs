using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckNumber_TL;
using System.Threading.Tasks;

namespace TestCheckPhones
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestTrue()
        {
            List<string> phones = new List<string> {
                "+380970729263", "+380681849336"};
            List<string> result = phones;
            List<string> compare = new List<string>();
            Telegram tg = new Telegram();
            for(int i = 0; i < phones.Count; i++)
            {
                if (await tg.IsAccountExist(phones[i]))
                    compare.Add(phones[i]);
            }
            Assert.AreEqual(result, compare);
        }

        [TestMethod]
        public async Task TestFalse()
        {
            List<string> phones = new List<string>
            {
                "+3812904y1265", "+380685224764"
            };
            List<string> result = null;
            Telegram tg = new Telegram();
            for (int i = 0; i < phones.Count; i++)
            {
                if(await tg.IsAccountExist(phones[i]) && result == null)
                {
                    result = new List<string>();
                    result.Add(phones[i]);
                }
                else if(await tg.IsAccountExist(phones[i]))
                {
                    result.Add(phones[i]);
                }
            }
            Assert.IsNull(result);
        }
    }
}
