using OceanTrenchModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanTrenchInterfaces.Services
{
    /// <summary>
    /// Interface of Service of main functionalities 
    /// </summary>
    public interface ISeaTrenchProcessorService
    {
        /// <summary>
        /// Collection of steps with sea floor situation
        /// </summary>
        IList<SeaFloorStep> SeaFloorSteps { get; }

        /// <summary>
        /// Method initializes Sea floor
        /// </summary>
        /// <returns></returns>
        SeaFloorStep Init();

        /// <summary>
        /// Method processes next step
        /// </summary>
        /// <param name="seaFloorStep">Current sea floor step</param>
        /// <returns>Next sea floor step</returns>
        SeaFloorStep MoveToNextStep(SeaFloorStep seaFloorStep);

        /// <summary>
        /// Method processes sub step of easten faced cucumbers
        /// </summary>
        /// <param name="seaFloor">current sea floor situation</param>
        /// <returns>Sea floor situation after movement of easten faced cucumbers</returns>
        SeaFloor MoveEastFaced(SeaFloor seaFloor);

        /// <summary>
        /// Method processes sub step of south faced cucumbers
        /// </summary>
        /// <param name="seaFloor">current sea floor situation</param>
        /// <returns>Sea floor situation after movement of south faced cucumbers</returns>
        SeaFloor MoveSouthFaced(SeaFloor seaFloor);

        /// <summary>
        /// Method runs main functionality
        /// </summary>
        void ProcessProgram();
    }
}
