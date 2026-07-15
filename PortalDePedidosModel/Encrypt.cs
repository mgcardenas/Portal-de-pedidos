using System.Security.Cryptography;
using System.Text;

namespace PortalDePedidosModel
{
    public class Encrypt
    {
        public static string GetMD5(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(str);
            byte[] hash = md5.ComputeHash(inputBytes);
            string clave_encriptada = BitConverter.ToString(hash).Replace("-", "");
            return clave_encriptada.ToLower();
        }

        public static string GetSHA1(string texto)
        {
            // Convertir el texto a bytes
            byte[] bytes = Encoding.UTF8.GetBytes(texto);

            // Calcular el hash SHA-1
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] hashBytes = sha1.ComputeHash(bytes);

                // Convertir el hash a una cadena hexadecimal
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
