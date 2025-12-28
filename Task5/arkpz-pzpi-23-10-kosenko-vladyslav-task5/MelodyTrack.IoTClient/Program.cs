using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MelodyTrack.IoTClient
{
    class Program
    {
       
        private const string ApiUrl = "https://localhost:7037/api/Grades";

       
        private const int CurrentStudentId = 4; 
        private const int CurrentTeacherId = 3; 
        private const int CurrentSubjectId = 1; 
        private const double ComplexityK = 1.1; 

        static async Task Main(string[] args)
        {
            using var client = new HttpClient();
            Console.WriteLine("==========================================");
            Console.WriteLine("   MelodyTrack IoT: Система активована    ");
            Console.WriteLine("==========================================");

            
            int practiceMinutes = 35;
            Console.WriteLine($"[Датчик]: Зафіксовано час гри: {practiceMinutes} хв.");

           
            double rawScore = (practiceMinutes * ComplexityK) / 4;
            int finalGrade = (int)Math.Clamp(Math.Round(rawScore), 1, 12);

            Console.WriteLine($"[Логіка]: Розрахований бал: {finalGrade}");

            
            var gradeData = new
            {
                value = finalGrade,
                comment = $"IoT: Автоматичний запис ({practiceMinutes} хв, K={ComplexityK})",
                date = DateTime.Now,
                subjectID = CurrentSubjectId,
                studentID = CurrentStudentId,
                teacherID = CurrentTeacherId
            };

        
            try
            {
                Console.WriteLine("[Мережа]: Синхронізація з сервером MelodyTrack...");
                var response = await client.PostAsJsonAsync(ApiUrl, gradeData);

                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(">>> УСПІХ: Оцінка успішно додана в базу даних!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($">>> ПОМИЛКА СЕРВЕРА: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($">>> ПОМИЛКА ЗВ'ЯЗКУ: {ex.Message}");
            }

            Console.ResetColor();
            Console.WriteLine("==========================================");
            Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}