namespace OceanTrenchModel
{
    public class Cucumber
    {
        /// <summary>
        /// Cucumber id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Cucumber type
        /// </summary>
        public CucumberType CucumberType { get; set; } = CucumberType.Unknown;
    }
}
