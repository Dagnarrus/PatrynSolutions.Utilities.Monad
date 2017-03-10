namespace UnitTests.NetStandard
{
    using System;

    using Xunit;

    using PatrynSolutions.Utilities.Monad;

    
    public class MaybeTests
    {

        #region Construction Tests

        [Fact]
        public void ConstructEmptyMaybe()
        {
            var maybe = new Maybe();

            Assert.False(maybe.HasValue);
            Assert.False(maybe.Value);

            Assert.False(maybe.HasMessage);
            Assert.Null(maybe.Message);

            Assert.False(maybe.IsExceptionState);
            Assert.Null(maybe.Exception);
        }

        [Fact]
        public void CunstructMaybeWithValue()
        {
            var maybe = new Maybe(true);

            Assert.True(maybe.HasValue);
            Assert.True(maybe.Value);

            Assert.False(maybe.HasMessage);
            Assert.Null(maybe.Message);

            Assert.False(maybe.IsExceptionState);
            Assert.Null(maybe.Exception);
        }

        [Fact]
        public void ConstructMaybeWithMessage()
        {
            var maybe = new Maybe("Test");

            Assert.False(maybe.HasValue);
            Assert.False(maybe.Value);

            Assert.True(maybe.HasMessage);
            Assert.True(!string.IsNullOrWhiteSpace(maybe.Message) && maybe.Message == "Test");

            Assert.False(maybe.IsExceptionState);
            Assert.Null(maybe.Exception);
        }

        [Fact]
        public void ConstructMaybeWithException()
        {
            var maybe = new Maybe(new Exception());

            Assert.False(maybe.HasValue);
            Assert.False(maybe.Value);

            Assert.False(maybe.HasMessage);
            Assert.Null(maybe.Message);

            Assert.True(maybe.IsExceptionState);
            Assert.NotNull(maybe.Exception);
        }

        #endregion Construction Tests

        #region Method Tests

        [Fact]
        public void CreateEmptyMaybe()
        {
            var maybe = Maybe.Empty();

            Assert.False(maybe.HasValue);
            Assert.False(maybe.Value);

            Assert.False(maybe.HasMessage);
            Assert.Null(maybe.Message);

            Assert.False(maybe.IsExceptionState);
            Assert.Null(maybe.Exception);
        }

        [Fact]
        public void CreateSuccessfulMaybe()
        {
            var maybe = Maybe.Success();

            Assert.True(maybe.HasValue);
            Assert.True(maybe.Value);

            Assert.False(maybe.HasMessage);
            Assert.Null(maybe.Message);

            Assert.False(maybe.IsExceptionState);
            Assert.Null(maybe.Exception);
        }

        [Fact]
        public void CreateFailureMaybe()
        {
            var maybe = Maybe.Failure();

            Assert.False(maybe.HasValue);
            Assert.False(maybe.Value);

            Assert.False(maybe.HasMessage);
            Assert.Null(maybe.Message);

            Assert.False(maybe.IsExceptionState);
            Assert.Null(maybe.Exception);
        }

        [Fact]
        public void CreateFailureMaybeWithMessage()
        {
            var maybe = Maybe.Failure("Test");

            Assert.False(maybe.HasValue);
            Assert.False(maybe.Value);

            Assert.True(maybe.HasMessage);
            Assert.True(!string.IsNullOrWhiteSpace(maybe.Message) && maybe.Message == "Test");

            Assert.False(maybe.IsExceptionState);
            Assert.Null(maybe.Exception);
        }

        [Fact]
        public void CreateFailureMaybeWithException()
        {
            var maybe = Maybe.Failure(new Exception());

            Assert.False(maybe.HasValue);
            Assert.False(maybe.Value);

            Assert.False(maybe.HasMessage);
            Assert.Null(maybe.Message);

            Assert.True(maybe.IsExceptionState);
            Assert.NotNull(maybe.Exception);
        }

        #endregion Method Tests

        #region Extension Method Tests

        [Fact]
        public void AccessPropertiesOfNullMaybe()
        {
            Maybe maybe = null;

            try
            {
                var value = maybe.Value;
                var message = maybe.Message;
                var exception = maybe.Exception;
            }
            catch
            {
                Assert.True(false);
            }
        }

        #endregion Extension Method Tests
    }
}
