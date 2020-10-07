using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservations
{
    class Hotel
    {
        private const int Days = 365;
        private int[,] _array;

        public Hotel(int size)
        {
            if(size > 1000 ) throw new ArgumentException("The size of hotel should be smaller than 1000!");
            _array = new int[size,Days];
        }
        public  bool MakeReservation(int startDay, int endDay)
        {
            if (startDay < 0 || endDay >= 365) return false;
            var checkAvailabity = false;
            for (var i = 0; i < _array.GetLength(0); i++)
            {
                if (checkAvailabity) break;
                for (var j = startDay; j <= endDay; j++)
                {
                    if (_array[i, j] == 1) break;
                    if (j == endDay)
                    {
                        checkAvailabity = true;
                        ConfirmReservation(i, startDay, endDay);
                    }
                }

            }

            return checkAvailabity;
        }

        public  void ConfirmReservation(int room, int startDay, int endDay)
        {
            for (var i = startDay; i <= endDay; i++)
            {
                _array[room, i] = 1;
            }
        }
    }
}
