using System.Security.Cryptography;
using System.Text;

namespace API.Services
{
    public class DataEncryptionSevice
    {
        private readonly byte[] IV =
        {
            0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
            0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
        };
        private readonly string passphrase = "ba3e03d9dc01a6eae5a29be363affa86cb5081700401c808ef273bff563046c9";

        /**
            Here, we are using a key derivation algorithm called PBKDF2 to turn the user passphrase into a random 
            fixed-length byte array. To achieve this we are using the static method Rfc2898DeriveBytes.Pbkdf2(). Note that we 
            could potentially use a password salt as the second parameter of this call. In this case, however, we are just using
            an empty salt for simplicity.

            Likewise, the AES implementation requires an initialization vector. We will use a 128-bit value called initialization 
            vector or IV to generate more entropy in the resulting encrypted data. This will make it more difficult to identify 
            patterns in it.
        */
        private byte[] DeriveKeyFromPassword()
        {
            var emptySalt = Array.Empty<byte>();
            var iterations = 1000;
            var desiredKeyLenght = 16; // 16bytes = 128 bits
            var hashMethod = HashAlgorithmName.SHA384;
            return Rfc2898DeriveBytes.Pbkdf2(
                Encoding.Unicode.GetBytes(passphrase),
                emptySalt,
                iterations,
                hashMethod,
                desiredKeyLenght);
        }

        /**
        First, we use the Aes.Create() factory method to obtain an instance of the Aes object that we will later use to obtain an
         encryptor. We generate our encryption key using the DeriveKeyFromPassword() method discussed earlier and add it to the 
         aes object along with our fixed initialization vector.

        Next, we go on and create an output MemoryStream that receives the encrypted data as it gets generated. We also need a 
        CryptoStream wrapping the output stream. Here, we are setting up the CryptoStream with an encryptor and CryptoStreamMode.
        Write so we can write our input text to it and get encrypted data written to the output stream.

        Finally, we write the user-provider clear text to the CryptoStream using the WriteAsync() method. It is important to 
        manually call the FlushFinalBlockAsync() on the cryptoStream object method so all the remaining bytes are written to the 
        output stream before we return its contents.
        */
        public async Task<byte[]> EncryptAsync(string text)
        {
            using Aes aes = Aes.Create();
            aes.Key = DeriveKeyFromPassword();
            aes.IV = IV;

            using MemoryStream outputStream = new();
            using CryptoStream cryptoStream = new(outputStream, aes.CreateEncryptor(), CryptoStreamMode.Write);

            await cryptoStream.WriteAsync(Encoding.Unicode.GetBytes(text));
            await cryptoStream.FlushFinalBlockAsync();

            return outputStream.ToArray();
        }

        /**
        Just like in our Encrypt() method, we set up the encryption key and IV. It is important to use the same values used 
        during encryption to decrypt successfully.

        Then, we set up our CryptoStream, this time, wrapped around a MemoryStream containing the encrypted data. Since this is a
         decryption operation, we use a decryptor instead of an encryptor and CryptoStreamMode.Read.

        Finally, we use CryptoStream.CopyToAsync() to copy the contents of cryptoStream into a newly created MemoryStream. At 
        this point, the encrypted data gets pulled from the input MemoryStream and put through the decrypt transformation.
        */
        public async Task<string> DecryptAsync(byte[] encrypted)
        {
            using Aes aes = Aes.Create();
            aes.Key = DeriveKeyFromPassword();
            aes.IV = IV;

            using MemoryStream inputStream = new(encrypted);
            using CryptoStream cryptoStream = new(inputStream, aes.CreateDecryptor(), CryptoStreamMode.Read);

            using MemoryStream outputStream = new();
            await cryptoStream.CopyToAsync(outputStream);

            return Encoding.Unicode.GetString(outputStream.ToArray());
        }

        public string EncryptAsString(byte[] encrypted)
        {
            return Convert.ToBase64String(encrypted);
        }
    }
}