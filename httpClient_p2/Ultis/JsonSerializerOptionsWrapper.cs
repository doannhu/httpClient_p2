using System.Text.Json;

namespace httpClient_p2.Ultis
{
    public class JsonSerializerOptionsWrapper
    {
        public JsonSerializerOptions Options { get; }

        public JsonSerializerOptionsWrapper()
        {
            Options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            Options.DefaultBufferSize = 10;
        }
    }
}
