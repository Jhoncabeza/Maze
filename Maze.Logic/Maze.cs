namespace Maze.Logic
{
    public class MyMaze
    {
        private char[,] _maze;

        public MyMaze(int n, int obstacles)
        {
            N = n;
            Obstacles = obstacles;
            _maze = new char[N, N];
            FillMaze();
        }

        public int N { get; }
        public int Obstacles { get; }

        public override string ToString()
        {
            var output = string.Empty;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    output += $"{_maze[i, j]}";
                }
                output += "\n";
            }
            return output;
        }

        private void FillMaze()
        {
            FillBorders();

            //bool result = TravelMaze();
            //if (result)
            //{
            //  throw new Exception("congratulations maze solved");
            //}
            //else
            //{
            //  throw new Exception("The maze has no solution ");
            //}
        }



        private void FillBorders()
        {
            int nFC = N - 1;
            char wall = char.Parse("║");
            char floorCeiling = char.Parse("═");


            //horizontal

            for (int i = 1; i < nFC; i++)
            {
                _maze[0, i] = floorCeiling;
                _maze[nFC, i] = floorCeiling;
            }

            //vertical

            for (int i = 1; i < nFC - 1; i++)
            {
                _maze[i + 1, 0] = wall;
                _maze[i, nFC] = wall;
            }

            //corners
            _maze[0, 0] = char.Parse("╔");
            _maze[0, nFC] = char.Parse("╗");
            _maze[nFC, 0] = char.Parse("╚");
            _maze[nFC, nFC] = char.Parse("╝");

            int percentage = (int)(nFC * nFC * 0.30);
            var random = new Random();
            int obstaclesCount = 0;


            while (obstaclesCount <= percentage)
            {
                int row = random.Next(1, ((nFC - 1) + 1)) ;
                int column = random.Next(1, ((nFC - 1) + 1));

                if (_maze[row, column] != wall
                    && !(row == 1 && column == 1)
                    && !(row == 2 && column == 1)
                    && !(row == nFC - 1 && column == nFC - 1)
                    && !(row == nFC - 2 && column == nFC - 1))

                {
                    _maze[row, column] = '║';
                    obstaclesCount++;
                }
            }
        }

        private bool TravelMaze()
        {
            int row = 1;
            int column = 0;
            char _rigth = char.Parse("►");
            char _left = char.Parse("◄");
            char _bottom = char.Parse("▼");
            char wall = char.Parse("║");
            char space = ' ';
            bool flag = true;
            int left = -1;
            int rigth = 1;
            int bottom = 1;

            _maze[row, column] = _rigth;

            while (flag && !(row == N - 2 && column == N - 1))
            {
                if (_maze[row, column + rigth] == space)
                {
                    column += rigth;
                    _maze[row, column] = _rigth;

                }
                else if (_maze[row + bottom, column] == space)
                {
                    row += bottom;
                    _maze[row, column] = _bottom;
                }
                else if (_maze[row, column + left] != wall)
                {
                    column += left;
                    _maze[row, column] = _left;
                }
                else
                {
                    _maze[row, column] = _rigth;
                    flag = false;
                }
            }
            return row == N - 2 && column == N - 1;
        }
    }
}
