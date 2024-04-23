using API.Controllers;
using API.ViewModels;
using BusinessLogic.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace RallyTests;

[TestClass]
public class JudgeControllerTests
{
    private readonly JudgeTestRepository testRepository;
    private readonly JudgeController judgeController;
    
    public JudgeControllerTests()
    {
        testRepository = new JudgeTestRepository();
        judgeController = new JudgeController(testRepository);
    }

        
    [TestMethod]
    public async Task TestAddJudge()
    {
        //Arrange
        AddJudgeViewModel addJudgeViewModel = new AddJudgeViewModel("firstName", "lastName");


        //Act
        await judgeController.AddJudge(addJudgeViewModel);


        //Assert
        Assert.AreEqual(1, testRepository.TestJudges.Count());
        Assert.AreEqual(testRepository.TestJudges[0].FirstName, "firstName");
        Assert.AreEqual(testRepository.TestJudges[0].LastName, "lastName");

    }

    [TestMethod]
    public async Task TestgetJudge()
    {
        //Arrange
        await testRepository.AddJudge(new Judge("Peter", "Nielsen"));

        //Act
        GetJudgeViewModel getJudgeViewModel = (await judgeController.GetJudge(1))
            .GetValueAs<GetJudgeViewModel>();

        //Assert
        Assert.AreEqual(getJudgeViewModel.FirstName, "Peter");
        Assert.AreEqual(getJudgeViewModel.LastName, "Nielsen");
    }

    [TestMethod]
    public async Task TestGetAllJudges()
    {
        //Arrange
        await testRepository.AddJudge(new Judge("Kathrine", "Hansen"));
        await testRepository.AddJudge(new Judge("Peter", "Nielsen"));

        //Act
        GetAllJudgesViewModel getAllJudgesViewModel = (await judgeController.GetAllJudges())
            .GetValueAs<GetAllJudgesViewModel>();

        //Assert
        Assert.AreEqual("Kathrine", getAllJudgesViewModel.Judges[0].FirstName);
        Assert.AreEqual("Hansen", getAllJudgesViewModel.Judges[0].LastName);
        Assert.AreEqual("Peter", getAllJudgesViewModel.Judges[1].FirstName);
        Assert.AreEqual("Nielsen", getAllJudgesViewModel.Judges[1].LastName);
    }

    [TestMethod]
    public async Task TestUpdateJudge()
    {
        //Arrange       
        await testRepository.AddJudge(new Judge("Kathrine", "Hansen"));
        UpdateJudgeViewModel updateJudgeViewModel = new UpdateJudgeViewModel("OpdateretKathrine", "OpdateretHansen", 1);

        //Act
        IActionResult result = await judgeController.UpdateJudge(updateJudgeViewModel);

        //Assert
        Assert.IsInstanceOfType<OkResult>(result);
        Assert.AreEqual("OpdateretKathrine", testRepository.TestJudges[0].FirstName);
        Assert.AreEqual("OpdateretHansen", testRepository.TestJudges[0].LastName);
    }

    [TestMethod]
    public async Task DeleteJudge()
    {
        //Arrange
        await testRepository.AddJudge(new Judge("Gurli", "Gris"));

        //Act
        IActionResult result = await judgeController.DeleteJudge(1);

        //Assert
        Assert.IsInstanceOfType<OkResult>(result);
        Assert.AreEqual(testRepository.TestJudges.Count(), 0);
    }
}
