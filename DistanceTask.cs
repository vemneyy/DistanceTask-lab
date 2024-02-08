using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            // Вычисляем вектора AB и AP
            double abx = bx - ax; // Координаты вектора AB по оси x
            double aby = by - ay; // Координаты вектора AB по оси y
            double apx = x - ax; // Координаты вектора AP по оси x
            double apy = y - ay; // Координаты вектора AP по оси y

            // Скалярное произведение векторов AB и AP
            double abDotAp = abx * apx + aby * apy;

            // Если скалярное произведение меньше нуля, то проекция точки на отрезок лежит за точкой A
            if (abDotAp <= 0)
                return Math.Sqrt(apx * apx + apy * apy); // Расстояние от точки до точки A

            // Скалярное произведение векторов BA и BP
            double bax = ax - bx; // Координаты вектора BA по оси x
            double bay = ay - by; // Координаты вектора BA по оси y
            double bpx = x - bx; // Координаты вектора BP по оси x
            double bpy = y - by; // Координаты вектора BP по оси y
            double baDotBp = bax * bpx + bay * bpy;

            // Если скалярное произведение меньше нуля, то проекция точки на отрезок лежит за точкой B
            if (baDotBp <= 0)
                return Math.Sqrt(bpx * bpx + bpy * bpy); // Расстояние от точки до точки B

            // Вычисляем площадь треугольника ABP
            double area = Math.Abs(abx * bpy - aby * bpx);

            // Длина отрезка AB
            double lengthAB = Math.Sqrt(abx * abx + aby * aby);

            // Расстояние до отрезка равно дважды площади треугольника ABP, делённой на длину AB
            return area / lengthAB; // Возвращаем расстояние до отрезка
        }
    }
}
