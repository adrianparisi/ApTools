using System;
using System.IO;
using System.Windows.Forms;

namespace SomeTools
{
    public class ExceptionLogger
    {
        public static string Path
        {
            get { return Application.StartupPath + "\\logs"; }
        }

        public static string FileName
        {
            get { return "error.log"; }
        }

        /// <summary>
        /// Gets the path with the file name.
        /// </summary>
        public static string FullName
        {
            get { return Path + "\\" + FileName; }
        }
        

        /// <summary>
        /// Logs the exception.
        /// </summary>
        public static void Log(Exception exception)
        {
            try
            {
                if (!Directory.Exists(Path))
                    Directory.CreateDirectory(Path);
                
                StreamWriter writer = null;

                if (!File.Exists(FullName))
                {
                    FileStream stream = File.Create(FullName);
                    stream.Close();

                    writer = File.AppendText(FullName);
                }
                else
                {
                    writer = File.AppendText(FullName);
                    writer.WriteLine();
                    writer.WriteLine();
                }

                writer.WriteLine(DateTime.Now);
                writer.WriteLine(exception.ToString());
                writer.Flush();
                writer.Close();
            }
            catch
            {
                // you can do nothing more.
            }
        }

        /// <summary>
        /// Handleds the unhandled exceptions.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="UnhandledExceptionEventArgs"/> instance containing the event data.</param>
        public static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = (Exception)e.ExceptionObject;

            ExceptionLogger.Log(exception);
            MessageBox.Show("Error: " + exception.Message, "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
