namespace PatrynSolutions.Utilities.Monad
{
    using System;
    using System.Collections.Generic;

    public struct Maybe : IMaybe<bool>
    {

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="Maybe"/> with the given value.
        /// </summary>
        /// <param name="value">The value of the result.</param>
        public Maybe(bool value)
        {
            HasValue = true;
            Value = value;

            HasMessage = 
            HasFriendlyMessage =
            HasErrorCode =
            IsExceptionState = false;

            Message = 
            FriendlyMessage = null;
            ErrorCode = 0;
            Exception = null;
            Exceptions = new List<Exception>(0);
        }

        /// <summary>
        /// Creates a new <see cref="Maybe"/> with the <paramref name="exception"/>.
        /// </summary>
        /// <param name="exception">The exception thrown within the called code.</param>
        public Maybe(Exception exception)
        {
            IsExceptionState = exception != null;
            Exception = exception;
            Exceptions = new List<Exception>() { exception };

            Message = 
            FriendlyMessage = null;
            ErrorCode = 0;

            HasValue =
            Value =
            HasMessage = 
            HasFriendlyMessage =
            HasErrorCode = false;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe"/> with the <paramref name="exceptions"/>, and no value.
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

            Value = 
            HasValue =
            HasMessage =
            HasErrorCode =
            HasFriendlyMessage = false;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe"/> with the given <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message to be displayed to the user.</param>
        public Maybe(string message, bool isFriendlyMessage = false)
        {
            if (HasFriendlyMessage = isFriendlyMessage)
            {
                FriendlyMessage = message;

                HasMessage = false;
                Message = null;
            }
            else
            {
                HasMessage = true;
                Message = message;

                FriendlyMessage = null;
                HasFriendlyMessage = false;
            }

            ErrorCode = 0;
            Exception = null;
            Exceptions = new List<Exception>(0);

            IsExceptionState =
            HasErrorCode =
            HasValue =
            Value = false;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe"/> with a message and exception, but no value.
        /// </summary>
        /// <param name="message">The message to be displayed to the user.</param>
        /// <param name="exception">The exception thrown within the called code.</param>
        public Maybe(string message, Exception exception, bool isFriendlyMessage = false)
        {
            if (HasFriendlyMessage = isFriendlyMessage)
            {
                FriendlyMessage = message;

                HasMessage = false;
                Message = null;
            }
            else
            {
                HasMessage = true;
                Message = message;

                FriendlyMessage = null;
            }

            IsExceptionState = exception != null;
            Exception = exception;
            Exceptions = new List<Exception>() { exception };

            ErrorCode = 0;

            HasErrorCode = 
            HasValue =
            Value = false;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe"/> with the message and enumerable of exceptions, but no value.
        /// </summary>
        /// <param name="message">The message to be wrapped.</param>
        /// <param name="exceptions">The exceptions thrown within the called code blocks.</param>
        /// <param name="isFriendlyMessage"><see cref="true"/> if the message is a friendly message intended for the user.</param>
        public Maybe(string message, IEnumerable<Exception> exceptions, bool isFriendlyMessage = false)
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

            IsExceptionState = exceptions != null;
            Exceptions = new List<Exception>(exceptions ?? new Exception[0]);
            Exception = null;

            ErrorCode = 0;

            Value = 
            HasErrorCode =
            HasValue = false;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe"/> with an <paramref name="errorCode"/>, but no value.
        /// </summary>
        /// <param name="errorCode">The error code wrapped in this maybe.</param>
        public Maybe(int errorCode)
        {
            ErrorCode = errorCode;
            HasErrorCode = true;

            Message =
            FriendlyMessage = null;
            Exception = null;
            Exceptions = new List<Exception>(0);

            Value =
            HasValue =
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

            Value =
            HasValue =
            IsExceptionState = false;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe"/> with the given <paramref name="message"/>, <paramref name="friendlyMessage"/>, but no value.
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

            Value =
            HasValue =
            HasErrorCode =
            IsExceptionState = false;
        }

        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// Returns a new <see cref="Maybe"/> with no value.
        /// </summary>
        /// <returns><see cref="Maybe"/> with no value.</returns>
        public static Maybe Empty()
        {
            return new Maybe();
        }

        /// <summary>
        /// Returns a new <see cref="Maybe"/> with a value of <see cref="true"/>.
        /// </summary>
        /// <returns>A new <see cref="Maybe"/> with a value of <see cref="true"/></returns>
        public static Maybe Success()
        {
            return new Maybe(true);
        }

        /// <summary>
        /// Returns a new <see cref="Maybe"/> with a value of <see cref="false"/>.
        /// </summary>
        /// <returns>A new <see cref="Maybe"/> with a value of <see cref="false"/></returns>
        public static Maybe Failure()
        {
            return new Maybe(false);
        }

        /// <summary>
        /// Returns a new instance of <see cref="Maybe"/> with no value, and the <paramref name="message"/> set.
        /// </summary>
        /// <param name="message">The message to wrap</param>
        /// <returns>A new instance of <see cref="Maybe"/> with the wrapped message.</returns>
        public static Maybe Failure(string message)
        {
            return new Maybe(message);
        }

        /// <summary>
        /// Returnes a new instance of <see cref="Maybe"/> with no value, and the <paramref name="exception"/> set. 
        /// This will set <see cref="MaybeBase.IsExceptionState"/> to <c>true</c>.
        /// </summary>
        /// <param name="exception">The exception to wrap in the <see cref="Maybe"/></param>
        /// <returns>A new instance of <see cref="Maybe"/> with the wrapped exception.</returns>
        public static Maybe Failure(Exception exception)
        {
            return new Maybe(exception);
        }

        /// <summary>
        /// Creates a new <see cref="Maybe"/> with the given <paramref name="message"/> as a friendly message.
        /// </summary>
        /// <param name="message">The message to wrap as a friendly message.</param>
        /// <returns>A new <see cref="Maybe"/> with the given friendly message</returns>
        public static Maybe CreateFriendlyMessage(string message)
        {
            return new Maybe(message, isFriendlyMessage: true);
        }

        /// <summary>
        /// Creates a new <see cref="Maybe"/> with the given <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message to be wrapped.</param>
        /// <returns>A new <see cref="Maybe"/> with the given message wrapped.</returns>
        public static Maybe CreateMessage(string message)
        {
            return new Maybe(message);
        }

        #endregion Public Methods

        #region Implicit Operators

        public static implicit operator Maybe (bool value)
        {
            return new Maybe(value);
        }

        public static implicit operator bool (Maybe maybe)
        {
            return maybe.Value;
        }

        public static implicit operator Maybe (string message)
        {
            return new Maybe(message);
        }

        public static implicit operator Maybe (Exception exception)
        {
            return new Maybe(exception);
        }

        #endregion Implicit Operators

        #region Properties

        /// <summary>
        /// The value of a caller's result. For non-generic <see cref="Maybe"/>, will only ever be true or false. 
        /// Thus it should be used to decalare the success or failure status of the call.
        /// </summary>
        public bool Value { get; private set; }

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

        /// <summary>
        /// Indicates whether this maybe has a friendly message.
        /// </summary>
        public bool HasFriendlyMessage { get; private set; }

        /// <summary>
        /// A message to be presented to the user.
        /// </summary>
        public string FriendlyMessage { get; private set; }

        /// <summary>
        /// An integer to map to a user/developer defined error table indicating a problem.
        /// </summary>
        public int ErrorCode { get; private set; }

        /// <summary>
        /// Indicates if this maybe contains an error code.
        /// </summary>
        public bool HasErrorCode { get; private set; }

        /// <summary>
        /// A list of exceptions, usually meant for cascading failures within code. This is a side option to embedding the exceptions within the inner exception of each parent.
        /// </summary>
        public IList<Exception> Exceptions { get; private set; }

        #endregion Properties
    }
}
