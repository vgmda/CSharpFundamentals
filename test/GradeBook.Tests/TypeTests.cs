using System;
using Xunit;
namespace GradeBook.Tests;

public delegate string WriteLogDelegate(string logMessage);

public class TypeTests
{
    int count = 0;

    [Fact]
    public void WriteLogDelegateCanPointToMethod()
    {
        WriteLogDelegate log = ReturnMessage;

        // log = ReturnMessage;
        log += new WriteLogDelegate(ReturnMessage);
        log += IncrementCount;

        var result = log("Hello!");
        Assert.Equal(3, count);

    }

    string IncrementCount(string message)
    {
        count++;
        return message.ToLower();
    }

    string ReturnMessage(string message)
    {
        count++;
        return message;
    }


    [Fact]
    public void StringsBehaveLikeValueTypes()
    {
        // Given
        string name = "Vaso";

        // When
        var upper = MakeUppercase(name);

        // Then
        Assert.Equal("Vaso", name);
        Assert.Equal("VASO", upper);

    }

    private string MakeUppercase(string parameter)
    {
        return parameter.ToUpper();
    }

    [Fact]
    public void ValueTypesAlsoPassByValue()
    {
        // Given
        var x = GetInt();

        // When
        SetInt(ref x);

        // Then
        Assert.Equal(42, x);
    }

    private void SetInt(ref int z)
    {
        z = 42;
    }

    private int GetInt()
    {
        return 3;
    }

    [Fact]
    public void CSharpCanPassByRef()
    {
        // Arrange
        // var book1 = new Book("Book 1");
        var book1 = GetBook("Book 1");


        // Act
        // SetName(book1, "New Name");
        GetBookSetName(out book1, "New Name");

        // Assert (Assertion)
        Assert.Equal("New Name", book1.Name);

    }

    private void GetBookSetName(out InMemoryBook book, string name)
    {
        book = new InMemoryBook(name);
    }


    [Fact]
    public void CSharpIsPassByValue()
    {
        // Arrange
        // var book1 = new Book("Book 1");
        var book1 = GetBook("Book 1");


        // Act
        // SetName(book1, "New Name");
        GetBookSetName(book1, "New Name");

        // Assert (Assertion)
        Assert.Equal("Book 1", book1.Name);

    }

    private void GetBookSetName(InMemoryBook book, string name)
    {
        book = new InMemoryBook(name);
    }


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

    private void SetName(InMemoryBook book, string name)
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
    InMemoryBook GetBook(string name)
    {
        return new InMemoryBook(name);
    }
}