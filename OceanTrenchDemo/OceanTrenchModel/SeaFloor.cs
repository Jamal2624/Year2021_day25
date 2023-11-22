using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanTrenchModel
{
    /// <summary>
    /// Sea floor class
    /// </summary>
    public class SeaFloor
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SeaFloor()
        {

        }

        /// <summary>
        /// overload of constructor with parameters
        /// </summary>
        /// <param name="xLength">Sea floor length in X direction</param>
        /// <param name="yLength">Sea floor length in Y direction</param>
        public SeaFloor(int xLength, int yLength)
        {

            SeaLocations = new SeaLocation[xLength][];
            for (int i = 0; i < xLength; i++)
            {
                var rowSeaLocation = new SeaLocation[yLength];
                for (int j = 0; j < yLength; j++) {
                    rowSeaLocation[j] = new SeaLocation(i,j);
                }
                SeaLocations[i] = rowSeaLocation;
            }
            YLength= yLength;
        }

        /// <summary>
        /// 2D array of sea floor locations
        /// </summary>
        public SeaLocation[][] SeaLocations { get; set; } = new SeaLocation[0][];

        /// <summary>
        /// Sea floor length in X direction
        /// </summary>
        public int XLength
        {
            get { return SeaLocations.GetLength(0); }
        }

        /// <summary>
        /// Sea floor length in Y direction
        /// </summary>
        public int YLength { get; set; }
    }
}
