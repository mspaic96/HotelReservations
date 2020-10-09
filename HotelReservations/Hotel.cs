using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservations
{
    public class Hotel
    {
        // we assume that  year has 365 days, no leap year
        private const int Days = 365;
        // 2D array where rows are rooms in hotel and columns are days in year
        // if _array[i,j]=0 then Room i on day j is free ,else if  _array[i,j]= 1 is already booked already
        private int[,] _array;

        public Hotel(int size)
        {
            if(size > 1000 ) throw new ArgumentException("The size of hotel should be smaller than 1000!");
            _array = new int[size,Days];
        }
        
        public  bool MakeReservation(int startDay, int endDay)
        {
            if (startDay < 0 || endDay >= 365) return false;

            var indexOfLatestBookedDateInRoom = -2;
            var indexOfFreeRoom = -1;
            var checkAvailability = false;

            for (var i = 0; i < _array.GetLength(0); i++)
            {
                
                for (var j = startDay; j <= endDay; j++)
                {
                    // if any day of given period of days is booked go to the next room
                    if (_array[i, j] == 1) break;
                    // room can be booked for given period,we set flag
                    if (j == endDay)
                    {
                        checkAvailability = true;
                        var pom = FindLatestBookedDateInRoom(i, startDay);
                        if (pom > indexOfLatestBookedDateInRoom)
                        {
                            indexOfLatestBookedDateInRoom = pom;
                            indexOfFreeRoom = i;
                        }

                    }
                }

            }
            if (checkAvailability) ConfirmReservation(indexOfFreeRoom,startDay,endDay);
            return checkAvailability;
        }
        /// <summary>
        /// We set cells in 2D array to 1 for a period of days to confirm reservation
        /// </summary>
        /// <param name="room"></param>
        /// <param name="startDay"></param>
        /// <param name="endDay"></param>
        public void ConfirmReservation(int room, int startDay, int endDay)
        {
            for (var i = startDay; i <= endDay; i++)
            {
                _array[room, i] = 1;
            }
        }
        /// <summary>
        /// Function that help us to maximize the utilization of our rooms for complex requests
        /// </summary>
        /// <param name="room"></param>
        /// <param name="startDay"></param>
        /// <returns></returns>
        public int FindLatestBookedDateInRoom(int room,int startDay)
        {
            for (var k = startDay-1; k >= 0; k--)
            {
                if (_array[room, k] == 1) return k;
            }

            return -1;
        }
    }
}
