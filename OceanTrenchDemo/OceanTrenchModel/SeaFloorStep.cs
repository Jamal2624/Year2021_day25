using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanTrenchModel
{
    /// <summary>
    /// class of sea floor at certain step
    /// </summary>
    public class SeaFloorStep
    {
        /// <summary>
        /// Step number
        /// </summary>
        public int Stepnumber { get; set; }

        /// <summary>
        /// Sea floor at the step
        /// </summary>
        public SeaFloor SeaFloor { get; set; } = new SeaFloor();
    }
}
