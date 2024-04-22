using API.Controllers;
using API.ViewModels;
using BusinessLogic.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

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
            await controller.AddJudge(addJudgeViewModel);


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
            await testRepository.AddJudge(new Judge("Kathrine", "Hansen"));
            await testRepository.AddJudge(new Judge("Peter", "Nielsen"));

            //Act
            OkObjectResult? result = (OkObjectResult)await controller.GetJudge(2);

            //Assert
            var judgeVM = result.Value as GetJudgeViewModel;

            Assert.AreEqual(judgeVM!.FirstName, "Peter");
            Assert.AreEqual(judgeVM!.LastName, "Nielsen");
        }

        [TestMethod]
        public async Task TestGetAllJudges()
        {
            //Arrange
            JudgeTestRepository testRepository = new JudgeTestRepository();
            JudgeController controller = new JudgeController(testRepository);
            await testRepository.AddJudge(new Judge("Kathrine", "Hansen"));
            await testRepository.AddJudge(new Judge("Peter", "Nielsen"));

            //Act
            OkObjectResult result = (OkObjectResult)await controller.GetAllJudges();

            //Assert
            IEnumerable<GetJudgeViewModel> judgesVM = (IEnumerable<GetJudgeViewModel>)result.Value!;
            List<GetJudgeViewModel> judgeVMList = judgesVM.ToList();

            Assert.AreEqual(judgeVMList.Count(), 2);
        }

        [TestMethod]
        public async Task TestUpdateJudge()
        {
            //Arrange
            JudgeTestRepository testRepository = new JudgeTestRepository();
            JudgeController controller = new JudgeController(testRepository);
            await testRepository.AddJudge(new Judge("Kathrine", "Hansen"));
            UpdateJudgeViewModel updateJudgeViewModel = new UpdateJudgeViewModel("OpdateretKathrine", "OpdateretHansen", 1);

            //Act
            await controller.UpdateJudge(updateJudgeViewModel);

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

            await testRepository.AddJudge(new Judge("Gurli", "Gris"));

            //Act
            await controller.DeleteJudge(1);

            //Assert
            Assert.AreEqual(testRepository.TestJudges.Count(), 0);
        }
    }
}
