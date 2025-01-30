using Xunit;
using System;
using QuadraticEquationSolver;

namespace QuadraticEquationSolver.Tests
{
    public class QuadraticEquationTests
    {
        [Theory]
        [InlineData(1, 0, 1, null, null)] // No real roots
        [InlineData(1, -2, 1, 1.0, null)] // One real root
        [InlineData(1, -3, 2, 1.0, 2.0)]  // Two real roots
        public void Solve_ValidCoefficients_ReturnsCorrectRoots(double a, double b, double c, double? expectedRoot1, double? expectedRoot2)
        {
            var (root1, root2) = QuadraticEquation.Solve(a, b, c);
            Assert.Equal(expectedRoot1, root1);
            Assert.Equal(expectedRoot2, root2);
        }

        [Fact]
        public void Solve_AIsZero_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => QuadraticEquation.Solve(0, 1, 1));
        }

        [Theory]
        [InlineData(1, 0, 1)]
        [InlineData(1, -2, 1)]
        [InlineData(1, -3, 2)]
        public void Solve_RootsSatisfyEquation(double a, double b, double c)
        {
            var (root1, root2) = QuadraticEquation.Solve(a, b, c);

            if (root1.HasValue)
                Assert.InRange(a * root1.Value * root1.Value + b * root1.Value + c, -1e-9, 1e-9);

            if (root2.HasValue)
                Assert.InRange(a * root2.Value * root2.Value + b * root2.Value + c, -1e-9, 1e-9);
        }
    }
}