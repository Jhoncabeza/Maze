using Maze.Logic;

try
{
    var maze = new MyMaze(30, 150);
    Console.WriteLine(maze);
    Console.WriteLine("Congratulations maze solved");
}
catch (Exception ex) {
    Console.WriteLine(ex.Message);
}
