using Simulator;
using Simulator.Maps;
using System.Net.WebSockets;

namespace TestSimulator;

public class SmallSquareMapTest
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        // Arrange
        int size = 10;
        // Act
        var map = new SmallSquareMap(size);
        // Assert
        Assert.Equal(size, map.Size);
    }
    [Theory]
    [InlineData(3)]
    [InlineData(30)]
    public void Constructor_InvalidSize_ShouldThrowException(int size)
    {
        // Act
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
             new SmallSquareMap(size));
    }

    [Theory]
    [InlineData(5,7,10,true)]
    [InlineData(13, 7, 14, true)]
    [InlineData(9, 7, 6, false)]
    [InlineData(20, 7, 20, false)]
    public void Exist_CheckIf_PointIsOnTheMap(int x, int y, int size, bool expectec)
    {
        //arrange
        Point testpoint = new Point(x, y);
        var squaremap = new SmallSquareMap(size);
        //act
        var result = squaremap.Exist(testpoint);
        //assert
        Assert.Equal(expectec, result);
    }

    [Theory]
    [InlineData(5, 7, Direction.Right, 6, 7)]
    [InlineData(0, 7, Direction.Left, 0, 7)]
    [InlineData(8, 12, Direction.Up, 8, 13)]
    [InlineData(5, 7, Direction.Down, 5, 6)]
    [InlineData(13, 0, Direction.Down, 13, 0)]
    public void Next_CheckIf_ReturnsProperPoint(int x, int y, Direction dir, int res_x, int res_y)
    {
        //arrange
        Point testpoint = new Point(x, y);
        var squaremap = new SmallSquareMap(20);
        //act
        var result = squaremap.Next(testpoint, dir);
        //assert
        var expected = new Point(res_x, res_y);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 7, Direction.Right, 6, 6)]
    [InlineData(3, 7, Direction.Left, 2, 8)]
    [InlineData(8, 12, Direction.Up, 9, 13)]
    [InlineData(5, 7, Direction.Down, 4, 6)]
    [InlineData(13, 0, Direction.Down, 13, 0)]
    public void NextDiagonal_CheckIf_ReturnsProperPoint(int x, int y, Direction dir, int res_x, int res_y)
    {
        //arrange
        Point testpoint = new Point(x, y);
        var squaremap = new SmallSquareMap(20);
        //act
        var result = squaremap.NextDiagonal(testpoint, dir);
        //assert
        var expected = new Point(res_x, res_y);
        Assert.Equal(expected, result);
    }
}
