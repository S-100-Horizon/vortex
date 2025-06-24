using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace S100Framework.EventSourcing
{
    static class Ensure
    {
        /// <summary>
        /// Checks if the object is not null, otherwise throws
        /// </summary>
        /// <param name="value">Object to check for null value</param>
        /// <param name="name">Name of the object to be used in the exception message</param>
        /// <typeparam name="T">Object type</typeparam>
        /// <returns>Non-null object value</returns>
        /// <exception cref="ArgumentNullException"></exception>
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T NotNull<T>(T? value, [CallerArgumentExpression("value")] string? name = default) where T : class {
            ArgumentNullException.ThrowIfNull(value, name);

            return value;
        }

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T NotNull<T>(T? value, [CallerArgumentExpression("value")] string? name = default) where T : struct {
            ArgumentNullException.ThrowIfNull(value, name);

            return value.Value;
        }

        /// <summary>
        /// Throws a custom exception if the condition is not met
        /// </summary>
        /// <param name="condition">Condition to check</param>
        /// <param name="getException"></param>
        /// <exception cref="Exception"></exception>
        [DebuggerHidden]
        public static void IsTrue(bool condition, Func<Exception> getException) {
            if (!condition) throw getException();
        }
    }
}
