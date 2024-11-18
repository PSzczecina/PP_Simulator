using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class RectangleTest
{
    [Theory]
    [InlineData(2,4,6,8,2,4,6,8)]
    [InlineData(6, 4, 3, 8, 3, 4, 6, 8)]
    [InlineData(6, 9, 2, 3, 2, 3, 6, 9)]
    public void Constructor_XsAndYs_ProperData_MakingRectangle(int x1, int y1, int x2, int y2, int expx1, int expy1, int expx2, int expy2)
    {
        //arrange
        //act
        var rect = new Rectangle(x1, x2, y1, y2);
        //assert
        Assert.Equal((rect.X1, rect.Y1, rect.X2, rect.Y2), (expx1, expy1, expx2, expy2));
    }

    [Fact]
    public void Constructor_XsAndYs_InproperData_ThrowException()
    {
        Assert.Throws<ArgumentException>(() =>
             new Rectangle(1,1,4,5));
    }

    [Theory]
    [InlineData(2, 4, 6, 8, 2, 4, 6, 8)]
    [InlineData(6, 4, 3, 8, 3, 4, 6, 8)]
    [InlineData(6, 9, 2, 3, 2, 3, 6, 9)]
    public void Constructor_Points_ProperData_MakingRectangle(int x1, int y1, int x2, int y2, int expx1, int expy1, int expx2, int expy2)
    {
        //arrange
        var point1 = new Point(x1, y1);
        var point2 = new Point(x2, y2);
        //act
        var rect = new Rectangle(point1, point2);
        //assert
        Assert.Equal((rect.X1, rect.Y1, rect.X2, rect.Y2), (expx1, expy1, expx2, expy2));
    }

    [Fact]
    public void Constructor_Points_InproperData_ThrowException()
    {
        //arrange
        var point1 = new Point(2, 7);
        var point2 = new Point(4, 7);
        Assert.Throws<ArgumentException>(() =>
             new Rectangle(point1, point2));
    }

    [Theory]
    [InlineData(3,5,true)]
    [InlineData(6, 17, true)]
    [InlineData(0, 19, true)]
    [InlineData(3, 22, false)]
    [InlineData(-4, 15, false)]
    public void Contains_CheckIf_PointsAreOrArenotOnRectangle(int x, int y, bool expected)
    {
        //arrange
        var point = new Point(x, y);
        var rect = new Rectangle(0,20,0,20);
        //act
        var result = rect.Contains(point);
        //assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToString_CheckIfDisplaysProperly()
    {
        //arrange
        var rect = new Rectangle(0, 20, 10, 26);
        //act
        //assert
        Assert.Equal("(0, 10):(20, 26)", rect.ToString());
    }

}
