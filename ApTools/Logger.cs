using System;
using System.IO;
using System.Windows.Forms;

namespace ApTools
{
    public class Logger
    {
        private static string path = Application.StartupPath + "\\logs";
        private static string file = "error.log";
        private static string fullName = path + "\\" + file;

        public static void LogException(Exception ex)
        {
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                
                StreamWriter writer = null;

                if (!File.Exists(fullName))
                {
                    FileStream stream = File.Create(fullName);
                    stream.Close();

                    writer = File.AppendText(fullName);
                }
                else
                {
                    writer = File.AppendText(fullName);
                    writer.WriteLine();
                    writer.WriteLine();
                }

                writer.WriteLine(DateTime.Now);
                writer.WriteLine(ex.ToString());
                writer.Flush();
                writer.Close();
            }
            catch
            {
                // Ya no se puede hacer nada mas.
            }
        }

        public static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception exception = (Exception)e.ExceptionObject;

                Logger.LogException(exception);
                MessageBox.Show("Error: " + exception.Message, "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception)
            {
                // mostrar cartel
            }
        }
    }
}
