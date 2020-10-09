using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservations;


namespace HotelReservationsTestCases
{
    [TestClass]
    public class HotelTests
    {
        /// <summary>
        /// Requests outside our planing period are declined(Size=1)
        /// </summary>
        [TestMethod]
        public void TestMethod1A()
        {
            var hotel = new Hotel(1);

            var bookingStatus=hotel.MakeReservation(-4, 2);

            Assert.AreEqual(bookingStatus, false);

        }
        /// <summary>
        /// Requests outside our planing period are declined(Size=1)
        /// </summary>
        [TestMethod]
        public void TestMethod1B()
        {
            var hotel = new Hotel(1);

            var bookingStatus = hotel.MakeReservation(200, 400);

            Assert.AreEqual(bookingStatus, false);

        }
        /// <summary>
        /// Requests are accepted (Size=3)
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            var hotel = new Hotel(3);

            var bookingStatus = hotel.MakeReservation(0, 5);
            Assert.AreEqual(bookingStatus,true);
            bookingStatus = hotel.MakeReservation(7, 13);
            Assert.AreEqual(bookingStatus,true);
            bookingStatus = hotel.MakeReservation(3, 9);
            Assert.AreEqual(bookingStatus,true);
            bookingStatus = hotel.MakeReservation(5, 7);
            Assert.AreEqual(bookingStatus,true);
            bookingStatus = hotel.MakeReservation(6, 6);
            Assert.AreEqual(bookingStatus,true);
            bookingStatus = hotel.MakeReservation(0, 4);
            Assert.AreEqual(true,true);

        }
        /// <summary>
        /// Requests are declined (Size=3)
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            var hotel = new Hotel(3);
            var bookingStatus = hotel.MakeReservation(1, 3);
            Assert.AreEqual(bookingStatus, true);
            bookingStatus = hotel.MakeReservation(2, 5);
            Assert.AreEqual(bookingStatus, true);
            bookingStatus = hotel.MakeReservation(1, 9);
            Assert.AreEqual(bookingStatus, true);
            bookingStatus = hotel.MakeReservation(0, 15);
            Assert.AreEqual(bookingStatus, false);

            ;
        }
        /// <summary>
        /// Requests can be accepted after a decline (Size=3)
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            var hotel=new Hotel(3);
            var bookingStatus = hotel.MakeReservation(1, 3);
            Assert.AreEqual(bookingStatus,true);
            bookingStatus = hotel.MakeReservation(0, 15);
            Assert.AreEqual(bookingStatus, true);
            bookingStatus = hotel.MakeReservation(1,9);
            Assert.AreEqual(bookingStatus, true);
            bookingStatus = hotel.MakeReservation(2,5);
            Assert.AreEqual(bookingStatus, false);
            bookingStatus = hotel.MakeReservation(4, 9);
            Assert.AreEqual(bookingStatus,true);


        }
        /// <summary>
        /// Complex Requests (Size=2)
        /// </summary>
        [TestMethod]
        public void TestMethod5()
        {
            var hotel = new Hotel(2);
            var bookingStatus = hotel.MakeReservation(1, 3);
            Assert.AreEqual(bookingStatus,true);
            bookingStatus = hotel.MakeReservation(0, 4);
            Assert.AreEqual(bookingStatus, true);
            bookingStatus = hotel.MakeReservation(2, 3);
            Assert.AreEqual(bookingStatus, false);
            bookingStatus = hotel.MakeReservation(5, 5);
            Assert.AreEqual(bookingStatus,true);
            bookingStatus = hotel.MakeReservation(4, 10);
            Assert.AreEqual(bookingStatus,true);
            bookingStatus = hotel.MakeReservation(10, 10);
            Assert.AreEqual(bookingStatus, true);
            bookingStatus = hotel.MakeReservation(6, 7);
            Assert.AreEqual(bookingStatus, true);
            bookingStatus = hotel.MakeReservation(8, 10);
            Assert.AreEqual(bookingStatus,false);
            bookingStatus = hotel.MakeReservation(8, 9);
            Assert.AreEqual(bookingStatus,true);



        }
    }
}
