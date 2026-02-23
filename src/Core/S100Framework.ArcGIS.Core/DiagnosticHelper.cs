using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ArcGIS.Desktop.Framework;

namespace ArcGIS.Core
{
    public static class DiagnosticHelper
    {
        internal static string CurrentMemberName([CallerMemberName] string? caller = null) => caller;

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static string GetMethodName() {
            var st = new StackTrace(new StackFrame(1));
            var fullName = st.GetFrame(0)!.GetMethod()!.ReflectedType!.FullName!;
            var parts = fullName.Split('+');
            if (parts.Length > 1 && parts[1].Contains('>') && parts[1].Contains('<')) {
                var idxStart = parts[1].IndexOf('<') + 1;
                var idxEnd = parts[1].LastIndexOf('>');
                var name = parts[1].Substring(idxStart, idxEnd - idxStart);
                return $@"{parts[0]}.{name}()";
            }
            else return $@"{st.GetFrame(0)!.GetMethod()!.Name}";
        }

        public static void Start([CallerMemberName] string? caller = null) => System.Diagnostics.Trace.WriteLine($@"Called: {caller}");

        public static void Error(string line) => ArcGIS.Desktop.Framework.Utilities.EventLog.Write
            (ArcGIS.Desktop.Framework.Utilities.EventLog.EventType.Error, $@"{System.Reflection.Assembly.GetExecutingAssembly().FullName!.Split(',')[0]}: {line}");

        public static void Error(System.Exception ex) => ArcGIS.Desktop.Framework.Utilities.EventLog.Write
            (ArcGIS.Desktop.Framework.Utilities.EventLog.EventType.Error, $@"{System.Reflection.Assembly.GetExecutingAssembly().FullName!.Split(',')[0]}: {ex}");


        public static void Warning(string line) => ArcGIS.Desktop.Framework.Utilities.EventLog.Write
              (ArcGIS.Desktop.Framework.Utilities.EventLog.EventType.Warning, $@"{System.Reflection.Assembly.GetExecutingAssembly().FullName!.Split(',')[0]}: {line}");
    }
}
