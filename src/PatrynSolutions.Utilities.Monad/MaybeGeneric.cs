namespace PatrynSolutions.Utilities.Monad
{
    using System;
    using System.Collections.Generic;

    public struct Maybe<TValue> : IMaybe<TValue>
    {

        #region Constructors

        /// <summary>
        /// Creates a new <see cref="Maybe{TValue}"/> with the value given. If the value is null, it will display as if no value were given.
        /// </summary>
        /// <param name="value">The value to be wrapped.</param>
        public Maybe(TValue value) 
        {
            //Perhaps compare to default(TValue)?
            HasValue = !EqualityComparer<TValue>.Default.Equals(default(TValue), value);
            Value = value;

            HasMessage =
            HasFriendlyMessage = 
            HasErrorCode =
            IsExceptionState = false;

            Message =
            FriendlyMessage = null;
            ErrorCode = 0;
            Exception = null;
            //Do we want this to be a zero length list, or null? 
            Exceptions = new List<Exception>(0);
        }

        /// <summary>
        /// Creates a new <see cref="Maybe{TValue}"/> with the message. If the parameter <paramref name="isMessage"/> is true, or the wrapped 
        /// type is not string, a valueless object with a message will be created. Should the type be string, or a derviation, the string 
        /// will be set as the value.
        /// </summary>
        /// <param name="value">The string message or value to be wrapped.</param>
        /// <param name="isMessage">Helps determine if the string is a message.</param>
        public Maybe(string value, bool isMessage = false, bool isFriendlyMessage = false)
        {
            //Assume that if "isMessage" is false, but type is not string, that the string IS a message.
            if (HasMessage = (isMessage || typeof(TValue) != typeof(string)))
            {
                Message = value;

                HasFriendlyMessage = 
                HasValue = false;

                Value = default(TValue);
                FriendlyMessage = null;
            }
            else if (HasFriendlyMessage = (isFriendlyMessage || typeof(TValue) != typeof(string)))
            {
                FriendlyMessage = value;

                HasMessage = 
                HasValue = false;
                
                Value = default(TValue);
                Message = null;
            }
            else
            {
                //Shouldn't throw as only strings or derived types should make it here.
                //But just in case...
                try
                {
                    Value = (TValue)Convert.ChangeType(value, typeof(TValue));
                    HasValue = true;
                }
                catch
                {
                    Value = default(TValue);
                    HasValue = false;
                }

                HasMessage = 
                HasFriendlyMessage = false;

                Message = null;
                FriendlyMessage = null;
            }

            HasErrorCode = 
            IsExceptionState = false;

            ErrorCode = 0;
            Exception = null;
            Exceptions = new List<Exception>(0);
        }

        /// <summary>
        /// Creates a new <see cref="Maybe{TValue}"/> with the <paramref name="exception"/>.
        /// </summary>
        /// <param name="exception">The exception being wrapped.</param>
        public Maybe(Exception exception)
        {
            IsExceptionState = exception != null;
            Exception = exception;
            Exceptions = new List<Exception>() { exception };

            Value = default(TValue);
            Message =
            FriendlyMessage = null;
            ErrorCode = 0;


            HasValue =
            HasMessage =
            HasErrorCode = 
            HasFriendlyMessage = false;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe{TValue}"/> with the <paramref name="exceptions"/>, and no value.
        /// </summary>
        /// <param name="exceptions">An enumerable of collected to be wrapped and passed back.</param>
        public Maybe(IEnumerable<Exception> exceptions)
        {
            IsExceptionState = exceptions != null;
            Exceptions = new List<Exception>(exceptions);
            //Should we put the first exception in this property?
            Exception = null;

            Message =
            FriendlyMessage = null;

            ErrorCode = 0;
            Value = default(TValue);

            HasValue =
            HasMessage =
            HasErrorCode =
            HasFriendlyMessage = false;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe{TValue}"/> with the message and exception, but no value.
        /// </summary>
        /// <param name="message">The message to be displayed to the user.</param>
        /// <param name="exception">The exception thrown within the called code.</param>
        public Maybe(string message, Exception exception, bool isFriendlyMessage = false)
        {
            if (HasFriendlyMessage = isFriendlyMessage)
            {
                FriendlyMessage = message;

                Message = null;
                HasMessage = false;
            }
            else
            {
                Message = message;
                HasMessage = true;

                FriendlyMessage = null;
            }

            IsExceptionState = exception != null;
            Exception = exception;
            Exceptions = new List<Exception>() { exception };

            ErrorCode = 0;
            Value = default(TValue);

            HasErrorCode = 
            HasValue = false;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe{TValue}"/> with the given <paramref name="errorCode"/> and no value.
        /// </summary>
        /// <param name="errorCode">The error code to be wrapped.</param>
        public Maybe(int errorCode, bool isErrorCode = false)
        {
            //Assume that if the isErrorCode is false, but the type is not int, that it IS an error code
            if (HasErrorCode = (isErrorCode || typeof(TValue) != typeof(int)))
            {
                ErrorCode = errorCode;

                Value = default(TValue);
                HasValue = false;
            }
            else
            {
                //Should only get here if error code is false and the generic type is derivative of int.
                Value = (TValue)Convert.ChangeType(errorCode, typeof(TValue));
                HasValue = true;

                ErrorCode = 0;
            }

            Message =
            FriendlyMessage = null;

            Exception = null;
            Exceptions = new List<Exception>(0);

            HasMessage =
            HasFriendlyMessage =
            IsExceptionState = false;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe"/> with the given <paramref name="message"/>, <paramref name="errorCode"/>, but no value.
        /// </summary>
        /// <param name="message">The message to be wrapped.</param>
        /// <param name="errorCode">The error code to be wrapped.</param>
        /// <param name="isFriendlyMessage"><see cref="true"/> if the message should be considered a friendly message for the user. <see cref="false"/> otherwise.</param>
        public Maybe(string message, int errorCode, bool isFriendlyMessage = false)
        {
            if (HasFriendlyMessage = isFriendlyMessage)
            {
                FriendlyMessage = message;

                HasMessage = false;
                Message = null;
            }
            else
            {
                Message = message;
                HasMessage = true;

                FriendlyMessage = null;
            }

            ErrorCode = errorCode;
            HasErrorCode = true;

            Exception = null;
            Exceptions = new List<Exception>(0);

            Value = default(TValue);

            HasValue =
            IsExceptionState = false;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe{TValue}"/> with the given <paramref name="message"/>, <paramref name="friendlyMessage"/>, but no value.
        /// </summary>
        /// <param name="message">The message to be wrapped.</param>
        /// <param name="friendlyMessage">The friendly message to be wrapped.</param>
        public Maybe(string message, string friendlyMessage)
        {
            Message = message;
            FriendlyMessage = friendlyMessage;

            HasMessage =
            HasFriendlyMessage = true;

            ErrorCode = 0;
            Exception = null;
            Exceptions = new List<Exception>(0);

            Value = default(TValue);

            HasValue =
            HasErrorCode =
            IsExceptionState = false;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Creates a new <see cref="Maybe{TValue}"/> with no value.
        /// </summary>
        /// <returns><see cref="Maybe{TValue}"/> with no value.</returns>
        public static Maybe<TValue> Empty()
        {
            return new Maybe<TValue>();
        }

        /// <summary>
        /// Creates a new <see cref="Maybe{TValue}"/> with the given <paramref name="message"/> as a friendly message.
        /// </summary>
        /// <param name="message">The message to wrap as a friendly message.</param>
        /// <returns>A new <see cref="Maybe{TValue}"/> with the given friendly message</returns>
        public static Maybe<TValue> CreateFriendlyMessage(string message)
        {
            return new Maybe<TValue>(message, isFriendlyMessage: true);
        }

        /// <summary>
        /// Creates a new <see cref="Maybe{TValue}"/> with the given <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message to be wrapped.</param>
        /// <returns>A new <see cref="Maybe{TValue}"/> with the given message wrapped.</returns>
        public static Maybe<TValue> CreateMessage(string message)
        {
            return new Maybe<TValue>(message, isMessage: true);
        }

        #endregion Public Methods

        #region Implicit Operators

        /// <summary>
        /// Unwraps the value contained in the <see cref="Maybe{TValue}"/>
        /// </summary>
        /// <param name="maybe">The maybe that wrapped the value.</param>
        public static implicit operator TValue (Maybe<TValue> maybe)
        {
            return maybe.Value;
        }

        /// <summary>
        /// Returns the <see cref="Maybe{TValue}.HasValue"/>, unless the wrapped type is <see cref="bool"/>. Then it returns the <see cref="Maybe{TValue}.Value"/>.
        /// </summary>
        /// <param name="maybe">The maybe who's value is being unwrapped</param>
        public static implicit operator bool (Maybe<TValue> maybe)
        {
            if (maybe.Value is bool)
                return Convert.ToBoolean(maybe.Value);

            return maybe.HasValue;
        }

        /// <summary>
        /// Wraps the <paramref name="value"/> in a new <see cref="Maybe{TValue}"/>.
        /// </summary>
        /// <param name="value">The value to be wrapped.</param>
        public static implicit operator Maybe<TValue> (TValue value)
        {
            return new Maybe<TValue>(value);
        }

        /// <summary>
        /// Wraps the <paramref name="message"/> in a new <see cref="Maybe{TValue}"/>
        /// </summary>
        /// <param name="message">The message to be wrapped in the value.</param>
        public static implicit operator Maybe<TValue> (string message)
        {
            return new Maybe<TValue>(message);
        }

        /// <summary>
        /// Wraps the exception in a new <see cref="Maybe{TValue}"/>.
        /// </summary>
        /// <param name="exception">The exception to be wrapped.</param>
        public static implicit operator Maybe<TValue> (Exception exception)
        {
            return new Maybe<TValue>(exception);
        }

        #endregion Implicit Operators

        #region Properties

        /// <summary>
        /// The wrapped value for the caller.
        /// </summary>
        public TValue Value { get; private set; }

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
        /// A message that can be passed for logging purposes, for a developer, etc.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// A friendly message to be displayed to the user.
        /// </summary>
        public string FriendlyMessage { get; private set; }

        /// <summary>
        /// True if this maybe has a friendly message to be displayed to the user.
        /// </summary>
        public bool HasFriendlyMessage { get; private set; }

        /// <summary>
        /// An error code defined within your application to pass back, if exceptions are not desired.
        /// </summary>
        public int ErrorCode { get; private set; }

        /// <summary>
        /// True if this maybe has an error code.
        /// </summary>
        public bool HasErrorCode { get; private set; }

        /// <summary>
        /// A list of exceptions, usually meant for cascading failures within code. This is a side option to embedding the exceptions within the inner exception of each parent.
        /// </summary>
        public IList<Exception> Exceptions { get; private set; }

        #endregion Properties
    }
}
