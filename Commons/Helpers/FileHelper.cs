using System;
using System.IO;
using Commons.Exceptions;
using Commons.Helpers.Objects;
using Commons.Logging;

namespace Commons.Helpers
{
    public static class FileHelper
    {
        public static byte[] ReadData(string pathToSourceFile)
        {
            var fileStream = new FileStream(pathToSourceFile, FileMode.Open, FileAccess.Read);

            try
            {
                var length = (int)fileStream.Length;
                var buffer = new byte[length];

                fileStream.Read(buffer, 0, length);

                return buffer;
            }
            finally
            {
                fileStream.Close();
            }
        }


        public static void SaveData(byte[] source, string pathToResultFile)
        {
            var resultDirectory = Path.GetDirectoryName(pathToResultFile);


            if (resultDirectory.IsNotEmpty() && Directory.Exists(resultDirectory) == false)
            {
                Directory.CreateDirectory(resultDirectory);
            }


            var resultFile = new FileStream(pathToResultFile, FileMode.Create);

            try
            {
                resultFile.Write(source, 0, source.Length);
            }
            finally
            {
                resultFile.Close();
            }
        }


        public static string ReadText(string path)
        {
            var streamReader = new StreamReader(path);

            var result = streamReader.ReadToEnd();

            streamReader.Close();

            return result;
        }

        public static void SaveText(string text, string destinationPath)
        {
            var resultDirectory = Path.GetDirectoryName(destinationPath);

            if (Directory.Exists(resultDirectory) == false) Directory.CreateDirectory(resultDirectory);

            var streamWriter = new StreamWriter(destinationPath);
            streamWriter.Write(text);
            streamWriter.Close();
        }



        public static byte[] GetContentData(string path)
        {
            try
            {
                return ReadData(path);
            }
            catch (Exception exception)
            {
                Log.Error(exception);

                throw new DownloadFileException(
                                String.Format("При получении содержимого файла произошла ошибка. Путь до файла '{0}'", path),
                                exception
                            );
            }
        }
    }
}