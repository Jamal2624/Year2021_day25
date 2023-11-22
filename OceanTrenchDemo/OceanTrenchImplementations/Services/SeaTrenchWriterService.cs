using OceanTrenchImplementations.Extentions;
using OceanTrenchInterfaces.Services;
using OceanTrenchModel;
using System.Text;

namespace OceanTrenchImplementations.Services
{
    public class SeaTrenchWriterService : ISeaTrenchWriterService
    {
        public void WriteLastStep(SeaFloorStep currentStep)
        {
            Console.WriteLine($"\r\n Last step: {currentStep.Stepnumber} ");
        }

        public void WriteStep(SeaFloorStep seaFloorStep, bool initial = false)
        {
            if (initial) {
                Console.WriteLine($"\r\n Initial state: ");
            } else
                Console.WriteLine($"\r\n After {seaFloorStep.Stepnumber} step: ");

            var reportBuilder = SeaFloorReport(seaFloorStep.SeaFloor);
            Console.WriteLine(reportBuilder.ToString());
        }

        public StringBuilder SeaFloorReport(SeaFloor seaFloor)
        {
            var reportKeeper = new StringBuilder();

            for (int i = 0; i < seaFloor.XLength; i++)
            {
                string line = seaFloor.SeaLocations[i].ToSeaFloorMap();
                reportKeeper.AppendLine(line);
            }
            return reportKeeper;
        }


    }
}
