namespace Security.Utils.Extensions
{
    public static class StreamExtension
    {
        public static async Task<string> ReasAsStringAsync(this Stream stream)
        {
            StreamReader reader = new(stream);

            string jsonBody = await reader.ReadToEndAsync();

            reader.Close();
            stream.Close();

            return jsonBody;
        }
    }
}
