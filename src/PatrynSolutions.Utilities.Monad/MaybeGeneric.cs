namespace PatrynSolutions.Utilities.Monad
{
    using System;

    public class Maybe<T> : MaybeBase
    {

        #region Constructors

        /// <summary>
        /// Creates a new <see cref="Maybe{T}"/> with no value.
        /// </summary>
        public Maybe() : base() { }

        /// <summary>
        /// Creates a new <see cref="Maybe{T}"/> with the value given. If the value is null, it will display as if no value were given.
        /// </summary>
        /// <param name="value">The value to be wrapped.</param>
        public Maybe(T value) 
        {
            HasValue = value != null;
            HasMessage = false;
            IsExceptionState = false;
            Value = value;
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
                catch { }
            }

            IsExceptionState = false;
        }


        public Maybe(Exception exception) : base(exception) { }

        /// <summary>
        /// Creates a new <see cref="Maybe{T}"/> with the message and exception, but no value.
        /// </summary>
        /// <param name="message">The message to be displayed to the user.</param>
        /// <param name="exception">The exception thrown within the called code.</param>
        public Maybe(string message, Exception exception) : base(message, exception) { }

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

        #region Properties

        /// <summary>
        /// The value for the caller.
        /// </summary>
        public T Value { get; private set; }

        #endregion Properties
    }
}
