namespace PatrynSolutions.Utilities.Monad.LocalTesting
{
    using PatrynSolutions.Utilities.Monad;

    public class Program
    {
        public static void Main(string[] args)
        {
            var val = "something";
            var maybe = val.ToMaybe<string>();
            //Maybe<string> nulM = null;

            var hasValue = maybe.HasValue;
            var value = maybe.Value;

            //var test = nulM.Value();
        }
    }
}
