namespace PatrynSolutions.Utilities.Monad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class MaybeBase
    {

        #region Constructors

        /// <summary>
        /// Creates a new <see cref="MaybeBase"/> object with no value.
        /// </summary>
        public MaybeBase()
        {
            HasValue = false;
            HasMessage = false;
            IsExceptionState = false;
        }

        /// <summary>
        /// Creates a new <see cref="MaybeBase"/> with the <see cref="System.Exception"/> thrown within the called code.
        /// </summary>
        /// <param name="exception">The exception thrown by the called code, for the further handling by the caller.</param>
        public MaybeBase(Exception exception)
        {
            HasValue = false;
            HasMessage = false;
            IsExceptionState = true;
            Exception = exception;
        }

        /// <summary>
        /// Creates a new <see cref="MaybeBase"/> with no value, but a message for the caller.
        /// </summary>
        /// <param name="message">The message to be displayed to the user.</param>
        public MaybeBase(string message)
        {
            HasValue = false;
            HasMessage = true;
            IsExceptionState = false;
            Message = message;
        }

        /// <summary>
        /// Creates a new <see cref="MaybeBase"/> with no value, but a message, and exception for the caller.
        /// </summary>
        /// <param name="message">The message to be displayed to the user.</param>
        /// <param name="exception">Th exception thrown within the called code.</param>
        public MaybeBase(string message, Exception exception)
        {
            HasValue = false;
            HasMessage = true;
            IsExceptionState = true;
            Message = message;
            Exception = exception;
        }

        #endregion Constructors
        
        #region Properties

        /// <summary>
        /// Whether the maybe has a value for the caller.
        /// </summary>
        public bool HasValue { get; protected set; }

        /// <summary>
        /// True if an exception was thrown and wrapped.
        /// </summary>
        public bool IsExceptionState { get; protected set; }

        /// <summary>
        /// The exception thrown during the user's request.
        /// </summary>
        public Exception Exception { get; protected set; }

        /// <summary>
        /// True if there is a message for the caller to be returned.
        /// </summary>
        public bool HasMessage { get; protected set; }

        /// <summary>
        /// A friendly message to be displayed to the user.
        /// </summary>
        public string Message { get; protected set; }

        #endregion Properties
    }
}
