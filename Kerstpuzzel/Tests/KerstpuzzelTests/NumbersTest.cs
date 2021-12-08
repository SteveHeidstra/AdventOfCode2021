using Kerstpuzzel;
using NUnit.Framework;
using System.Collections.Generic;

namespace KerstpuzzelTests
{
    public class NumbersTests
    {
        [Test]
        public void GetFibonacciSequence_gives_right_result()
        {
            List<int> fibonacci = Numbers.GetFibonacciSequence(1);
            Assert.AreEqual(0, fibonacci[0]);
            Assert.AreEqual(1, fibonacci[1]);
            Assert.AreEqual(1, fibonacci[2]);
            Assert.AreEqual(2, fibonacci[3]);
            Assert.AreEqual(3, fibonacci[4]);
            Assert.AreEqual(5, fibonacci[5]);
            Assert.AreEqual(8, fibonacci[6]);
            Assert.AreEqual(7, fibonacci.Count);
        }

        [Test]
        public void GetFibonacciSequence_with_more_digits()
        {
            List<int> fibonacci = Numbers.GetFibonacciSequence(3);
            Assert.AreEqual(17, fibonacci.Count);
            Assert.AreEqual(987, fibonacci[fibonacci.Count - 1]);
        }

        [Test]
        public void IsFibonacci_works_for_fibonaccinumbers()
        {
            Assert.IsTrue(Numbers.IsFibonacci(0));
            Assert.IsTrue(Numbers.IsFibonacci(1));
            Assert.IsTrue(Numbers.IsFibonacci(5));
            Assert.IsTrue(Numbers.IsFibonacci(144));
            Assert.IsTrue(Numbers.IsFibonacci(2584));
            Assert.IsTrue(Numbers.IsFibonacci(121393));
        }

        [Test]
        public void IsFibonacci_works_for_non_fibonaccinumbers()
        {
            Assert.IsFalse(Numbers.IsFibonacci(-5));
            Assert.IsFalse(Numbers.IsFibonacci(4));
            Assert.IsFalse(Numbers.IsFibonacci(254));
            Assert.IsFalse(Numbers.IsFibonacci(1009));
            Assert.IsFalse(Numbers.IsFibonacci(144788));
        }

        [Test]
        public void IsPrime_works_for_primenumbers()
        {
            //2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97
            Assert.IsTrue(Numbers.IsPrime(2));
            Assert.IsTrue(Numbers.IsPrime(5));
            Assert.IsTrue(Numbers.IsPrime(13));
            Assert.IsTrue(Numbers.IsPrime(61));

            Assert.IsTrue(Numbers.IsPrime(79));
            Assert.IsTrue(Numbers.IsPrime(97));

        }

        [Test]
        public void IsPrime_works_for_non_primenumbers()
        {
            Assert.IsFalse(Numbers.IsPrime(0));
            Assert.IsFalse(Numbers.IsPrime(-1));
            Assert.IsFalse(Numbers.IsPrime(8));
            Assert.IsFalse(Numbers.IsPrime(14));
            Assert.IsFalse(Numbers.IsPrime(225));
            Assert.IsFalse(Numbers.IsPrime(69));
        }

        [Test]
        public void Steekproef_DecimalToDifferentBase_8()
        {
            Assert.AreEqual("20", Numbers.DecimalToDifferentBase(16, 8));
            Assert.AreEqual("-2", Numbers.DecimalToDifferentBase(-2, 8));
            Assert.AreEqual("-20", Numbers.DecimalToDifferentBase(-16, 8));
            Assert.AreEqual("0", Numbers.DecimalToDifferentBase(0, 8));
            Assert.AreEqual("105", Numbers.DecimalToDifferentBase(69, 8));
            Assert.AreEqual("175", Numbers.DecimalToDifferentBase(125, 8));
        }

        [Test]
        public void Steekproef_DecimalToDifferentBase_16()
        {
            Assert.AreEqual("B", Numbers.DecimalToDifferentBase(11, 16));
            Assert.AreEqual("-2", Numbers.DecimalToDifferentBase(-2, 16));
            Assert.AreEqual("-B", Numbers.DecimalToDifferentBase(-11, 16));
            Assert.AreEqual("0", Numbers.DecimalToDifferentBase(0, 16));
            Assert.AreEqual("45", Numbers.DecimalToDifferentBase(69, 16));
            Assert.AreEqual("7D", Numbers.DecimalToDifferentBase(125, 16));
        }

    }
}