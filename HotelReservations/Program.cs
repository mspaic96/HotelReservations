using System;


namespace HotelReservations
{
   class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of rooms in hotel (size of your hotel)!");

            var size = Convert.ToInt32(Console.ReadLine());

            Hotel hotel;
            try
            {
                 hotel = new Hotel(size);
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
                return;
            }

            Console.WriteLine("Enter the startDay! If you want to exit press Enter!");

            var start = Console.ReadLine();

            while (start != "")
            {
                var startDay = Convert.ToInt32(start);

                Console.WriteLine("Enter the endDay!");

                var endDay = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(hotel.MakeReservation(startDay, endDay)
                    ? "Reservation accepted!"
                    : "Reservation declined!");

                Console.WriteLine("Enter the startDay! If you want to exit press Enter!");

                start = Console.ReadLine();
            }
        }

       
    }
}
