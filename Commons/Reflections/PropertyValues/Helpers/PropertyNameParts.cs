namespace Commons.Reflections.PropertyValues.Helpers
{
    public struct PropertyNameParts
    {
        public string BasePart { get; set; }
        public string OtherPart { get; set; }


        public PropertyNameParts(string basePart, string otherPart) : this()
        {
            BasePart = basePart;
            OtherPart = otherPart;
        }
    }
}