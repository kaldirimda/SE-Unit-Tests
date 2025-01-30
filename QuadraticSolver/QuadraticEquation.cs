using System;

namespace QuadraticEquationSolver
{
    public static class QuadraticEquation
    {
        public static (double? root1, double? root2) Solve(double a, double b, double c)
        {
            if (a == 0)
                throw new ArgumentException("Coefficient 'a' cannot be zero.");

            double discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
                return (null, null);
            else if (discriminant == 0)
            {
                double root = -b / (2 * a);
                return (root, null);
            }
            else
            {
                double sqrtDiscriminant = Math.Sqrt(discriminant);
                double root1 = (-b - sqrtDiscriminant) / (2 * a);
                double root2 = (-b + sqrtDiscriminant) / (2 * a);
                return (root1, root2);
            }
        }
    }
}