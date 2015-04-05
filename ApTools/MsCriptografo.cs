using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApTools
{
    public class MsCriptografo
    {
        public string Encriptar(string texto)
        {
            #region Validar argumento

            if (texto == null)
                throw new ArgumentNullException("texto");

            if (texto == String.Empty)
                throw new ArgumentException("La cadena texto no debe estar vacía");

            if (texto.Length > 10)
                throw new ArgumentException("La cadena texto debe tener una logitud menor o igual a diez caracteres");

            #endregion Validar argumento


            char[] szPass = texto.ToCharArray(); 
            int nStrlen, i, e;

            nStrlen = szPass.Length;

            if (nStrlen == 1) e = 2;
            else e = nStrlen * 2;

            for (i = 0; i < nStrlen; i++)
            {
                szPass[i] = (char)(szPass[i] + e);
                e--;
            }

            return szPass.ToString();
        }
    }
}
