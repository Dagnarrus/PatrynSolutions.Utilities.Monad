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
        /// <param name="exception"></param>
        public Maybe(Exception exception) : base(exception) { }

        /// <summary>
        /// Creates a new <see cref="Maybe"/> with the given message.
        /// </summary>
        /// <param name="message">The message for the caller.</param>
        public Maybe(string message) : base(message) { }

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
