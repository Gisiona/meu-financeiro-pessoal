﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace OEconomicoPessoal.Utils
{
    public class Criptografia
    {
        private static byte[] chave = { };
        private static byte[] iv = { 12, 34, 56, 78, 90, 102, 114, 126 };

        private static string chaveCriptografia = "OEconomicoPessoal";

        //Criptografa o Cookie
        public static string Criptografar(string valor)
        {
            DESCryptoServiceProvider des;
            MemoryStream ms;
            CryptoStream cs; byte[] input;

            try
            {
                using (des = new DESCryptoServiceProvider())
                {

                    using (ms = new MemoryStream())
                    {

                        input = Encoding.UTF8.GetBytes(valor);
                        chave = Encoding.UTF8.GetBytes(chaveCriptografia.Substring(0, 8));

                        using (cs = new CryptoStream(ms, des.CreateEncryptor(chave, iv), CryptoStreamMode.Write))
                        {
                            cs.Write(input, 0, input.Length);
                            cs.FlushFinalBlock();
                        }

                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Descriptografa o cookie
        public static string Descriptografar(string valor)
        {
            DESCryptoServiceProvider des;
            MemoryStream ms;
            CryptoStream cs; byte[] input;

            try
            {
                des = new DESCryptoServiceProvider();
                ms = new MemoryStream();

                input = new byte[valor.Length];
                input = Convert.FromBase64String(valor.Replace(" ", "+"));

                chave = Encoding.UTF8.GetBytes(chaveCriptografia.Substring(0, 8));

                cs = new CryptoStream(ms, des.CreateDecryptor(chave, iv), CryptoStreamMode.Write);
                cs.Write(input, 0, input.Length);
                cs.FlushFinalBlock();

                return Encoding.UTF8.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static bool ValidaCaptcha(string _Challenge, string _Response)
        //{
        //    RecaptchaValidator validator = new Recaptcha.RecaptchaValidator
        //    {
        //        PrivateKey = "6LeettsSAAAAAIar7bn_hUpoMrzoDB7n_QeUe9FS",
        //        RemoteIP = System.Web.HttpContext.Current.Request.UserHostAddress,
        //        Challenge = _Challenge,
        //        Response = _Response
        //    };

        //    RecaptchaResponse Response = validator.Validate();

        //    return Response.IsValid;
        //}

        public static string GeraSenha()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", "");

            Random random = new Random();

            string senha = string.Empty;
            for (int i = 0; i <= 5; i++)
                senha += guid.Substring(random.Next(1, guid.Length), 1);

            return senha;
        }

        public static string CriptografaSHA1(string str)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "sha1");
        }


        public static string EncryptSenha(string password)
        {
            password += "|2d331cca-f6c0-40c0-bb43-6e32989c2881";
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] data = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(password));
            System.Text.StringBuilder sbString = new System.Text.StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sbString.Append(data[i].ToString("x2"));
            return sbString.ToString();
        }
    }
}