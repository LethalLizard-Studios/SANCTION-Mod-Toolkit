/* All Rights Reserved to LethalLizard Studios
-- Created By: Leland T L Carter
-- DATE: 11/13/2024
*/

using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tests
{
    public class ValidationTests
    {
        private TMP_InputField inputField;
        private Outline outline;

        [SetUp]
        public void SetUp()
        {
            GameObject inputGO = new GameObject("InputFieldTest");

            inputField = inputGO.AddComponent<TMP_InputField>();
            outline = inputGO.AddComponent<Outline>();
            outline.enabled = false;
        }

        [Test]
        public void Test_CheckInputNullOrEmpty_InputIsEmpty()
        {
            inputField.text = "";

            bool result = Validation.CheckInputNullOrEmpty(inputField);

            Assert.IsFalse(result);
            Assert.IsTrue(outline.enabled);
        }

        [Test]
        public void Test_CheckInputNullOrEmpty_InputIsNotEmpty()
        {
            inputField.text = "Test Input";

            bool result = Validation.CheckInputNullOrEmpty(inputField);

            Assert.IsTrue(result);
            Assert.IsFalse(outline.enabled);
        }

        [Test]
        public void Test_CheckInputGreaterThan_InputGreaterThanThreshold()
        {
            inputField.text = "15";

            bool result = Validation.CheckInputGreaterThan(inputField, 10);

            Assert.IsTrue(result);
            Assert.IsFalse(outline.enabled);
        }

        [Test]
        public void Test_CheckInputGreaterThan_InputEqualToThreshold()
        {
            inputField.text = "10";

            bool result = Validation.CheckInputGreaterThan(inputField, 10);

            Assert.IsFalse(result);
            Assert.IsTrue(outline.enabled);
        }

        [Test]
        public void Test_CheckInputGreaterThan_InputLessThanThreshold()
        {
            inputField.text = "5";

            bool result = Validation.CheckInputGreaterThan(inputField, 10);

            Assert.IsFalse(result);
            Assert.IsTrue(outline.enabled);
        }

        [Test]
        public void Test_CheckInputRange_InputWithinRange()
        {
            inputField.text = "10";

            bool result = Validation.CheckInputRange(inputField, 5, 15);

            Assert.IsTrue(result);
            Assert.IsFalse(outline.enabled);
        }

        [Test]
        public void Test_CheckInputRange_InputBelowMinRange()
        {
            inputField.text = "4";

            bool result = Validation.CheckInputRange(inputField, 5, 15);

            Assert.IsFalse(result);
            Assert.IsTrue(outline.enabled);
        }

        [Test]
        public void Test_CheckInputRange_InputAboveMaxRange()
        {
            inputField.text = "20";

            bool result = Validation.CheckInputRange(inputField, 5, 15);

            Assert.IsFalse(result);
            Assert.IsTrue(outline.enabled);
        }

        [Test]
        public void Test_CheckInputRange_InputNotANumber()
        {
            inputField.text = "NotANumber";

            bool result = Validation.CheckInputRange(inputField, 5, 15);

            Assert.IsFalse(result);
            Assert.IsTrue(outline.enabled);
        }
    }
}