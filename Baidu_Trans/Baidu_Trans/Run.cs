using System;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using Baidu_Trans;

namespace BaiDuTransAPIC
{
    class Run
    {
        static void Main(string[] args)
        {
            // 原文
            string q = "我不去想是否能够成功，既然选择了远方，便只顾风雨兼程。我不去想能否赢得爱情，既然钟情于玫瑰，就勇敢地吐露真诚。我不去想身后会不会袭来寒风冷雨，既然目标是地平线，留给世界的只能是背影。我不去想未来是平坦还是泥泞，只要热爱生命，一切都在意料之中。";
            // 源语言
            string from = "zh";
            // 目标语言
            string to = "en";
            // XXXX处输入你的APP ID
            string appId = "XXXX";
            Random rd = new Random();
            string salt = rd.Next(100000).ToString();
            // XXXX处输入你的密钥
            string secretKey = "XXXX";

            Transform tran1 = new Transform(q, from, to, appId, salt, secretKey);

            //利用fastJSON包对返回的JSON数据进行解析，拿到第一次翻译结果
            dynamic d1 = fastJSON.JSON.ToDynamic(tran1.TransString());
            string dst1 = d1.trans_result[0].dst.ToString();

            //由于QPS为1，故令线程休眠一秒后再发出请求
            System.Threading.Thread.Sleep(1000);
            Transform tran2 = new Transform(dst1, to, from, appId, salt, secretKey);

            dynamic d2 = fastJSON.JSON.ToDynamic(tran2.TransString());
            string dst2 = d2.trans_result[0].dst.ToString();

            Console.WriteLine(dst2);

            Console.ReadKey();
        }
    }
}
