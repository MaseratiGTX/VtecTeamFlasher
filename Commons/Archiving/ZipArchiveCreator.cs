using System.Collections.Generic;
using System.IO;
using System.Text;
using Ionic.Zip;

namespace Commons.Archiving
{
    public class ZipArchiveCreator
    {
        private readonly Dictionary<string, byte[]> filesContentToArchive = new Dictionary<string, byte[]>( );


        public ZipArchiveCreator(params string[] files)
        {
            foreach (var file in files)
            {
                filesContentToArchive.Add(file, File.ReadAllBytes(file));
            }
        }


        public ZipArchiveCreator(Dictionary<string, byte[]> filesContent)
        {
            foreach (KeyValuePair<string, byte[]> fileContent in filesContent)
            {
                filesContentToArchive[fileContent.Key] = fileContent.Value;
            }
        }


        public byte[] CreateArchive()
        {
            var archiveFile = new ZipFile
                          {
                              ProvisionalAlternateEncoding = Encoding.GetEncoding(866),
                          };



            foreach (var file in filesContentToArchive)
            {
                archiveFile.AddEntry(file.Key, file.Value);
            }


            var archiveMemoryStream = new MemoryStream();

            archiveFile.Save(archiveMemoryStream);


            return archiveMemoryStream.ToArray();
        }
    }
}