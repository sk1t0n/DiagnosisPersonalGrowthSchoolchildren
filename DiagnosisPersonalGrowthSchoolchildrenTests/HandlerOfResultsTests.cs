using DiagnosisPersonalGrowthSchoolchildren;

namespace DiagnosisPersonalGrowthSchoolchildrenTests
{
    public class HandlerOfResultsTests
    {
        private int[] answers = [
            1, 4, -2, 3, 1, 2, -1, 3, 0, 2, 1, 4, -3,
            1, 4, -2, 3, 1, 2, -1, 3, 0, 2, 1, 4, -3,
            1, 4, -2, 3, 1, 2, -1, 3, 0, 2, 1, 4, -3,
            1, 4, -2, 3, 1, 2, -1, 3, 0, 2, 1, 4, -3,
            1, 4, -2, 3, 1, 2, -1, 3, 0, 2, 1, 4, -3,
            1, 4, -2, 3, 1, 2, -1, 3, 0, 2, 1, 4, -3,
            1, 4, -2, 3, 1, 2, -1, 3, 0, 2, 1, 4, -3,
        ];

        [Fact]
        public void HandlerOfResultsTests_CalculateResult_ReturnsSuccess()
        {
            // Arrange
            var handler = new HandlerOfResults();
            var expected = -1;
            
            // Act
            var result = handler.CalculateResult(answers);

            // Assert
            Assert.Equal(expected, result[0]);
        }
    }
}