using Xunit;
namespace GradeBook.Tests;

public class TypeTests
{
    [Fact]
    public void GetBookReturnsDifferentObjects()
    {
        // Arrange
        // var book1 = new Book("Book 1");
        var book1 = GetBook("Book 1");
        var book2 = GetBook("Book 2");

        
        // Act
        // GetBook() is the 'Act'

        // Assert (Assertion)
        Assert.Equal("Book 1", book1.Name);
        Assert.Equal("Book 2", book2.Name);
        Assert.NotSame(book1, book2);

    }
    [Fact]
    public void TwoVarsCanReferenceSameObject()
    {
        // Arrange
        // var book1 = new Book("Book 1");
        var book1 = GetBook("Book 1");
        var book2 = book1;

        
        // Act
        // GetBook() is the 'Act'

        // Assert (Assertion)
        // Assert.Equal("Book 1", book1.Name);
        // Assert.Equal("Book 1", book2.Name);
        Assert.Same(book1, book2);
        Assert.True(Object.ReferenceEquals(book1, book2));

    }

    // Lowest base type (object)
    Book GetBook(string name)
    {
        return new Book(name);
    }
}