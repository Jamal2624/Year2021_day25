using Moq;
using Ninject.MockingKernel.Moq;
using OceanTrenchImplementations.Services;
using OceanTrenchInterfaces.Services;
using OceanTrenchModel;
using System.Diagnostics.Metrics;

namespace OceanTrenchTests
{
    public class OceanTrenchUnitTest
    {
        private static SeaFloor _seaFloor1 =  SeaFloorSituation1() ;

        private MoqMockingKernel _kernel;
        private Mock<ISeaTrenchReaderService> _seaTrenchReaderService = new Mock<ISeaTrenchReaderService>();
        private Mock<ISeaTrenchWriterService> _seaTrenchWriterService = new Mock<ISeaTrenchWriterService>();

        private static SeaFloor SeaFloorSituation1()
        {
            int id = 1;
            int yLength = 4;
            SeaFloor result = new SeaFloor()
            {
                YLength = yLength,
                SeaLocations = [
                    [
                        new SeaLocation(0,0){
                            Cucumber= new Cucumber(){ Id = id++,
                                CucumberType=CucumberType.Eastfacing
                            },
                        },
                        new SeaLocation(1,0){
                            Cucumber= new Cucumber(){ Id = id++,
                                CucumberType=CucumberType.Eastfacing
                            },
                        },
                        new SeaLocation(2,0){
                            Cucumber= new Cucumber(){ Id = id++,
                                CucumberType=CucumberType.Eastfacing
                            },
                        },
                        new SeaLocation(3,0){
                            Cucumber= new Cucumber(){ Id = id++,
                                CucumberType=CucumberType.Eastfacing
                            },
                        }
                    ],
                    [
                        new SeaLocation(0, 1)
                        {
                            Cucumber = new Cucumber()
                            {
                                Id = id++,
                                CucumberType = CucumberType.Eastfacing
                            },
                        },
                        new SeaLocation(1, 1)
                        {
                            Cucumber = new Cucumber()
                            {
                                Id = id++,
                                CucumberType = CucumberType.Eastfacing
                            },
                        },
                        new SeaLocation(2, 1)
                        {
                            Cucumber = new Cucumber()
                            {
                                Id = id++,
                                CucumberType = CucumberType.Eastfacing
                            },
                        },
                        new SeaLocation(3, 1)
                        {
                            Cucumber = new Cucumber()
                            {
                                Id = id++,
                                CucumberType = CucumberType.Eastfacing
                            },
                        }
                    ],
                    [
                        new SeaLocation(0, 2)
                        {
                            Cucumber = new Cucumber()
                            {
                                Id = id++,
                                CucumberType = CucumberType.Eastfacing
                            },
                        },
                        new SeaLocation(1, 2)
                        {
                            Cucumber = new Cucumber()
                            {
                                Id = id++,
                                CucumberType = CucumberType.Eastfacing
                            },
                        },
                        new SeaLocation(2, 2)
                        {
                            Cucumber = new Cucumber()
                            {
                                Id = id++,
                                CucumberType = CucumberType.Eastfacing
                            },
                        },
                        new SeaLocation(3, 2)
                        {
                            Cucumber = new Cucumber()
                            {
                                Id = id++,
                                CucumberType = CucumberType.Eastfacing
                            },
                        }
                    ],
                    [
                        new SeaLocation(0, 3)
                        {
                            Cucumber = new Cucumber()
                            {
                                Id = id++,
                                CucumberType = CucumberType.Eastfacing
                            },
                        },
                        new SeaLocation(1, 3)
                        {
                            Cucumber = new Cucumber()
                            {
                                Id = id++,
                                CucumberType = CucumberType.Eastfacing
                            },
                        },
                        new SeaLocation(2, 3)
                        {
                            Cucumber = new Cucumber()
                            {
                                Id = id++,
                                CucumberType = CucumberType.Eastfacing
                            },
                        },
                        new SeaLocation(3, 3)
                        {
                            Cucumber = new Cucumber()
                            {
                                Id = id++,
                                CucumberType = CucumberType.Eastfacing
                            },
                        }
                    ],
                ]
            };
            return result;
        }

        [SetUp]
        public void Setup()
        {
            _kernel = new MoqMockingKernel();
            _kernel.Bind<ISeaTrenchReaderService>().To<SeaTrenchReaderService>();
            _kernel.Bind<ISeaTrenchWriterService>().To<SeaTrenchWriterService>();
        }

        [Test]
        public void check_sea_floor_situation()
        {
           var writer = new SeaTrenchWriterService();

            var text = writer.SeaFloorReport(_seaFloor1).ToString();
            string textResult =
@">>>>
>>>>
>>>>
>>>>
";
           Assert.That(textResult, Is.EqualTo(text));

        }

        //and so on ...
    }
}