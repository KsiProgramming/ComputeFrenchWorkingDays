namespace ComputeFrenchWorkingDays.Tests
{
    public class FrenchWorkingDaysTest
    {
        [Theory]
        [InlineData("2023-07-31", 1, "2023-08-01")]
        [InlineData("2023-07-31", 2, "2023-08-02")]
        [InlineData("2023-12-23", 3, "2023-12-28")]
        [InlineData("2023-12-24", 1, "2023-12-26")]
        [InlineData("2023-07-14", 1, "2023-07-17")]
        [InlineData("2023-07-14", -2, "2023-07-12")]
        public void AddFrenchWorkingDays_DateOnly_ShouldReturnCorrectDate(string inputDate, int workingDaysToAdd, string expectedDate)
        {
            // Arrange
            var inputDateTime = DateOnly.Parse(inputDate);
            var expectedDateTime = DateOnly.Parse(expectedDate);

            // Act
            var resultDateTime = inputDateTime.AddFrenchWorkingDays(workingDaysToAdd);

            // Assert
            resultDateTime.Should().Be(expectedDateTime);
        }

        [Theory]
        [InlineData("2023-07-31", 0, "Working days must be a nonzero number. (Parameter 'workingDays')")]
        [InlineData("1200-07-31", 2, "Year must be greater than or equal to 1583. (Parameter 'dateOnly')")]
        public void AddFrenchWorkingDays_DateOnly_OutOfRangeException(string inputDate, int workingDaysToAdd, string expectedExceptionMessage)
        {
            // Arrange
            var inputDateTime = DateTime.Parse(inputDate);

            // Act
            var act = () => inputDateTime.AddFrenchWorkingDays(workingDaysToAdd);

            // Assert
            act
                .Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage(expectedExceptionMessage);
        }

        [Theory]
        [InlineData("2023-07-31 12:34:56", 1, "2023-08-01 12:34:56")]
        [InlineData("2023-07-31 18:45:00", 2, "2023-08-02 18:45:00")]
        [InlineData("2023-12-23 09:00:00", 3, "2023-12-28 09:00:00")]
        [InlineData("2023-12-24 14:30:00", 1, "2023-12-26 14:30:00")]
        [InlineData("2023-07-14 16:40:00", 1, "2023-07-17 16:40:00")]
        [InlineData("2023-07-14 22:50:00", -2, "2023-07-12 22:50:00")]
        public void AddFrenchWorkingDays_DateTime_ShouldReturnCorrectDate(string inputDate, int workingDaysToAdd, string expectedDate)
        {
            // Arrange
            var inputDateTime = DateTime.Parse(inputDate);
            var expectedDateTime = DateTime.Parse(expectedDate);

            // Act
            var resultDateTime = inputDateTime.AddFrenchWorkingDays(workingDaysToAdd);

            // Assert
            resultDateTime.Should().Be(expectedDateTime);
        }

        [Theory]
        [InlineData("2023-07-31 18:45:00", 0, "Working days must be a nonzero number. (Parameter 'workingDays')")]
        [InlineData("1200-07-31 02:15:00", 2, "Year must be greater than or equal to 1583. (Parameter 'dateOnly')")]
        public void AddFrenchWorkingDays_DateTime_OutOfRangeException(string inputDate, int workingDaysToAdd, string expectedExceptionMessage)
        {
            // Arrange
            var inputDateTime = DateTime.Parse(inputDate);

            // Act
            var act = () => inputDateTime.AddFrenchWorkingDays(workingDaysToAdd);

            // Assert
            act
                .Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage(expectedExceptionMessage);
        }


    }
}
