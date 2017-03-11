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

        

        #endregion Properties
    }
}
