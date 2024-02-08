using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            // Вычисляем вектора AB и AP
            double abx = bx - ax;
            double aby = by - ay;
            double apx = x - ax;
            double apy = y - ay;

            // Скалярное произведение векторов AB и AP
            double abDotAp = abx * apx + aby * apy;

            // Если скалярное произведение меньше нуля, то проекция точки на отрезок лежит за точкой A
            if (abDotAp <= 0)
                return Math.Sqrt(apx * apx + apy * apy);

            // Скалярное произведение векторов BA и BP
            double bax = ax - bx;
            double bay = ay - by;
            double bpx = x - bx;
            double bpy = y - by;
            double baDotBp = bax * bpx + bay * bpy;

            // Если скалярное произведение меньше нуля, то проекция точки на отрезок лежит за точкой B
            if (baDotBp <= 0)
                return Math.Sqrt(bpx * bpx + bpy * bpy);

            // Вычисляем площадь треугольника ABP
            double area = Math.Abs(abx * bpy - aby * bpx);

            // Длина отрезка AB
            double lengthAB = Math.Sqrt(abx * abx + aby * aby);

            // Расстояние до отрезка равно дважды площади треугольника ABP, делённой на длину AB
            return area / lengthAB;
        }
    }
}
