using System;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;

namespace Baidu_Trans
{
    /*
     *  用于计算MD5，生成签名sign 
     */
    class EncryptString
    {

        public static string Encryptstring(string str)
        {
            MD5 md5 = MD5.Create();
            // 将字符串转换成字节数组
            byte[] byteOld = Encoding.UTF8.GetBytes(str);
            // 调用加密方法
            byte[] byteNew = md5.ComputeHash(byteOld);
            // 将加密结果转换为字符串
            StringBuilder sb = new StringBuilder();
            foreach (byte b in byteNew)
            {
                // 将字节转换成16进制表示的字符串，
                sb.Append(b.ToString("x2"));
            }
            // 返回加密的字符串
            return sb.ToString();
        }
    }
}
