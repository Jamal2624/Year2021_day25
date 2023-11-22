using OceanTrenchModel;

namespace OceanTrenchImplementations.Extentions
{
    public static class GeneralExtentions
    {
        /// <summary>
        /// Method convertes cucumber type into string for reporting purposes
        /// </summary>
        /// <param name="seaLocation">cucumber type</param>
        /// <returns>string</returns>
        public static string ToSeaFloorMap(this SeaLocation[]  seaLocation)
        {
            var result = "";
            result = new string(seaLocation.Select(sl => sl.Cucumber == null ? '.' :
                sl.Cucumber.CucumberType == CucumberType.Eastfacing ? '>' : 
                sl.Cucumber.CucumberType == CucumberType.Southfacing ? 'v' : '?')
                .ToArray());
            return result;
        }
    }
}
