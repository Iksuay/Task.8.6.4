using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:/Users/tamer/Рабочий стол/Students.dat";
            string directoryPath = @"C:/Users/tamer/Рабочий стол/Students";
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Фаил {filePath} не найден");
                return;
            }
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Student[] students = (Student[])formatter.Deserialize(fs);

                foreach (Student student in students)
                {
                    string groupFilePath = Path.Combine(directoryPath, student.Group + ".txt");

                    using (StreamWriter sw = new StreamWriter(groupFilePath, true))
                    {
                        sw.WriteLine($"{student.Name}, {student.DateOfBirth.ToShortDateString()}");
                    }
                }
            }

            Console.WriteLine("Информация о студентах была составлена");
        }
    }
}