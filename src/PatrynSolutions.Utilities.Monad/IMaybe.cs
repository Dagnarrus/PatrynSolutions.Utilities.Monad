namespace PatrynSolutions.Utilities.Monad
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public interface IMaybe<TValue>
    {
        /// <summary>
        /// 
        /// </summary>
        TValue Value { get; }
        /// <summary>
        /// 
        /// </summary>
        bool HasValue { get; }
        /// <summary>
        /// 
        /// </summary>
        string Message { get; }
        /// <summary>
        /// 
        /// </summary>
        bool HasMessage { get; }
        /// <summary>
        /// 
        /// </summary>
        string FriendlyMessage { get; }
        /// <summary>
        /// 
        /// </summary>
        bool HasFriendlyMessage { get; }
        /// <summary>
        /// 
        /// </summary>
        Exception Exception { get; }
        ///
        bool IsExceptionState { get; }
        /// <summary>
        /// 
        /// </summary>
        int ErrorCode { get; }
        /// <summary>
        /// 
        /// </summary>
        bool HasErrorCode { get; }
        /// <summary>
        /// 
        /// </summary>
        IList<Exception> ExceptionList { get; }
    }
}
