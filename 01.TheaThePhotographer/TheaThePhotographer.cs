namespace _01.TheaThePhotographer
{
    using System;
    using System.Numerics;

    public static class TheaThePhotographer
    {
        public static void Main()
        {
            var numberofPictures = int.Parse(Console.ReadLine());
            var filterTime = int.Parse(Console.ReadLine());
            var filterFactor = double.Parse(Console.ReadLine());
            var uploadTime = long.Parse(Console.ReadLine());

            var usefulPictures = (BigInteger)(Math.Ceiling((numberofPictures * filterFactor) / 100));

            var totalTimeTaken = (BigInteger)numberofPictures * filterTime;
            totalTimeTaken += usefulPictures * uploadTime;
            
            var days = totalTimeTaken / (24 * 60 * 60);
            totalTimeTaken -= days * (24 * 60 * 60);

            var hours = totalTimeTaken / (60 * 60);
            totalTimeTaken -= hours * (60 * 60);

            var minutes = totalTimeTaken / 60;
            var seconds = totalTimeTaken - (minutes * 60);

            Console.WriteLine($"{days}:{hours:00}:{minutes:00}:{seconds:00}");
        }
    }
}
