using System.Text;

namespace desafiodev.infra.crosscutting.Extensions
{
    public static class StringExtensions
    {
        public static string FromBase64(this string value)
        {
            return Encoding.UTF8.GetString(System.Convert.FromBase64String(value));
        }
    }
}