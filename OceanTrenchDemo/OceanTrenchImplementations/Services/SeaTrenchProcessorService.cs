using OceanTrenchInterfaces.Services;
using OceanTrenchModel;
using System.Drawing;

namespace OceanTrenchImplementations.Services
{
    public class SeaTrenchProcessorService : ISeaTrenchProcessorService
    {
        private readonly IList<SeaFloorStep> _seaFloorSteps = new List<SeaFloorStep>();
        private readonly ISeaTrenchReaderService _seaTrenchReader;
        private readonly ISeaTrenchWriterService _seaTrenchWriter;
        public SeaTrenchProcessorService(ISeaTrenchReaderService seaTrenchReader,
           ISeaTrenchWriterService seaTrenchWriter)
        {
            _seaTrenchReader = seaTrenchReader;
            _seaTrenchWriter = seaTrenchWriter;
        }
        public void ProcessProgram()
        {
            bool seaFloorChanged = false;
            SeaFloorStep? nextStep = null;
            SeaFloorStep currentStep = Init();
            _seaTrenchWriter.WriteStep(currentStep, true);
            do
            {
                nextStep = MoveToNextStep(currentStep);
                seaFloorChanged = SeaFloorChanged(currentStep.SeaFloor, nextStep.SeaFloor);
                if (seaFloorChanged)
                {
                    _seaFloorSteps.Add(nextStep);
                    currentStep = nextStep;
                }
                _seaTrenchWriter.WriteStep(nextStep);
            } while (seaFloorChanged);

            _seaTrenchWriter.WriteLastStep(nextStep);
        }

        /// <summary>
        /// method compares steps
        /// </summary>
        /// <param name="currentSeaFloor">Current sea floor</param>
        /// <param name="nextSeaFloor">Next sea floor</param>
        /// <returns> false sea floor is not changed</returns>
        private bool SeaFloorChanged(SeaFloor currentSeaFloor, SeaFloor nextSeaFloor)
        {
            for (var i = 0; i < currentSeaFloor.XLength; i++)
            {
                for (var j = 0; j < currentSeaFloor.YLength; j++)
                {
                    if (currentSeaFloor.SeaLocations[i][j].Cucumber != nextSeaFloor.SeaLocations[i][j].Cucumber)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// list of sea floor steps
        /// </summary>
        public IList<SeaFloorStep> SeaFloorSteps => _seaFloorSteps;

        /// <summary>
        /// Method initialises sea floor
        /// </summary>
        /// <returns></returns>
        public SeaFloorStep Init()
        {
            var firstStep = new SeaFloorStep()
            {
                Stepnumber = _seaFloorSteps.Count,
                SeaFloor = _seaTrenchReader.ReadSituation()
            };

            _seaFloorSteps.Add(firstStep);
            return firstStep;
        }

        /// <summary>
        /// method of movement eastern faced cucumbers
        /// </summary>
        /// <param name="seaFloor">Sea floor before movement</param>
        /// <returns>Sea floor after movement</returns>
        public SeaFloor MoveEastFaced(SeaFloor seaFloor)
        {
            var resultFloor = new SeaFloor(seaFloor.XLength, seaFloor.YLength);

            var busyLocations = seaFloor.SeaLocations
                .SelectMany(x => x.Where(d => d.Cucumber != null).Select(y => y)).ToList();

            busyLocations.ForEach(
                lc =>
                {
                    if (lc.Cucumber.CucumberType == CucumberType.Eastfacing)
                    {
                        var candidateLocation = (XCoord: lc.XCoord, YCoord: (lc.YCoord + 1 < seaFloor.YLength ? lc.YCoord + 1 : 0));
                        if (seaFloor.SeaLocations[candidateLocation.XCoord][candidateLocation.YCoord].Cucumber == null)
                        {
                            resultFloor.SeaLocations[candidateLocation.XCoord][candidateLocation.YCoord].Cucumber = lc.Cucumber;
                        }
                        else
                        {
                            resultFloor.SeaLocations[lc.XCoord][lc.YCoord].Cucumber = lc.Cucumber;
                        }
                    }
                    else
                    {
                        resultFloor.SeaLocations[lc.XCoord][lc.YCoord].Cucumber = lc.Cucumber;
                    }
                }
                );
            return resultFloor;
        }

        /// <summary>
        /// method of movement south faced cucumbers
        /// </summary>
        /// <param name="seaFloor">Sea floor before movement</param>
        /// <returns>Sea floor after movement</returns>
        public SeaFloor MoveSouthFaced(SeaFloor seaFloor)
        {
            var resultFloor = new SeaFloor(seaFloor.XLength, seaFloor.YLength);

            var busyLocations = seaFloor.SeaLocations
                .SelectMany(x => x.Where(d => d.Cucumber != null).Select(y => y)).ToList();

            busyLocations.ForEach(
                lc =>
                {
                    if (lc.Cucumber.CucumberType == CucumberType.Southfacing)
                    {
                        var candidateLocation = (XCoord: (lc.XCoord + 1 < seaFloor.XLength ? lc.XCoord + 1 : 0), YCoord: lc.YCoord);
                        if (seaFloor.SeaLocations[candidateLocation.XCoord][candidateLocation.YCoord].Cucumber == null)
                        {
                            resultFloor.SeaLocations[candidateLocation.XCoord][candidateLocation.YCoord].Cucumber = lc.Cucumber;
                        }
                        else
                        {
                            resultFloor.SeaLocations[lc.XCoord][lc.YCoord].Cucumber = lc.Cucumber;
                        }
                    }
                    else
                    {
                        resultFloor.SeaLocations[lc.XCoord][lc.YCoord].Cucumber = lc.Cucumber;
                    }
                }
                );
            return resultFloor;
        }

        /// <summary>
        /// method of movement all cucumbers
        /// </summary>
        /// <param name="seaFloorStep">Sea floor step before movement</param>
        /// <returns>Sea floor step after movement</returns>
        public SeaFloorStep MoveToNextStep(SeaFloorStep seaFloorStep)
        {
            SeaFloor afterEastMovement = MoveEastFaced(seaFloorStep.SeaFloor);
            SeaFloor afterSouthMovement = MoveSouthFaced(afterEastMovement);
            return new SeaFloorStep()
            {
                SeaFloor = afterSouthMovement,
                Stepnumber = seaFloorStep.Stepnumber + 1,
            };
        }
    }
}
