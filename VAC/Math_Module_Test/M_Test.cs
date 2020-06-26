﻿using LMath;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Math_Module_Test
{
     [TestClass]
    public class M_Test
    {
        [TestMethod]
        public void CreateTest1()
        {

        }

        [TestMethod]
        public void unarMinusTest1()

        {
            string num = "1_2_3|4_5_6|7_8_9";
            string num1 = "-1_-2_-3|-4_-5_-6|-7_-8_-9";
            M input = Create(num);
            M output = Create(num1);
            Assert.AreEqual(output,-input);
        }
        [TestMethod]
        public void unarMinusTest2()

        {
            string num = "1_2_3|4_5_6|7_8_9";
            string num1 = "-1_-2_-3|-4_-5_-6|-7_-8_-9";
            M input = Create(num1);
            M output = Create(num);
            Assert.AreEqual(output, -input);
        }
        [TestMethod]
        public void binPlusTest1()

        {
            string num = "1_2_3|4_5_6|7_8_9|1_2_3|4_5_6|";
            string num1 = "2_4_6|8_10_12|14_16_18|2_4_6|8_10_12|";
            M input = Create(num);
            M output = Create(num1);
            Assert.AreEqual(output, input + input);
        }
        [TestMethod]
        public void binPlusTest2()

        {
            string num2 = "1_2_3|4_5_6|7_8_9";
            string num1 = "-1_-2_-3|-4_-5_-6|-7_-8_-9";
            string num = "0_0_0|0_0_0|0_0_0";
            M input = Create(num1);
            M input2 = Create(num2);
            M output = Create(num);
            Assert.AreEqual(output, input+input2);
        }
        [TestMethod]
        public void binMinTest1()

        {
            string num1 = "1_2_3|4_5_6|7_8_9";
            string num2 = "-1_-2_-3|-4_-5_-6|-7_-8_-9";
            string num = "2_4_6|8_10_12|14_16_18|";
            M input = Create(num1);
            M input2 = Create(num2);
            M output = Create(num);
            Assert.AreEqual(output, input - input2);
        }

        [TestMethod]
        public void binMinTest2()

        {
            string num1 = "1_2_3|4_5_6|7_8_9";
            string num = "0_0_0|0_0_0|0_0_0";
            M input = Create(num1);
            M output = Create(num);
            Assert.AreEqual(output, input - input);
        }

        [TestMethod]
        public void binMinTest3()

        {
            string num1 = "0_0_0|0_0_0|0_0_0";
            string num2 = "1_2_3|4_5_6|7_8_9";
            string num = "-1_-2_-3|-4_-5_-6|-7_-8_-9";
            M input = Create(num1);
            M input2 = Create(num2);
            M output = Create(num);
            Assert.AreEqual(output, input - input2);
        }
    }

}
