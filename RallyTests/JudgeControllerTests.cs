using API.Controllers;
using API.ViewModels;
using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccess;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTests
{
    [TestClass]
    public class JudgeControllerTests
    {
        [TestMethod]
        public async Task TestAddJudge()
        {
            //Arrange
            JudgeTestRepository testRepository = new JudgeTestRepository();
            JudgeController controller = new JudgeController(testRepository);
            testRepository.TestJudges.Clear();

            //Act
            controller.AddJudge("fornavn", "efternavn");


            //Assert
            Assert.AreEqual(testRepository.TestJudges.Count(), 1);
            Assert.AreEqual(testRepository.TestJudges[0].FirstName, "fornavn");
            Assert.AreEqual(testRepository.TestJudges[0].LastName, "efternavn");

        }

        [TestMethod]
        public async Task TestgetJudge() 
        {
            //Arrange
            JudgeTestRepository testRepository = new JudgeTestRepository();
            JudgeController controller = new JudgeController(testRepository);
            testRepository.TestJudges.Clear();
            testRepository.AddJudge("Kathrine", "Hansen");
            testRepository.AddJudge("Peter", "Nielsen");

            //Act
            GetJudgeViewModel judgeVM = await controller.GetJudge(2);

            //Assert
            Assert.AreEqual(judgeVM.FirstName, "Peter");
            Assert.AreEqual(judgeVM.LastName, "Nielsen");


        }
        [TestMethod]
        public async Task TestGetAllJudges() 
        {
            //Arrange
            JudgeTestRepository testRepository = new JudgeTestRepository();
            JudgeController controller = new JudgeController(testRepository);
            testRepository.TestJudges.Clear();
            testRepository.AddJudge("Kathrine", "Hansen");
            testRepository.AddJudge("Peter", "Nielsen");

            //Act
            IEnumerable<Judge> judges = await controller.GetAllJudges();
            List<Judge> judgeList = judges.ToList();
            int count = judgeList.Count();

            //Assert
            Assert.AreEqual(count, 2);  


        }


    }
}
