namespace PatrynSolutions.Utilities.Monad
{
    using System;

    public struct Maybe
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
            IsExceptionState = false;

            Message = null;
            Exception = null;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe"/> with the <paramref name="exception"/>.
        /// </summary>
        /// <param name="exception">The exception thrown within the called code.</param>
        public Maybe(Exception exception)
        {
            IsExceptionState = exception != null;
            Exception = exception;

            Message = null;

            HasValue =
            Value =
            HasMessage = false;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe"/> with the given <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message to be displayed to the user.</param>
        public Maybe(string message)
        {
            HasMessage = !string.IsNullOrEmpty(message);
            Message = message;

            Exception = null;

            IsExceptionState =
            HasValue =
            Value = false;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe"/> with a message and exception, but no value.
        /// </summary>
        /// <param name="message">The message to be displayed to the user.</param>
        /// <param name="exception">The exception thrown within the called code.</param>
        public Maybe(string message, Exception exception)
        {
            IsExceptionState = exception != null;
            Exception = exception;

            HasMessage = !string.IsNullOrEmpty(message);
            Message = message;

            HasValue =
            Value = false;
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

        #endregion Public Methods

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

        #endregion Properties
    }
}
