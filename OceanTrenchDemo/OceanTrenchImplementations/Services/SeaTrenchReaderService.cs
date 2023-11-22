using OceanTrenchInterfaces.Services;
using OceanTrenchModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OceanTrenchImplementations.Services
{
    public class SeaTrenchReaderService : ISeaTrenchReaderService
    {
        public SeaFloor ReadSituation()
        {
            var seaFloor = new SeaFloor();
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!string.IsNullOrEmpty(path))
            {
                var filepath = Path.Combine(path, @"InitialSeaFloor.txt");
                var fileInfo = new FileInfo(filepath);
                if (fileInfo.Exists)
                {
                    int cucumberCounter = 1;
                    string text = File.ReadAllText(filepath);
                    string[] lines = text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    seaFloor.SeaLocations = new SeaLocation[lines.Length][];

                    for (int i = 0; i < lines.Length; i++)
                    {
                        var line = lines[i];

                        line = line.Replace("\r", "").Replace(" ", "");
                        var chars = line.ToCharArray();

                        var rowSeaLocations = new SeaLocation[chars.Length];
                        for (int j = 0; j < chars.Length; j++)
                        {
                            var locChar = chars[j];

                            rowSeaLocations[j] = new SeaLocation(i, j)
                            {
                                Cucumber = locChar == '>' ? new Cucumber()
                                {
                                    Id = cucumberCounter++,
                                    CucumberType = CucumberType.Eastfacing
                                } :
                                    locChar == 'v' ? new Cucumber()
                                    {
                                        Id = cucumberCounter++,
                                        CucumberType = CucumberType.Southfacing
                                    } : null
                            };
                        }
                        seaFloor.SeaLocations[i] = rowSeaLocations;
                        if (i == 0)
                        {
                            seaFloor.YLength = rowSeaLocations.Length;
                        }
                        else if (seaFloor.YLength != rowSeaLocations.Length)
                        {
                            throw new IndexOutOfRangeException("Initial definition of Sea floor is incorrect!");
                        }
                    }

                }
            }
            return seaFloor;
        }
    }
}

