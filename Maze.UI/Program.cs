using Maze.Logic;


var maze = new MyMaze(30, 150);
Console.WriteLine(maze);

if (maze.Win)
{
    
    Console.WriteLine("the maze has a solution");
}
else
{
    Console.WriteLine("the maze has no solution");
}

