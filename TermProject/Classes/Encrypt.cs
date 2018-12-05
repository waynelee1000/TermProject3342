using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace Classes
{
    public class Encrypt
    {
        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };

        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };

        public string EncryptPass(string password)
        {
            UTF8Encoding encoder = new UTF8Encoding();      // used to convert bytes to characters, and back

            Byte[] textBytes;                               // stores the plain text data as bytes

            string EncryptPassword;

            textBytes = encoder.GetBytes(password);

            // Create an instances of the encryption algorithm (Rinjdael AES) for the encryption to perform,

            // a memory stream used to store the encrypted data temporarily, and

            // a crypto stream that performs the encryption algorithm.

            RijndaelManaged rmEncryption = new RijndaelManaged();

            MemoryStream myMemoryStream = new MemoryStream();

            CryptoStream myEncryptionStream = new CryptoStream(myMemoryStream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);



            // Use the crypto stream to perform the encryption on the plain text byte array.

            myEncryptionStream.Write(textBytes, 0, textBytes.Length);

            myEncryptionStream.FlushFinalBlock();



            // Retrieve the encrypted data from the memory stream, and write it to a separate byte array.

            myMemoryStream.Position = 0;

            Byte[] encryptedBytes = new Byte[myMemoryStream.Length];

            myMemoryStream.Read(encryptedBytes, 0, encryptedBytes.Length);



            // Close all the streams.

            myEncryptionStream.Close();

            myMemoryStream.Close();

            EncryptPassword = Convert.ToBase64String(encryptedBytes);

            return EncryptPassword;
        }


        public string EncryptLogin(string loginid)
        {
            UTF8Encoding encoder = new UTF8Encoding();      // used to convert bytes to characters, and back

            Byte[] textBytes;                               // stores the plain text data as bytes

            string EncryptloginID;

            textBytes = encoder.GetBytes(loginid);

            // Create an instances of the encryption algorithm (Rinjdael AES) for the encryption to perform,

            // a memory stream used to store the encrypted data temporarily, and

            // a crypto stream that performs the encryption algorithm.

            RijndaelManaged rmEncryption = new RijndaelManaged();

            MemoryStream myMemoryStream = new MemoryStream();

            CryptoStream myEncryptionStream = new CryptoStream(myMemoryStream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);



            // Use the crypto stream to perform the encryption on the plain text byte array.

            myEncryptionStream.Write(textBytes, 0, textBytes.Length);

            myEncryptionStream.FlushFinalBlock();



            // Retrieve the encrypted data from the memory stream, and write it to a separate byte array.

            myMemoryStream.Position = 0;

            Byte[] encryptedBytes = new Byte[myMemoryStream.Length];

            myMemoryStream.Read(encryptedBytes, 0, encryptedBytes.Length);



            // Close all the streams.

            myEncryptionStream.Close();

            myMemoryStream.Close();

            EncryptloginID = Convert.ToBase64String(encryptedBytes);

            return EncryptloginID;
        }

        public string Decrypt(string EncryptedValue)
        {
            Byte[] encryptedPasswordBytes = Convert.FromBase64String(EncryptedValue);

            Byte[] textBytes;

            String plainTextValue;

            UTF8Encoding encoder = new UTF8Encoding();


            // Perform Decryption

            //-------------------

            // Create an instances of the decryption algorithm (Rinjdael AES) for the encryption to perform,

            // a memory stream used to store the decrypted data temporarily, and

            // a crypto stream that performs the decryption algorithm.

            RijndaelManaged rmEncryption = new RijndaelManaged();

            MemoryStream myMemoryStream = new MemoryStream();

            CryptoStream myDecryptionStream = new CryptoStream(myMemoryStream, rmEncryption.CreateDecryptor(key, vector), CryptoStreamMode.Write);



            // Use the crypto stream to perform the decryption on the encrypted data in the byte array.

            myDecryptionStream.Write(encryptedPasswordBytes, 0, encryptedPasswordBytes.Length);

            myDecryptionStream.FlushFinalBlock();



            // Retrieve the decrypted data from the memory stream, and write it to a separate byte array.

            myMemoryStream.Position = 0;

            textBytes = new Byte[myMemoryStream.Length];

            myMemoryStream.Read(textBytes, 0, textBytes.Length);



            // Close all the streams.

            myDecryptionStream.Close();

            myMemoryStream.Close();



            // Convert the bytes to a string and display it.

            plainTextValue = encoder.GetString(textBytes);

            return plainTextValue;
        }
    }
}
