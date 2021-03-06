﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Tests
{
    [TestClass()]
    public class PropTests
    {
        [TestMethod()]
        public void checkInRange_ZeroInRange_True()
        {
            double number1 = 0;
            double number2 = 0;
            double range = 0;

            bool actual = Prop.CheckInRange(number1, number2, range);

            Assert.IsTrue(actual, "Zero in range");
        }

        [TestMethod()]
        public void checkInRange_OnehundredInRange_True()
        {
            double number1 = 100;
            double number2 = 100;
            double range = 100;

            bool actual = Prop.CheckInRange(number1, number2, range);

            Assert.IsTrue(actual, "Onehunderd is in range");
        }

        [TestMethod()]
        public void checkInRange_LargeRangeInRange_True()
        {
            double number1 = 0;
            double number2 = 100;
            double range = 1000;

            bool actual = Prop.CheckInRange(number1, number2, range);

            Assert.IsTrue(actual, "Large range is in range");
        }

        [TestMethod()]
        public void checkInRange_SmallNumberInRange_True()
        {
            double number1 = 10;
            double number2 = 0;
            double range = 100;

            bool actual = Prop.CheckInRange(number1, number2, range);

            Assert.IsTrue(actual, "Small number is in range");
        }

        [TestMethod()]
        public void checkInRange_LargeRangeInRange_False()
        {
            double number1 = 0;
            double number2 = 2000;
            double range = 1000;

            bool actual = Prop.CheckInRange(number1, number2, range);

            Assert.IsFalse(actual, "Large range is not in range");
        }

        [TestMethod()]
        public void checkInRange_SmallNumberInRange_False()
        {
            double number1 = 10;
            double number2 = 0;
            double range = 5;

            bool actual = Prop.CheckInRange(number1, number2, range);

            Assert.IsFalse(actual, "Small number is not in range");
        }

        [TestMethod()]
        public void checkInRange_DoubleInRange_True()
        {
            double number1 = 55.55;
            double number2 = 77.77;
            double range = 99.99;

            bool actual = Prop.CheckInRange(number1, number2, range);

            Assert.IsTrue(actual, "Double is in range");
        }

        [TestMethod()]
        public void checkInRange_DoubleInRange_False()
        {
            double number1 = 55.55;
            double number2 = 77.77;
            double range = 11.11;

            bool actual = Prop.CheckInRange(number1, number2, range);

            Assert.IsFalse(actual, "Double is not in range");
        }

        [TestMethod()]
        public void checkInRange_MinusInRange_True()
        {
            double number1 = -10;
            double number2 = -50;
            double range = 100;

            bool actual = Prop.CheckInRange(number1, number2, range);

            Assert.IsTrue(actual, "Minus is in range");
        }

        [TestMethod()]
        public void checkInRange_MinusInRange_False()
        {
            double number1 = -10;
            double number2 = -50;
            double range = 20;

            bool actual = Prop.CheckInRange(number1, number2, range);

            Assert.IsFalse(actual, "Minus is not in range");
        }
    }
}