using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace OEconomicoPessoal.Utils.Conversor
{
    public class Conversores
    {
        public static string GetNomeExtensaoArquivo(string pathArquivo)
        {
            try
            {
                return Path.GetFileName(pathArquivo);
            }
            catch
            {
                throw new Exception("NÃO FOI POSSÍVEL RECUMPERAR O NOME DO ARQUIVO.");
            }
        }

        public static Byte[] ConverterArquivoToBytes(string pathArquivo)
        {
            try
            {
                return File.ReadAllBytes(pathArquivo);
            }
            catch
            {
                throw new Exception("NÃO FOI POSSÍVEL CONVERTER O ARQUIVO EM BYTES.");
            }
        }

        public static byte[] ConverterImagemParaByteArray()
        {
            try
            {
                using (var stream = new System.IO.MemoryStream())
                {
                    //webCamPictureBox.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    stream.Seek(0, System.IO.SeekOrigin.Begin);
                    byte[] bArray = new byte[stream.Length];
                    stream.Read(bArray, 0, System.Convert.ToInt32(stream.Length));
                    return bArray;
                }
            }
            catch
            {
                throw new Exception("NÃO FOI POSSÍVEL CONVERTER O ARQUIVO EM BYTES.");
            }
        }

        public static string GetExtensaoArquivo(string nomeArquivo)
        {
            var retorno = nomeArquivo.Split('.')[nomeArquivo.Split('.').Length - 1];
            return retorno;
        }

        public static void ConverterBytesToArray(byte bytes)
        {
            //File.WriteAllBytes(@"C:/teste.pdf", bytes); 
        }

        public static Byte[] GetBytesFromBinaryString(String binary)
        {
            var list = new List<Byte>();

            for (int i = 0; i < binary.Length; i += 8)
            {
                String t = binary.Substring(i, 8);

                list.Add(Convert.ToByte(t, 2));
            }

            return list.ToArray();
        }

        public static string DefinirContextDownloadArquivo(string nomeArquivo)
        {
            string[] arquivo = nomeArquivo.Split('.');
            string contexto = string.Empty;
            switch (arquivo[arquivo.Length - 1].ToLower())
            {
                case "jpeg":
                case "jpg":
                    contexto = "image/jpeg";
                    break;
                case "png":
                    contexto = "image/png";
                    break;
                case "gif":
                    contexto = "image/gif";
                    break;
                case "doc":
                case "dot":
                    contexto = "application/msword";
                    break;
                case "docx":
                    contexto = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    break;
                case "xls":
                    contexto = "application/vnd.ms-excel";
                    break;
                case "xlsx":
                    contexto = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    break;
                case "ppt":
                    contexto = "application/vnd.ms-powerpoint";
                    break;
                case "pptx":
                    contexto = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                    break;
                case "pdf":
                    contexto = "application/pdf";
                    break;
                default:
                    contexto = "application/octet-stream";
                    break;
            }
            return contexto;
        }

        public static void BaixarArquivo(string nomeArquivo, byte[] arquivo, HttpResponseBase response, HttpServerUtilityBase server)
        {
            try
            {
                response.ClearContent();
                response.ContentType = DefinirContextDownloadArquivo(nomeArquivo);
                String Header = "attachment; filename=" + nomeArquivo;
                response.AppendHeader("Content-Disposition", Header);
                response.BinaryWrite(arquivo);
                response.Flush();
                response.End();
            }
            catch
            {
                throw new Exception("ERRO: 2200. </br>" + " NÃO FOI POSSÍVEL FAZER O DOWNLOAD DO ARQUIVO, TENTE NOVAMENTE MAIS TARDE.");
            }
        }

        public static byte[] GetArquivoFormatado()
        {
            throw new NotImplementedException();
        }

        public static byte[] ConverterHttpPostFileBaseToBytes(HttpPostedFileBase result)
        {
            byte[] data;
            using (Stream inputStream = result.InputStream)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    inputStream.CopyTo(ms);
                    data = ms.ToArray();
                }
            }
            return data;
        }

        public static byte[] ConverToBytes(HttpPostedFileBase file)
        {
            var length = file.InputStream.Length; //Length: 103050706
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                fileData = binaryReader.ReadBytes(file.ContentLength);
            }
            return fileData;
        }

        public static byte[] ConvertToByte(HttpPostedFileBase file)
        {
            byte[] imageByte = null;
            BinaryReader rdr = new BinaryReader(file.InputStream);
            imageByte = rdr.ReadBytes((int)file.ContentLength);
            return imageByte;
        }



    }
}