using System.Web;
using Commons.Helpers.Objects;
using Commons.Serialization.Base64;

namespace WebAppCommons.Classes.Helpers
{
    public static class HttpResponseExtensions
    {
        public static void DownloadFile(this HttpResponse source, DownloadableFile file)
        {
            var contentData = file.ContentData.IsEmpty()
                                  ? file.ContentText.GetBytes(source.ContentEncoding)
                                  : file.ContentData;


            source.Clear();
            source.Buffer = false;
            source.AddHeader("Accept-Ranges", "bytes");
            source.AddHeader("Content-Disposition", "attachment;filename=\"" + file.FileName + "\"");
            source.AddHeader("Connection", "Keep-Alive");
            source.ContentType = file.ContentType;
            source.BinaryWrite(contentData);
            source.End();
        } 
    }
}