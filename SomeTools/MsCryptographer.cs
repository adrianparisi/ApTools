using System;
using System.Text;

namespace SomeTools
{
    public class MsCryptographer
    {
        /// <summary>
        /// Encrypts the password with the MsGestion algorithm.
        /// </summary>
        /// <returns>The encrypted text.</returns>
        /// <exception cref="System.ArgumentNullException">text</exception>
        /// <exception cref="System.ArgumentException"></exception>
        public string Encrypt(string text)
        {
            this.ValidateArgument(text);

            char[] array = text.Reverse().ToUpper().ToCharArray();
            StringBuilder encrypted = new StringBuilder(text.Length);

            for (int i = 0; i < array.Length; i++)
            {
                char letter = array[i];

                encrypted.Append((char)((int)letter + this.Offset(array, i)));
            }

            return encrypted.ToString();
        }

        /// <summary>
        /// Dencrypts the specified hash with the MsGestion algorithm.
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
            {
                char letter = array[i];

                dencrypted.Append((char)((int)letter - this.Offset(array, i)));
            }
            
            return dencrypted.ToString().Reverse().ToLower();
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

        private int Offset(char[] array, int position)
        {
            return array.Length * 2 - position;
        }
    }
}
