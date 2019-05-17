using System.IO;

namespace Planowanie_Zlecen_LED
{
    public class KartyTechnologiczne
    {
        public static bool CheckIfAvailible(string modelId)
        {
            string folderPath = @"Y:\Manufacturing_Center\Integral Quality Management\Karty technologiczne\Karty technologiczne LED";
            string filePath = Path.Combine(folderPath, $"{modelId}46.xlsx");

            return File.Exists(filePath);
        }
    }
}