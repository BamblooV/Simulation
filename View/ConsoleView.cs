using Simulation.Model.Entities;
using Simulation.Model.Map;

namespace Simulation.View
{
    internal class ConsoleView : ISimulationView
    {
        public void RenderMap(WorldMap map)
        {
            int rows = map.RowsCount;
            int cols = map.ColsCount;

            DrawRowSeparator(cols);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (col == 0) Console.Write("|");

                    Coordinates coordinates = new(row, col);
                    map.TryGetEntity(coordinates, out var entity);
                    Console.Write($" {GetEntitySymbol(entity)} |");
                }
                DrawRowSeparator(cols);
            }

        }

        private void DrawRowSeparator(int cols)
        {
            Console.WriteLine();
            for (int i = 0; i < cols; i++)
            {
                Console.Write("-----");
            }
            Console.WriteLine();
        }

        private string GetEntitySymbol(Entity? entity) => entity switch
        {
            Grass => "Gr",
            Tree => "Tr",
            Rock => "Ro",
            null => "  ",
            _ => throw new NotImplementedException()
        };
    }
}
