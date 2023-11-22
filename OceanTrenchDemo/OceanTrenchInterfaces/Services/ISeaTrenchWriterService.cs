using OceanTrenchModel;
using System.Text;

namespace OceanTrenchInterfaces.Services
{
    public interface ISeaTrenchWriterService
    {
        /// <summary>
        /// Method shows last step number
        /// </summary>
        /// <param name="currentStep"></param>
        void WriteLastStep(SeaFloorStep currentStep);

        /// <summary>
        /// Method reports sea floor
        /// </summary>
        /// <param name="seaFloor">Sea floor to be reported</param>
        /// <param name="initial">true - initial sea floor</param>
        void WriteStep(SeaFloorStep seaFloor, bool initial = false);

        /// <summary>
        /// Method creates sea floor report and returns it as string builder
        /// </summary>
        /// <param name="seaFloor"></param>
        /// <returns></returns>
        StringBuilder SeaFloorReport(SeaFloor seaFloor);
    }
}
