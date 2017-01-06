namespace PatrynSolutions.Utilities.Monad
{
    using System;

    public class Maybe : MaybeBase
    {

        #region Private Members

        private bool value;

        #endregion Private Members

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="Maybe"/> with no value.
        /// </summary>
        public Maybe() : base() { }

        /// <summary>
        /// Creates a new <see cref="Maybe"/> with the given value.
        /// </summary>
        /// <param name="value">The value of the result.</param>
        public Maybe(bool value)
        {
            HasValue = true;
            HasMessage = false;
            IsExceptionState = false;
            Value = value;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe"/> with the exception thrown in the called code.
        /// </summary>
        /// <param name="exception">The exception thrown within the called code.</param>
        public Maybe(Exception exception) : base(exception) { }

        /// <summary>
        /// Creates a new <see cref="Maybe"/> with the given message.
        /// </summary>
        /// <param name="message">The message to be displayed to the user.</param>
        public Maybe(string message) : base(message) { }

        /// <summary>
        /// Creates a new <see cref="Maybe"/> with a message and exception, but no value.
        /// </summary>
        /// <param name="message">The message to be displayed to the user.</param>
        /// <param name="exception">The exception thrown within the called code.</param>
        public Maybe(string message, Exception exception) : base(message, exception) { }

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

        #endregion Public Methods

        #region Properties

        /// <summary>
        /// The value of a caller's result. For non-generic <see cref="Maybe"/>, will only ever be true or false. 
        /// Thus it should be used to decalare the success or failure status of the call.
        /// </summary>
        public bool Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }

        #endregion Properties
    }
}
