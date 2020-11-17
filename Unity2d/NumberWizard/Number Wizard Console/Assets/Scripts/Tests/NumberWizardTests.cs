using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class NumberWizardTests
    {
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestMinimumandMaximumValuesPasses()
        {
            // Arrange
            var numberWizard = new GameObject("wizard").AddComponent<NumberWizard>();
            
            // Act
            numberWizard.StartGame();

            // Assert
            Assert.IsTrue(numberWizard.minNumber == 1);
            Assert.IsTrue(numberWizard.maxNumber == 1001);
            
            // Finish
            yield return null;
        }
    }
}
