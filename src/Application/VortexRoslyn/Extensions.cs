using System.Text;

namespace S100Framework.Applications
{
    internal static class Extensions
    {
        public static string ToString(this StringBuilder builder, string indent) {
            var lines = builder.ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var text = lines[0];
            for (int i = 1; i < lines.Length - 1; i++) {
                text += Environment.NewLine + indent + lines[i];
            }
            return text + Environment.NewLine + indent + lines.Last();
        }
    }
}
