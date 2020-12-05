
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("VW", "Golf", 10, 100)]
        [TestCase("BMW", "3", 20, 200)]
        public void CarConstructorShouldSetAllDataCorrectly(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Arrange / Act
            Car car = new Car(
                make: make,
                model: model,
                fuelConsumption: fuelConsumption,
                fuelCapacity: fuelCapacity);

            //Assert

            Assert.AreEqual(car.Make, make);
            Assert.AreEqual(car.Model, model);
            Assert.AreEqual(car.FuelConsumption, fuelConsumption);
            Assert.AreEqual(car.FuelCapacity, fuelCapacity);
            Assert.AreEqual(car.FuelAmount, 0);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]

        public void CarConstructorShouldThrowExceptionIfMakeIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "model", 10, 10));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]

        public void CarConstructorShouldThrowExceptionIfModelIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("make", model, 10, 10));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        [TestCase(-50)]

        public void CarConstructorShouldThrowExceptionIfFuelConsumptionIsBelowOrEqualToZero(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("make", "model", fuelConsumption, 10));
        }

        [Test]
        [TestCase(-10)]
        [TestCase(-50)]

        public void CarConstructorShouldThrowExceptionIfFuelCapacityIsBelowOrEqualToZero(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("make", "model", 10, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelShouldThrowExceptionWhenPassedValueIsBelowOrEqualToZero(double value)
        {
            Car car = new Car("VW", "Model", 10, 100);

            Assert.Throws<ArgumentException>(() => car.Refuel(0));
        }

        [Test]
        [TestCase(100, 50, 50)]
        [TestCase(200, 350, 200)]
        public void RefuelShouldWorkAsExpected(double capacity, double fuel, double expectedResult)
        {
            Car car = new Car("VW", "Model", 10, capacity);

            car.Refuel(fuel);

            var actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(10, 50, 505)]
        [TestCase(15, 30, 201)]
       
        
        public void DriveShouldThrowExceptionIfFuelAmountIsNotEnough
            (double fuelConsumption, double refuel, double km)
        {
            Car car = new Car("VW", "Model", fuelConsumption, 100);

            car.Refuel(refuel);

            var actualResult = car.FuelAmount;

            Assert.Throws<InvalidOperationException>(() => car.Drive(km));
        }

        [Test]
        [TestCase(10, 100, 50, 95)]

        public void DriveShouldReduceFuelBasedOnDrivenKm(double fuelConsumption, double fuel, double km, double fuelAmountLeft)
        {
            Car car = new Car("VW", "Model", fuelConsumption, 100);

            car.Refuel(fuel);

            car.Drive(km);

            var expectedValue = fuelAmountLeft;
            var actualValue = car.FuelAmount;

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}