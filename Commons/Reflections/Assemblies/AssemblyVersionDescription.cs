using Commons.Helpers.CommonObjects;

namespace Commons.Reflections.Assemblies
{
    public class AssemblyVersionDescription
    {
        private const string UNDEFINED = "UNDEFINED";

        public string Version { get; set; }
        public string Build { get; set; }
        public string Revision { get; set; }


        public override string ToString()
        {
            return "{0}-{1}-{2}"
                .FillWith(
                    Version ?? UNDEFINED, 
                    Revision ?? UNDEFINED,
                    Build ?? UNDEFINED
                );
        }
    }
}