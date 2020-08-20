using System;
namespace 简单异或加密
{
    class XorEncryption 
    {
        private XorEncryption() { }
        private static XorEncryption instance;
        public static XorEncryption Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new XorEncryption();
                }
                return instance;
            }
        }
        public char[] Encrypt(string content,string secretKey) 
        {
            char[] data = content.ToCharArray();
            char[] key = secretKey.ToCharArray();
            for (int i = 0; i < data.Length; i++)
            {
                data[i] ^= key[i % key.Length];
            }
            return data;
        }

        public string Decrypt(char[] data, string secretKey) 
        {
            char[] key = secretKey.ToCharArray();
            for (int i = 0; i < data.Length; i++)
            {
                data[i] ^= key[i % key.Length];
            }
            return new string(data);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string secretkey = "123qwe";
            string context = "MichaelChipmunk";
            Console.WriteLine(new string(XorEncryption.Instance.Encrypt(context, secretkey)));
            Console.WriteLine(XorEncryption.Instance.Decrypt(XorEncryption.Instance.Encrypt(context, secretkey),secretkey));

        }
    }
}
