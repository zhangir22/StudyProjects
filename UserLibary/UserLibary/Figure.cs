using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLibary
{
    class Figure
    {
        public int  Raduis { get; set; }
        public int  SideA { get; set; }
        public int  SideB { get; set; }
        public int  SideC { get; set; }

        public Figure(int side_a = 0, int side_b = 0, int side_c = 0) {
            SideA = side_a;
            SideB = side_b;
            SideC = side_c;
            
        }
        public Figure(int raduis = 0)
        {
            Raduis = raduis;
        }
        private int FindSquareTriangle()
        {
            int cut = 2;
            int perimetr = (SideA + SideB + SideC) / cut;
            return Convert.ToInt32(Math.Sqrt(Convert.ToDouble(perimetr * (perimetr - SideA) * (perimetr - SideB) * (perimetr - SideC))));
        }
        private int FindSquareCircle(int raduis)
        {
            return Convert.ToInt32(Math.PI * Convert.ToDouble((raduis * raduis)));
        }
        public void FindFigure()
        {
            
            if(SideA == 0 && SideB == 0 && SideC == 0)
            {
                Console.WriteLine($"По моим данными мы узнали что ваше фигура это круг в котором Площадь {FindSquareCircle(Convert.ToInt32(Raduis))}");
            }
            else 
            {
                int value = Convert.ToInt32(FindSquareCircle(Raduis));
                if (value != 0) Console.WriteLine($"Мы обнуружили что данный треугольник является прямоугольным в котором Площадь {value}");

            }


        }

    }
}
