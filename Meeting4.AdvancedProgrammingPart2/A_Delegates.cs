﻿using System;
using System.Diagnostics;
using FluentAssertions;
using Meeting4.AdvancedProgrammingPart2.BuiltinDelegatesSamples;
using Meeting4.AdvancedProgrammingPart2.CovarianceContravariance;
using Meeting4.AdvancedProgrammingPart2.OperationsWithArray;
using Meeting4.AdvancedProgrammingPart2.OperationsWithInteger;
using NUnit.Framework;

namespace Meeting4.AdvancedProgrammingPart2
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    internal static class A_Delegates
    {
        [TestCase(5, 10)]
        public static void A_DelegateContainReferenceOnMethod(int i, int j)
        {
            // Here ReSharper tells us, that it is redundant call delegate's constructor, because we can simply assign the method
            // But we want to see this syntax now
            // ReSharper disable once RedundantDelegateCreation
            IntOperation operationWithIntegers = new IntOperation(SimpleCalculator.Add);

            var resultSum = operationWithIntegers(i, j);
            resultSum
                .Should()
                .Be(i + j);

            operationWithIntegers = SimpleCalculator.Multiply;

            var resultProduct = operationWithIntegers(i, j);
            resultProduct
                .Should()
                .Be(i * j);
        }

        [Test]
        public static void B_CallMulticastDelegate()
        {
            int[] myArr = {2, -4, 10, 5, -6, 9};

            ArrayOperation arrayOperation = ArrayUtils.PrintArray;
            arrayOperation += ArrayUtils.SortAscending;
            arrayOperation += ArrayUtils.PrintArray;
            arrayOperation += ArrayUtils.SortDescending;
            arrayOperation += ArrayUtils.PrintArray;

            arrayOperation(myArr);
        }

        [Test]
        public static void C_CallDelageteWithCovarianceAndContravariance()
        {
            // Covariant call
            // You can use method, which have a parameter of derived type.
            GetUserInfoOperation printUserInfo = UserHandler.PrintFullName;

            var userInfo = new FullName("Bill", "Black");
            Name userInfoAfterPrinting = printUserInfo(userInfo);
            Trace.TraceInformation(userInfoAfterPrinting.GetType().ToString());
            Trace.TraceInformation(userInfoAfterPrinting.ToString());

            // Contravariant call
            // You can use method, which have an argument of base type
            printUserInfo = UserHandler.PrintName;

            userInfoAfterPrinting = printUserInfo(userInfo);
            Trace.TraceInformation(userInfoAfterPrinting.GetType().ToString());
        }

        [Test]
        public static void D_CallCustomGenericDelegate()
        {
            ConvertToOtherObject<FullName, Name> convertFullnameToName = UserHandler.ToName;

            var userInfo = new FullName("Bill", "Black");
            Name nameInfo = convertFullnameToName(userInfo);

            Trace.TraceInformation(nameInfo.ToString());
        }

        [Test]
        public static void E_CallBuiltinDelegateWithoutParameters()
        {
            Action printTime = Clock.PrintCurrentTime;

            printTime();
        }

        [Test]
        public static void F_CallBuiltinParametrizedDelegateWithReturnType()
        {
            Func<FullName, int, Employee> createEmployee = UserHandler.CreateEmployee;

            var userInfo = new FullName("Bill", "Black");
            var employee = createEmployee(userInfo, 5000);

            Trace.TraceInformation(employee.ToString());
        }
    }
}