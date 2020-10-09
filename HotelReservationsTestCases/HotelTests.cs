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
            Assert.AreEqual(hotel.MakeReservation(-4, 2), false);

        }
        /// <summary>
        /// Requests outside our planing period are declined(Size=1)
        /// </summary>
        [TestMethod]
        public void TestMethod1B()
        {
            var hotel = new Hotel(1);
            Assert.AreEqual(hotel.MakeReservation(200, 400), false);

        }
        /// <summary>
        /// Requests are accepted (Size=3)
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            var hotel = new Hotel(3);

            Assert.AreEqual(hotel.MakeReservation(0, 5), true);
            Assert.AreEqual(hotel.MakeReservation(7, 13), true);
            Assert.AreEqual(hotel.MakeReservation(3, 9), true);
            Assert.AreEqual(hotel.MakeReservation(5, 7), true);
            Assert.AreEqual(hotel.MakeReservation(6, 6), true);
            Assert.AreEqual(hotel.MakeReservation(0, 4), true);

        }
        /// <summary>
        /// Requests are declined (Size=3)
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            var hotel = new Hotel(3);

            Assert.AreEqual(hotel.MakeReservation(1, 3), true);
            Assert.AreEqual(hotel.MakeReservation(2, 5), true);
            Assert.AreEqual(hotel.MakeReservation(1, 9), true);
            Assert.AreEqual(hotel.MakeReservation(0, 15), false);

            ;
        }
        /// <summary>
        /// Requests can be accepted after a decline (Size=3)
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            var hotel=new Hotel(3);

            
            Assert.AreEqual(hotel.MakeReservation(1, 3), true);
            Assert.AreEqual(hotel.MakeReservation(0, 15), true);
            Assert.AreEqual(hotel.MakeReservation(1, 9), true);
            Assert.AreEqual(hotel.MakeReservation(2, 5), false);
            Assert.AreEqual(hotel.MakeReservation(4, 9), true);


        }
        /// <summary>
        /// Complex Requests (Size=2)
        /// </summary>
        [TestMethod]
        public void TestMethod5()
        {
            var hotel = new Hotel(2);
           
            Assert.AreEqual(hotel.MakeReservation(1, 3), true);
            Assert.AreEqual(hotel.MakeReservation(0, 4), true);
            Assert.AreEqual(hotel.MakeReservation(2, 3), false);
            Assert.AreEqual(hotel.MakeReservation(5, 5), true);
            Assert.AreEqual(hotel.MakeReservation(4, 10), true);
            Assert.AreEqual(hotel.MakeReservation(10, 10), true);
            Assert.AreEqual(hotel.MakeReservation(6, 7), true);
            Assert.AreEqual(hotel.MakeReservation(8, 10), false);
            Assert.AreEqual(hotel.MakeReservation(8, 9), true);



        }
    }
}
