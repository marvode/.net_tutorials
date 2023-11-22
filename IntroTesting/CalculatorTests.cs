using Calculator;

namespace IntroTesting;

public class CalculatorTests
{
    [Fact]
    public void Should_AddTwoNumbersTogether()
    {
        // Arrange
        var firstNum = 2;
        var secondNum = 1;
        var expected = 3;

        // Act 
        var calculator = new Calculate();
        var actual = calculator.Add(firstNum, secondNum);

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Should_MultiplyTwoNumbers()
    {
        // Arrange
        var firstNum = 2;
        var secondNum = 5;
        var expected = 10;

        // Act 
        var calculator = new Calculate();
        var actual = calculator.Multiply(firstNum, secondNum);

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData(2, 5, 10)]
    [InlineData(1, 6, 6)]
    [InlineData(0, 100, 0)]
    [InlineData(-1, 5, -5)]
    [InlineData(-5, -5, 25)]
    public void Should_MultiplyTwoNumbersTheory(int firstNum, int secondNum, int expected)
    {
        // Act 
        var calculator = new Calculate();
        var actual = calculator.Multiply(firstNum, secondNum);

        // Assert
        Assert.Equal(expected, actual);
    }
}