namespace PatrynSolutions.Utilities.Monad
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A definition of of properties for a maybe construct to help ensure a more standard response, along with a guarantee of some response.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public interface IMaybe<TValue>
    {
        /// <summary>
        /// The value wrapped by this maybe construct.
        /// </summary>
        TValue Value { get; }
        /// <summary>
        /// Indicates whether this maybe has a value.
        /// </summary>
        bool HasValue { get; }
        /// <summary>
        /// A message designed to be used as a log message, or more detailed "ugly" message for developers.
        /// </summary>
        string Message { get; }
        /// <summary>
        /// Indicates whether this maybe has a message.
        /// </summary>
        bool HasMessage { get; }
        /// <summary>
        /// A message to be presented to the user.
        /// </summary>
        string FriendlyMessage { get; }
        /// <summary>
        /// Indicates whether this maybe has a friendly message.
        /// </summary>
        bool HasFriendlyMessage { get; }
        /// <summary>
        /// An exception thrown in the called code and wrapped in this maybe construct.
        /// </summary>
        Exception Exception { get; }
        /// <summary>
        /// Indicates if this maybe contains an exception, or not empty list of exceptions.
        /// </summary>
        bool IsExceptionState { get; }
        /// <summary>
        /// An integer to map to a user/developer defined error table indicating a problem.
        /// </summary>
        int ErrorCode { get; }
        /// <summary>
        /// Indicates if this maybe contains an error code.
        /// </summary>
        bool HasErrorCode { get; }
        /// <summary>
        /// A list of exceptions, usually meant for cascading failures within code. This is a side option to embedding the exceptions within the inner exception of each parent.
        /// </summary>
        IList<Exception> Exceptions { get; }
    }
}
