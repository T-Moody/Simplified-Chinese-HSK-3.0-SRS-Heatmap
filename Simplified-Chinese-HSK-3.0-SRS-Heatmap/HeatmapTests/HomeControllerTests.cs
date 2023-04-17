using Moq;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.Controllers;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.infrastructure;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.Models;

namespace HeatmapTests
{
    public class HomeControllerTests
    {
        //[Fact]
        //public void Index_ReturnsView_WithHskModels()
        //{
        //    // Arrange
        //    var ankiMock = new Mock<IAnki>();
        //    var hskMock = new Mock<IHsk>();

        //    var hskDictionary = new Dictionary<string, int>
        //{
        //    { "hsk1", 10 },
        //    { "hsk2", 20 },
        //    { "hsk3", 30 }
        //};

        //    var hskModels = new List<HskModel>
        //{
        //    new HskModel { Id = 1, Level = "hsk1" },
        //    new HskModel { Id = 2, Level = "hsk2" },
        //    new HskModel { Id = 3, Level = "hsk3" }
        //};

        //    int maxDays = 30;

        //    ankiMock.Setup(a => a.GetDictionary()).Returns(hskDictionary);
        //    hskMock.Setup(h => h.GetAll()).Returns(hskModels);
        //    ankiMock.Setup(a => a.GetMaxDays()).Returns(maxDays);

        //    var controller = new HomeController(ankiMock.Object, hskMock.Object);

        //    // Act
        //    var result = controller.Index() as ViewResult;
        //    var model = result?.Model as List<HskModel>;

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.NotNull(model);
        //    Assert.Equal(hskModels.Count, model.Count);

        //    // You can add more assertions to test the contents of the view result or the model object
        //}
    }
}