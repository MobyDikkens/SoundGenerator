using System;
using Sound;

namespace MainThread
{
    class Program
    {

        private const string absolute = @"C:\Users\MobyDi\Documents\Visual Studio Code\Sounds\";


        static void Main(string[] args)
        {

            try
            {
                double frequence = 0, amplitude = 0;

                int durability = 0;

                string filename = String.Empty;

                Console.WriteLine("Enter the durability");
                durability = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the frequence");
                frequence = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter the amplitude");
                amplitude = Convert.ToDouble(Console.ReadLine());
                

                Console.WriteLine("Enter the filename:");
                filename = Convert.ToString(Console.ReadLine());


                SoundGenerator generator = new SoundGenerator(durability,frequence,amplitude);


                generator.Save(absolute + filename + ".wav");
            }
            catch
            {
                Console.WriteLine("Error has occured");
            }


        }
    }
}
