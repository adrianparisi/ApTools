using System;
using System.Text;

namespace SomeTools
{
    /// <summary>
    /// Encrypts and decrypts text with the MsGestion algorithm.
    /// </summary>
    public class MsCryptographer
    {
        /// <summary>
        /// Encrypts the text with the MsGestion algorithm.
        /// </summary>
        /// <returns>The encrypted text.</returns>
        /// <exception cref="System.ArgumentNullException">text</exception>
        /// <exception cref="System.ArgumentException"></exception>
        public string Encrypt(string text)
        {
            this.ValidateArgument(text);

            char[] array = text.Reverse().ToCharArray();
            StringBuilder encrypted = new StringBuilder(text.Length);

            for (int i = 0; i < array.Length; i++)
                encrypted.Append(this.EncryptChar(array.Length, array[i], i));

            return encrypted.ToString();
        }

        private char EncryptChar(int length, char letter, int position)
        {
            return (char)((int)Char.ToUpper(letter) + this.Offset(length, position));
        }

        /// <summary>
        /// Dencrypts the specified text with the MsGestion algorithm.
        /// </summary>
        /// <returns>The dencrypted text.</returns>
        /// <exception cref="System.ArgumentNullException">text</exception>
        /// <exception cref="System.ArgumentException"></exception>
        public string Decrypt(string text)
        {
            this.ValidateArgument(text);

            char[] array = text.ToCharArray();
            StringBuilder dencrypted = new StringBuilder(text.Length);

            for (int i = 0; i < array.Length; i++)
                dencrypted.Append(this.DecryptChar(array.Length, array[i], i));
            
            return dencrypted.ToString().Reverse();
        }

        private char DecryptChar(int length, char letter, int position)
        {
            return Char.ToLower((char)((int)letter - this.Offset(length, position)));
        }

        private void ValidateArgument(string text)
        {
            if (text == null)
                throw new ArgumentNullException("text");

            if (text == String.Empty)
                throw new ArgumentException("The string must not be empty");

            if (text.Length > 10)
                throw new ArgumentException("The string must be less than or equal to ten characters logitud");
        }

        private int Offset(int length, int position)
        {
            return length * 2 - position;
        }
    }
}
