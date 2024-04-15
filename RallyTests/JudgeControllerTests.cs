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
            AddJudgeViewModel addJudgeViewModel = new AddJudgeViewModel("firstName", "lastName");

            //Act
            controller.AddJudge(addJudgeViewModel);


            //Assert
            Assert.AreEqual(testRepository.TestJudges.Count(), 1);
            Assert.AreEqual(testRepository.TestJudges[0].FirstName, "firstName");
            Assert.AreEqual(testRepository.TestJudges[0].LastName, "lastName");

        }

        [TestMethod]
        public async Task TestgetJudge() 
        {
            //Arrange
            JudgeTestRepository testRepository = new JudgeTestRepository();
            JudgeController controller = new JudgeController(testRepository);
            testRepository.TestJudges.Clear();
            testRepository.AddJudge(new Judge("Kathrine", "Hansen"));
            testRepository.AddJudge(new Judge("Peter", "Nielsen"));

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
            testRepository.AddJudge(new Judge("Kathrine", "Hansen"));
            testRepository.AddJudge(new Judge("Peter", "Nielsen"));

            //Act
            IEnumerable<GetJudgeViewModel> judgesVM = await controller.GetAllJudges();
            List<GetJudgeViewModel> judgeVMList = judgesVM.ToList();
            int count = judgeVMList.Count();

            //Assert
            Assert.AreEqual(count, 2);  

        }

        [TestMethod]
        public async Task TestUpdateJudge() 
        {
            //Arrange
            JudgeTestRepository testRepository = new JudgeTestRepository();
            JudgeController controller = new JudgeController(testRepository);
            testRepository.TestJudges.Clear();
            testRepository.AddJudge(new Judge("Kathrine", "Hansen"));
            Judge judge = new Judge("OpdateretKathrine", "OpdateretHansen", 1);

            //Act
            controller.UpdateJudge(judge);

            //Assert
            Assert.AreEqual(testRepository.TestJudges[0].FirstName, "OpdateretKathrine");
            Assert.AreEqual(testRepository.TestJudges[0].LastName, "OpdateretHansen");
        }

        [TestMethod]
        public async Task DeleteJudge() 
        {
            //Arrange
            JudgeTestRepository testRepository = new JudgeTestRepository();
            JudgeController controller = new JudgeController(testRepository);
            testRepository.TestJudges.Clear();
            testRepository.AddJudge(new Judge("Gurli", "Gris"));

            //Act
            controller.DeleteJudge(1);
            int count = testRepository.TestJudges.Count();

            //Assert
            Assert.AreEqual (count, 0);
        }


    }
}
