using Microsoft.VisualStudio.TestTools.UnitTesting;
using Multiplication;


namespace MultiplicationTests
{
    [TestClass]
    public class GradeSchoolTest
    {
        [TestMethod]
        public void TestGradeSchool()
        {
            string multiplicand = "23958233";
            string multiplier = "5830";

            string result = Multiplicator.GradeSchool(multiplicand, multiplier);

            Assert.AreEqual("139676498390", result);
        }

    }
}
