using System.Text;

namespace System.IO
{
    public static class StreamExtensions
    {
        public static string ReadString(this Stream stream)
        {
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                string req = reader.ReadToEnd();
                reader.Close();
                return req;
            }
        }
    }
}
