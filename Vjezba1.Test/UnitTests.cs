using System;
using NUnit.Framework;

namespace Vjezba1.Test
{
    [TestFixture]
    public class crashMoveTest
    {
        private static object[] source =
        {
            new object[]
            {
                new Truck(),
                new Car(),
                new Motorcycle(),
                1
            },
        };

        //testing method name convection Method_Scenario_ExpectedBehavior()
        [Test]
        [TestCaseSource("source")]
        public void CrashMove_Victory_VictoryOneOfCrashMove(CrashMove crashMove_1, CrashMove crashMove_2, CrashMove crashMove_3, int result)
        {
            Assert.That(crashMove_1.Victory(crashMove_2), Is.EqualTo(result));
            Assert.That(crashMove_2.Victory(crashMove_3), Is.EqualTo(result));

            //Arrange

            //Act

            //Assert
        }

        [Test]
        public void CrashMove_VictoryTruck_VictoryTruckVSCar()
        {
            // Arrange
            var truck = new Truck();
            var car = new Car();

            // Act
            var result = (truck.Victory(car) > 0) || (car.Victory(truck) < 0);

            // Assert
            Assert.IsTrue(result);

        }

        [Test]
        public void CrashMove_VictoryCar_VictoryCarVSMotorcycle()
        {
            // Arrange
            var motorcycle = new Motorcycle();
            var car = new Car();

            // Act
            var result = motorcycle.Victory(car) > 0;
            var result_2 = car.Victory(motorcycle) > 0;

            // Assert
            Assert.IsTrue(result_2);
            Assert.IsFalse(result);
        }

        [Test]
        public void CrashMove_VictoryMotorcycle_VictoryMotorcycleVSTruck()
        {
            // Arrange
            var motorcycle = new Motorcycle();
            var truck = new Truck();

            // Act
            var result = truck.Victory(motorcycle) < 0;
            var result_2 = motorcycle.Victory(truck) < 0;

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(result_2);
        }

        [Test]
        public void CrashMove_Equal_TruckEqualTruck()
        {
            // Arrange
            var truck_1 = new Truck();
            var truck_2 = new Truck();

            // Act
            var result = truck_1.Victory(truck_2) == 0;
            var result_2 = truck_2.Victory(truck_1) == 0;

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(result_2);
        }

        [Test]
        public void CrashMove_Nothing_NoResult() 
        {
            // Arrange
            CrashMove crashMove = null;
            var truck = new Truck();

            // Act
            //var result = truck.Victory(crashMove) != -2 ;
            var result_2 = truck.Victory(crashMove) == -2;

            // Assert
            Warn.Unless(result_2);
            //Warn.Unless(result);

        }

        // testiranje driver klase 

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
