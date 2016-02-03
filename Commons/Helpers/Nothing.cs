namespace Commons.Helpers
{
    public sealed class Nothing
    {
        public static readonly Nothing Value = new Nothing();

        private Nothing()
        {
        }
    }
}