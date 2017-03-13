namespace PatrynSolutions.Utilities.Monad
{
    using System;
    using System.Collections.Generic;

    public static class MaybeExtensions
    {

        #region Maybe Extensions

        /// <summary>
        /// Creates an empty <see cref="Maybe"/> with the <see cref="Exception"/> thrown.
        /// </summary>
        /// <param name="exception">The exception thrown by the callee.</param>
        /// <returns>An empty <see cref="Maybe"/> with the exception thrown in the called code.</returns>
        public static Maybe ToMaybe(this Exception exception)
        {
            return new Maybe(exception);
        }

        /// <summary>
        /// Creates an empty <see cref="Maybe"/> with a new message for the caller.
        /// </summary>
        /// <param name="message">The message for the caller.</param>
        /// <returns>An empty <see cref="Maybe"/> with a message for the caller.</returns>
        public static Maybe ToMaybe(this string message)
        {
            return new Maybe(message);
        }
        
        #endregion Maybe Extensions

        #region Maybe Generic Extensions

        /// <summary>
        /// Wraps the value in a new <see cref="Maybe{T}"/>. If the value is null, or equal to the default of the type, 
        /// an empty maybe will be created.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Maybe<T> ToMaybe<T>(this T value)
        {
            if (value == null || (value is object && EqualityComparer<T>.Default.Equals(default(T), value)))
            {
                return Maybe<T>.Empty();
            }
            return new Maybe<T>(value);
        }

        /// <summary>
        /// Creates an empty <see cref="Maybe{T}"/> with the exception thrown in the called code.
        /// </summary>
        /// <typeparam name="T">The type the <see cref="Maybe{T}"/> is wrapping</typeparam>
        /// <param name="exception">The <see cref="Exception"/> thrown in the caller code.</param>
        /// <returns>An empty <see cref="Maybe{T}"/> with the thrown exception from the caller's code.</returns>
        public static Maybe<T> ToMaybe<T>(this Exception exception)
        {
            return new Maybe<T>(exception);
        }

        /// <summary>
        /// This one might get a bit wonky if you need to return <see cref="Maybe{string}"/> and the string you're 
        /// setting is a message, not the value.
        /// </summary>
        /// <typeparam name="T">The type of the maybe wrapper to create.</typeparam>
        /// <param name="value">The message for the caller.</param>
        /// <param name="isMessage">Helps determine if the string is a messsage, or value for string types and derivations.</param>
        /// <returns>An empty <see cref="Maybe{T}"/> with a message for the caller.</returns>
        public static Maybe<T> ToMaybe<T>(this string value, bool isMessage = false)
        {
            return new Maybe<T>(value, isMessage);
        }
        
        #endregion Maybe Generic Extensions
    }
}
