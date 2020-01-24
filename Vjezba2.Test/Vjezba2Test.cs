using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace Vjezba2.Test
{
    [TestFixture]
    public class Vjezba2Test
    {
        public Driver Denis;
        public Driver Mario;
        //private Driver Paradigme;
        [SetUp]
        public void Setup()
        {
            Denis = new Driver(null) { Money = 10 };
            Mario = new Driver(null) { Money = 100 };
        }


        //testing method name convection Method_Scenario_ExpectedBehavior()

        [Test]
        [TestCase(10, 0)]
        [TestCase(11, 10)]
        public void TestMethod1(int withdrawAmount, int result)
        {
            Denis.Withdraw(withdrawAmount);
            Assert.That(Denis.Money, Is.EqualTo(result));
        }

        [Test]
        public void CrashMove_MakeCrashMove_ToCertainDriverTookVehicleAndCrash()
        {
            // Arrange
            var denisCrashVehicle = Denis.MakeCrashMove("Truck");
            var marioCrashVehicle = Mario.MakeCrashMove("Car");

            // Act
            var result = denisCrashVehicle.Victory(marioCrashVehicle);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }


    }
}
