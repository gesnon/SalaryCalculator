using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalaryCalculator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculator.Logic.Models.Tests
{
    [TestClass()]
    public class FreelancerTests
    {
        [TestMethod()]
        public void AddWorkTimeTest()
        {
            Freelancer testFreelancer = new Freelancer("фрилансер имя","фрилансер фамилия");

            testFreelancer.AddWorkTime(testFreelancer, 7.5f, new DateTime(2020, 12, 19), "запись 1");
        }
    }
}