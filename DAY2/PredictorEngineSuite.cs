using Moq;

namespace PredictionEngine.Tests;

public class PredictorEngineSuite
{

    [TestCase("Hello how are doing", "doing")]
    //[TestCase]
    public void ShouldCallUnigramFOrPartial(string inputString, string lastword)
    {
        //Arrange
        var mock = new Mock<ILanguageModelAlgo>();

        PredictionEngine predictionEngine = new PredictionEngine(mock.Object);

        //Act
        string predictResult = predictionEngine.Predict(inputString);

        mock.Verify(p => p.predictUsingMonogram(lastword), Times.Once());
    }

    [TestCase("Hello how are you ", "you")]
    //[TestCase]
    public void ShouldCallBigramEndingWithSpace(string inputString, string lastword)
    {
        //Arrange
        var mock = new Mock<ILanguageModelAlgo>();

        PredictionEngine predictionEngine = new PredictionEngine(mock.Object);

        //Act
        string predictResult = predictionEngine.Predict(inputString);

        mock.Verify(p => p.predictUsingBigram(lastword), Times.Once());


    }

    /*

        [Test]
    public void Ping_invokes_DoSomething()
    {
        // ARRANGE
        var mock = new Mock<ILanguageModelAlgo>();
        mock.Setup(p => p.predictUsingMonogram(It.IsAny<string>())).Returns("value");


        // ACT


        // ASSERT
        mock.Verify(p => p.predictUsingMonogram("PING"), Times.Once());
    }
    */
}