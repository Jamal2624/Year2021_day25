using OceanTrenchModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanTrenchInterfaces.Services
{
    public interface ISeaTrenchReaderService
    {
        /// <summary>
        /// Method reads initial sea floor situation
        /// </summary>
        /// <returns>Initial sea floor</returns>
        SeaFloor ReadSituation();
    }
}
