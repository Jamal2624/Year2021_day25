using Microsoft.Extensions.DependencyInjection;
using OceanTrenchImplementations.Services;
using OceanTrenchInterfaces.Services;

namespace OceanTrenchApp
{
    public class OceanTrenchApp
    {
        public static int Main()
        {
            try
            {
                //Registering injectable classes
                ServiceProvider serviceProvider = new ServiceCollection()
                        .AddScoped<ISeaTrenchReaderService, SeaTrenchReaderService>()
                        .AddScoped<ISeaTrenchWriterService, SeaTrenchWriterService>()
                        .AddScoped<ISeaTrenchProcessorService, SeaTrenchProcessorService>()
                        .BuildServiceProvider();


                Console.WriteLine("Starting application");
                ISeaTrenchProcessorService? processingService = serviceProvider.GetService<ISeaTrenchProcessorService>();
                processingService.ProcessProgram();

                Console.WriteLine("All done!");
            }
            catch (IOException e)
            {
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(e.Message);
                return 1;
            }
            catch (NullReferenceException ex)
            {
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(ex.Message);
                return 1;
            }

            Console.WriteLine("Press any key to continue...");
            _ = Console.ReadKey();
            return 0;
        }
    }
}