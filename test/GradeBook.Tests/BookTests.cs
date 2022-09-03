using Xunit;
namespace GradeBook.Tests;

public class BookTests
{
    [Fact]
    public void Test1()
    {
        // Arrange
        var book = new Book("");
        book.AddGrade(89.1);
        book.AddGrade(90.5);
        book.AddGrade(77.3);
        
        // Act
        var result = book.GetStatistics();

        // Assert (Assertion)
        Assert.Equal(85.6, result.Average);
        Assert.Equal(85.6, result.High);
        Assert.Equal(85.6, result.Low);


    }
}