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

            byte byt = 0x24;
            var bytMaybe = new Maybe<byte>(byt);

            Assert.True(bytMaybe.HasValue);
            Assert.Equal(byt, bytMaybe.Value);

            short shrt = 42;
            var shrtMaybe = new Maybe<short>(shrt);

            Assert.True(shrtMaybe.HasValue);
            Assert.Equal(shrt, shrtMaybe.Value);

            var lon = 6474728273L;
            var lonMaybe = new Maybe<long>(lon);

            Assert.True(lonMaybe.HasValue);
            Assert.Equal(lon, lonMaybe.Value);

            var obj = new object();
            var objMaybe = new Maybe<object>(obj);

            Assert.True(objMaybe.HasValue);
            Assert.Equal(obj, objMaybe.Value);

            dynamic dyn = new { SomeValue = 56 };
            var dynMaybe = new Maybe<dynamic>(dyn);

            Assert.True(dynMaybe.HasValue);
            Assert.Equal(dyn, dynMaybe.Value);
        }

        [Fact]
        public void NullAndDefaultValueWrapped()
        {
            string val = null;
            var maybe = new Maybe<string>(val);

            Assert.False(maybe.HasValue);
            Assert.Null(maybe.Value);

            int defInt = default(int);
            var intMaybe = new Maybe<int>(defInt);

            Assert.False(intMaybe.HasValue);
            Assert.Equal(defInt, intMaybe.Value);
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
