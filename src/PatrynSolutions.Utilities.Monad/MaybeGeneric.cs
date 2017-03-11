namespace PatrynSolutions.Utilities.Monad
{
    using System;

    public struct Maybe<T>
    {

        #region Constructors

        /// <summary>
        /// Creates a new <see cref="Maybe{T}"/> with the value given. If the value is null, it will display as if no value were given.
        /// </summary>
        /// <param name="value">The value to be wrapped.</param>
        public Maybe(T value) 
        {
            HasValue = value != null;
            Value = value;

            HasMessage =
            IsExceptionState = false;

            Message = null;
            Exception = null;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe{T}"/> with the message. If the parameter <paramref name="isMessage"/> is true, or the wrapped 
        /// type is not string, a valueless object with a message will be created. Should the type be string, or a derviation, the string 
        /// will be set as the value.
        /// </summary>
        /// <param name="value">The string message or value to be wrapped.</param>
        /// <param name="isMessage">Helps determine if the string is a message.</param>
        public Maybe(string value, bool isMessage = false)
        {
            //Assume that if "isMessage" is false, but type is not string, that the string IS a message.
            if (HasMessage = (isMessage || typeof(T) != typeof(string)))
            {
                Message = value;

                Value = default(T);
                HasValue = false;
            }
            else
            {
                //Shouldn't throw as only strings or derived types should make it here.
                //But just in case...
                try
                {
                    Value = (T)Convert.ChangeType(value, typeof(T));
                    HasValue = true;
                }
                catch
                {
                    Value = default(T);
                    HasValue = false;
                }

                HasMessage = false;
                Message = null;
            }

            IsExceptionState = false;
            Exception = null;
        }


        public Maybe(Exception exception)
        {
            IsExceptionState = exception != null;
            Exception = exception;

            Value = default(T);
            Message = null;

            HasValue =
            HasMessage = false;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe{T}"/> with the message and exception, but no value.
        /// </summary>
        /// <param name="message">The message to be displayed to the user.</param>
        /// <param name="exception">The exception thrown within the called code.</param>
        public Maybe(string message, Exception exception)
        {
            HasMessage = !string.IsNullOrEmpty(message);
            Message = message;

            IsExceptionState = exception != null;
            Exception = exception;

            HasValue = false;
            Value = default(T);
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Creates a new <see cref="Maybe{T}"/> with no value.
        /// </summary>
        /// <returns><see cref="Maybe{T}"/> with no value.</returns>
        public static Maybe<T> Empty()
        {
            return new Maybe<T>();
        }

        #endregion Public Methods

        #region Implicit Operators

        public static implicit operator T (Maybe<T> maybe)
        {
            return maybe.Value;
        }

        public static implicit operator Maybe<T> (T value)
        {
            return new Maybe<T>(value);
        }

        public static implicit operator Maybe<T> (string message)
        {
            return new Maybe<T>(message);
        }

        public static implicit operator Maybe<T> (Exception exception)
        {
            return new Maybe<T>(exception);
        }

        #endregion Implicit Operators

        #region Properties

        /// <summary>
        /// The value for the caller.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Whether the maybe has a value for the caller.
        /// </summary>
        public bool HasValue { get; private set; }

        /// <summary>
        /// True if an exception was thrown and wrapped.
        /// </summary>
        public bool IsExceptionState { get; private set; }

        /// <summary>
        /// The exception thrown during the user's request.
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// True if there is a message for the caller to be returned.
        /// </summary>
        public bool HasMessage { get; private set; }

        /// <summary>
        /// A friendly message to be displayed to the user.
        /// </summary>
        public string Message { get; private set; }

        #endregion Properties
    }
}
