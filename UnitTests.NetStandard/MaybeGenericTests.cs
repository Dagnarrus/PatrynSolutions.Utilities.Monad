namespace UnitTests.NetStandard
{
    using System;

    using Xunit;

    using PatrynSolutions.Utilities.Monad;
    
    public class MaybeGenericTests
    {

        #region Value/HasValue

        [Fact]
        public void VariousValuesWrapped()
        {
            var val = "TestValue";
            var maybe = new Maybe<string>(val);

            Assert.True(maybe.HasValue);
            Assert.Equal(val, maybe.Value);

            var str = "TestValueTwo";
            var strMaybe = new Maybe<string>(str, false);

            Assert.True(strMaybe.HasValue);
            Assert.Equal(str, strMaybe.Value);

            var num = 42;
            var numMaybe = new Maybe<int>(num);

            Assert.True(numMaybe.HasValue);
            Assert.Equal(num, numMaybe.Value);

            var byt = 0x24;
            var bytMaybe = new Maybe<byte>(byt);

            Assert.True(bytMaybe.HasValue);
            Assert.Equal(byt, bytMaybe.Value);

            var shrt = 42;
        }

        [Fact]
        public void NullAndDefaultValueWrapped()
        {
            
        }

        #endregion Value/HasValue

        #region Message/HasMessage



        #endregion Message/HasMessage

        #region FriendlyMessage/HasFriendlyMessage



        #endregion FriendlyMessage/HasFriendlyMessage

        #region ErrorCode/HasErrorCode



        #endregion ErrorCode/HasErrorCode

        #region Exception/HasException/Exceptions



        #endregion Exception/HasException/Exceptions

        #region Static Methods



        #endregion Static Methods

        #region Extension Methods



        #endregion Extension Methods

        #region Implicit Operators



        #endregion Implicit Operators
    }
}
