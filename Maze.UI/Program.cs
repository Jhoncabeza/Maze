using Maze.Logic;


var maze = new MyMaze(30, 150);

Console.WriteLine("maze skeleton".ToUpper());
Console.WriteLine(maze.MazeBorder);
Console.WriteLine("******************************");
Console.WriteLine(maze);

if (maze.Win)
{
    Console.WriteLine("the maze has a solution".ToUpper());
}
else
{ 
    Console.WriteLine("the maze has no solution".ToUpper());
}

