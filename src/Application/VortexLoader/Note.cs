using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TestNisImporter")]

namespace S100Framework.Applications
{
    internal sealed class Note
    {
        private ICollection<string> _headers { get; set; } = new List<string>();
        private ICollection<string> _content { get; set; } = new List<string>();

        internal string? Header {
            get {
                if (_headers.Count == 0)
                    return default;
                return string.Join(Environment.NewLine, _headers);
            }
        }

        internal string? Content {
            get {
                if (_content.Count == 0)
                    return default;
                return string.Join(Environment.NewLine, _content);
            }
        }

        private static readonly Regex headerRegex = new Regex(@"^[A-Z0-9ÆØÅ\s\W]+$", RegexOptions.Compiled);

        internal Note(string filePath) {
            var lines = File.ReadAllLines(filePath, Encoding.Latin1);

            foreach (var line in lines) {
                var trimmedLine = line.Trim();

                if (string.IsNullOrEmpty(trimmedLine))
                    continue;

                if (headerRegex.IsMatch(trimmedLine)) {
                    _headers.Add(trimmedLine);
                }
                else {
                    _content.Add(trimmedLine);
                }
            }
        }

    }
}
