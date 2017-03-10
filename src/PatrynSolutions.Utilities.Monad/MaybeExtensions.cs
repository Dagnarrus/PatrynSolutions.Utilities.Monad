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

        /// <summary>
        /// Ensures that the <see cref="Maybe"/> is not null and attempts to retrieve the value. 
        /// If this maybe is null, an empty one will be created and the default for the value will be retrieved.
        /// </summary>
        /// <param name="maybe">This <see cref="Maybe"/>.</param>
        /// <returns>The value wrapped within this maybe. If the <see cref="Maybe"/> is null, 
        /// an empty maybe will be created and the default value will be returned.</returns>
        public static bool Value(this Maybe maybe)
        {
            if (maybe == null)
            {
                maybe = Maybe.Empty();
            }

            return maybe.Value;
        }

        /// <summary>
        /// Ensures that the <see cref="Maybe"/> is not null and attempts to retrieve the message.
        /// If this maybe is null, an empty one will be created and null will be returned for the message.
        /// </summary>
        /// <param name="maybe">This <see cref="Maybe"/>.</param>
        /// <returns>The message contained within this maybe. If the <see cref="Maybe"/> is null. 
        /// An empty maybe will be created and a null will be returned.</returns>
        public static string Message(this Maybe maybe)
        {
            if (maybe == null)
            {
                maybe = Maybe.Empty();
            }

            return maybe.Message;
        }

        /// <summary>
        /// Ensures that the <see cref="Maybe"/> is not null and attempts to retrieve the exception.
        /// If this maybe is null, an empty one will be created and null will be returned for the exception.
        /// </summary>
        /// <param name="maybe">This <see cref="Maybe"/>.</param>
        /// <returns>The exception contained within this maybe. If the <see cref="Maybe"/> is null. 
        /// An empty maybe will be created and a null will be returned.</returns>
        public static Exception Exception(this Maybe maybe)
        {
            if (maybe == null)
            {
                maybe = Maybe.Empty();
            }

            return maybe.Exception;
        }

        /// <summary>
        /// Ensures that the <see cref="Maybe"/> is not null and retrieves the value for <see cref="MaybeBase.HasValue"/>.
        /// If this maybe is null an empty one will be created.
        /// </summary>
        /// <param name="maybe">This <see cref="Maybe"/>.</param>
        /// <returns><see cref="true"/> if this maybe has a value, <see cref="false"/> otherwise.</returns>
        public static bool HasValue(this Maybe maybe)
        {
            if (maybe == null)
            {
                maybe = Maybe.Empty();
            }

            return maybe.HasValue;
        }

        /// <summary>
        /// Ensures that the <see cref="Maybe"/> is not null and retrieves the value for <see cref="MaybeBase.HasMessage"/>.
        /// If this maybe is null an empty one will be created.
        /// </summary>
        /// <param name="maybe">This <see cref="Maybe"/>.</param>
        /// <returns><see cref="true"/> if this maybe has a message, <see cref="false"/> otherwise.</returns>
        public static bool HasMessage(this Maybe maybe)
        {
            if (maybe == null)
            {
                maybe = Maybe.Empty();
            }

            return maybe.HasMessage;
        }

        /// <summary>
        /// Ensures that the <see cref="Maybe"/> is not null and retrieves the value for <see cref="MaybeBase.IsExceptionState"/>.
        /// If this maybe is null an empty one will be created.
        /// </summary>
        /// <param name="maybe">This <see cref="Maybe"/>.</param>
        /// <returns><see cref="true"/> if this maybe has a message, <see cref="false"/> otherwise.</returns>
        public static bool IsExceptionState(this Maybe maybe)
        {
            if (maybe == null)
            {
                maybe = Maybe.Empty();
            }

            return maybe.IsExceptionState;
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

        /// <summary>
        /// Ensures that the <see cref="Maybe{T}"/> is not null and attempts to retrieve the value. 
        /// If this maybe is null, an empty one will be created and the default for the value will be retrieved.
        /// </summary>
        /// <typeparam name="T">The type this maybe is wrapping.</typeparam>
        /// <param name="maybe">This <see cref="Maybe{T}"/>.</param>
        /// <returns>The value wrapped within this maybe. If the <see cref="Maybe{T}"/> is null. 
        /// The default value of <typeparamref name="T"/> will be returned.</returns>
        public static T Value<T>(this Maybe<T> maybe)
        {
            if (maybe == null)
            {
                maybe = Maybe<T>.Empty();
            }

            return maybe.Value;
        }

        /// <summary>
        /// Ensures that the <see cref="Maybe{T}"/> is not null and attempts to retrieve the message.
        /// If this maybe is null, an empty one will be created and null will be returned for the message.
        /// </summary>
        /// <typeparam name="T">The type wrapped in this maybe.</typeparam>
        /// <param name="maybe">This <see cref="Maybe{T}"/>.</param>
        /// <returns>The message contained within this maybe. If the <see cref="Maybe{T}"/> is null. 
        /// An empty maybe will be created and a null will be returned.</returns>
        public static string Message<T>(this Maybe<T> maybe)
        {
            if (maybe == null)
            {
                maybe = Maybe<T>.Empty();
            }

            return maybe.Message;
        }

        /// <summary>
        /// Ensures that the <see cref="Maybe{T}"/> is not null and attempts to retrieve the exception.
        /// If this maybe is null, an empty one will be created and null will be returned for the exception.
        /// </summary>
        /// <typeparam name="T">The type wrapped in this maybe.</typeparam>
        /// <param name="maybe">This <see cref="Maybe{T}"/>.</param>
        /// <returns>The exception contained within this maybe. If the <see cref="Maybe{T}"/> is null. 
        /// An empty maybe will be created and a null will be returned.</returns>
        public static Exception Exception<T>(this Maybe<T> maybe)
        {
            if (maybe == null)
            {
                maybe = Maybe<T>.Empty();
            }

            return maybe.Exception;
        }

        /// <summary>
        /// Ensures that the <see cref="Maybe{T}"/> is not null and retrieves the value for <see cref="MaybeBase.HasValue"/>.
        /// If this maybe is null an empty one will be created.
        /// </summary>
        /// <typeparam name="T">The type wrapped in this maybe.</typeparam>
        /// <param name="maybe">This <see cref="Maybe{T}"/>.</param>
        /// <returns><see cref="true"/> if this maybe has a value, <see cref="false"/> otherwise.</returns>
        public static bool HasValue<T>(this Maybe<T> maybe)
        {
            if (maybe == null)
            {
                maybe = Maybe<T>.Empty();
            }

            return maybe.HasValue;
        }

        /// <summary>
        /// Ensures that the <see cref="Maybe{T}"/> is not null and retrieves the value for <see cref="MaybeBase.HasMessage"/>.
        /// If this maybe is null an empty one will be created.
        /// </summary>
        /// <typeparam name="T">The type wrapped in this maybe.</typeparam>
        /// <param name="maybe">This <see cref="Maybe{T}"/>.</param>
        /// <returns><see cref="true"/> if this maybe has a message, <see cref="false"/> otherwise.</returns>
        public static bool HasMessage<T>(this Maybe<T> maybe)
        {
            if (maybe == null)
            {
                maybe = Maybe<T>.Empty();
            }

            return maybe.HasMessage;
        }

        /// <summary>
        /// Ensures that the <see cref="Maybe{T}"/> is not null and retrieves the value for <see cref="MaybeBase.IsExceptionState"/>.
        /// If this maybe is null an empty one will be created.
        /// </summary>
        /// <typeparam name="T">The type wrapped in this maybe.</typeparam>
        /// <param name="maybe">This <see cref="Maybe{T}"/>.</param>
        /// <returns><see cref="true"/> if this maybe has a message, <see cref="false"/> otherwise.</returns>
        public static bool IsExceptionState<T>(this Maybe<T> maybe)
        {
            if (maybe == null)
            {
                maybe = Maybe<T>.Empty();
            }

            return maybe.IsExceptionState;
        }

        #endregion Maybe Generic Extensions
    }
}
