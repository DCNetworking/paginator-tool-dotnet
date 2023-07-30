using PaginatorTool;
using PaginatorTool.Extension;
using System.Numerics;
using Xunit;

namespace PaginatorTool.Test;

public class UnitTest1
{
    private readonly List<Product> TestList = new() { new(1), new(2), new(3), new(4), new(5), new(6), new(7), new(8), new(9), new(10), new(11), new(12), new(13), new(14), new(15), new(16), new(17), new(18), new(19), new(20) };
    [Fact]
    public void Is_2PagesInPaginator()
    {
        // Arrange
        Paginator<Product> products = new(TestList, range: 10);

        int expectedPages = 2;
        // Act
        (int actualPage, int numberofPages) = products.GetPageStateInfo();

        // Assert
        Assert.Equal(expectedPages, numberofPages);
    }
    [Fact]
    public void Is_SetPageActualPageFourth()
    {
        // Arrange
        Paginator<Product> products = new(TestList, range: 5);
        int expectedAcutalPage = 4;
        // Act
        products.SetPage(4);
        (int actualPage, int numberofPages) = products.GetPageStateInfo();
        // Assert
        Assert.Equal(actualPage, expectedAcutalPage);
    }
    [Fact]
    public void Is_NextPageActualPageSecond()
    {
        // Arrange
        Paginator<Product> products = new(TestList, range: 5);
        int expectedAcutalPage = 2;
        // Act
        products.SetNext();
        (int actualPage, int numberofPages) = products.GetPageStateInfo();
        // Assert
        Assert.Equal(actualPage, expectedAcutalPage);
    }
    [Fact]
    public void Is_PrevPageActualPageStillFirst()
    {
        // Arrange
        Paginator<Product> products = new(TestList, range: 5);
        int expectedAcutalPage = 1;
        // Act
        products.SetPrev();
        (int actualPage, int numberofPages) = products.GetPageStateInfo();
        // Assert
        Assert.Equal(actualPage, expectedAcutalPage);
    }
    [Fact]
    public void Is_ItemOfSecondPageEqual()
    {
        // Arrange
        Paginator<Product> products = new(TestList, range: 5);
        int expectedProdId = 6;
        // Act
        products.SetNext();
        var prodList = products.CurrentState();
        int actualProdId = prodList.First().Id;
        // Assert
        Assert.Equal(actualProdId, expectedProdId);
    }
    [Fact]
    public void Is_WrongPageNotSet()
    {
        // Arrange
        Paginator<Product> products = new(TestList, range: 5);
        int expectedPage = 1;
        // Act
        products.SetPage(10);
        (int actualPage, int numberofPages) = products.GetPageStateInfo();
        // Assert
        Assert.Equal(actualPage, expectedPage);
    }
    [Fact]
    public void Is_NextStep2Works()
    {
        // Arrange
        Paginator<Product> products = new(TestList, range: 5, stepChange: 2);
        int expectedPage = 3;
        // Act
        products.SetNext();
        (int actualPage, int numberofPages) = products.GetPageStateInfo();
        // Assert
        Assert.Equal(actualPage, expectedPage);
    }
    class Product
    {
        public int Id { get; private set; }
        public Product(int id)
        {
            Id = id;
        }
    }
}
