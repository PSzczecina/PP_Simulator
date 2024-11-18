using Simulator;

namespace TestSimulator;

public class PointTest
{
    [Fact]
    public void Constructor_MakesPointProperly()
    {
        int x = 1; int y = 4;
        var test = new Point(1,4);
        Assert.Equal((x, y), (test.X,test.Y));
    }
    [Fact]
    public void ToString_ReturnsProperly()
    {
        var test = new Point(1, 4);
        Assert.Equal("(1, 4)", test.ToString());
    }

    [Theory]
    [InlineData(1,4, Direction.Right, 2, 4)]
    [InlineData(1, 4, Direction.Up, 1, 5)]
    [InlineData(6, 0, Direction.Down, 6, -1)]
    [InlineData(7, 4, Direction.Left, 6, 4)]
    public void Next_CheckIf_MovesProperly(int x, int y, Direction dir, int res_x, int res_y)
    {
        //arrange
        var point = new Point(x,y);
        var expected = new Point(res_x, res_y);
        //act
        var test = point.Next(dir);
        //assert
        Assert.Equal(expected, test);
    }

    [Theory]
    [InlineData(1, 4, Direction.Right, 2, 3)]
    [InlineData(1, 4, Direction.Up, 2, 5)]
    [InlineData(6, 0, Direction.Down, 5, -1)]
    [InlineData(7, 4, Direction.Left, 6, 5)]
    public void NextDiagonal_CheckIf_MovesProperly(int x, int y, Direction dir, int res_x, int res_y)
    {
        //arrange
        var point = new Point(x, y);
        var expected = new Point(res_x, res_y);
        //act
        var test = point.NextDiagonal(dir);
        //assert
        Assert.Equal(expected, test);
    }
}
