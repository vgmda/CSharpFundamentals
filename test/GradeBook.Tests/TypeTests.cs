using System;
using Xunit;
namespace GradeBook.Tests;

public class TypeTests
{
    [Fact]
    public void CanSetNameFromReference()
    {
        // Arrange
        // var book1 = new Book("Book 1");
        var book1 = GetBook("Book 1");
        
        
        // Act
        // SetName(book1, "New Name");
        SetName(book1, "New Name");

        // Assert (Assertion)
        Assert.Equal("New Name", book1.Name);

    }

    private void SetName(Book book, string name)
    {
        book.Name = name;
    }

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