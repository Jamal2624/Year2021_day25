using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanTrenchModel
{
    /// <summary>
    /// Class location
    /// </summary>
    public class SeaLocation
    {
        public SeaLocation(int xLength, int yLength)
        {
            XCoord = xLength; 
            YCoord = yLength;
        }

        /// <summary>
        /// X coordinate
        /// </summary>
        public int XCoord { get; set; }

        /// <summary>
        /// Y coordinate
        /// </summary>
        public int YCoord { get; set; }

        /// <summary>
        /// reference to cucumber at the location
        /// if the reference is null then location is free
        /// </summary>
        public Cucumber? Cucumber { get; set; }

    }
}
