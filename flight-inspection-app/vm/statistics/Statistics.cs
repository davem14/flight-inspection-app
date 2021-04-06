using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flight_inspection_app.vm.statistics
{
    class Statistics
    {
        // returns the average of X
        public static double avg(List<float> x, int size)
        {
            // sum is the sum of x's
            float sum = 0;
            // the sigma
            for (int i = 0; i < size; i++)
            {
                sum += x[i];
            }

            return sum / size;
        }

        // returns the variance of X and Y
        public static double var(List<float> x, int size)
        {
            // the E(X)
            double e = avg(x, size);

            double sum = 0;
            // the sigma for: VAR(X)
            for (int i = 0; i < size; i++)
            {
                sum = sum + Math.Pow(x[i], 2);
            }
            // divides 'sum' by 'size'
            sum = sum / size;

            // return: sigma - (expected_value^2)

            return sum - Math.Pow(e, 2);
        }

        // returns the covariance of X and Y
        public static double cov(List<float> x, List<float> y, int size)
        {
            // the E(X)
            double eX = avg(x, size);
            // the E(Y)
            double eY = avg(y, size);

            double sum = 0;
            // the sigma for: COV(X,Y) = E((X-E(X))(Y-E(Y)))
            for (int i = 0; i < size; i++)
            {
                sum = sum + (x[i] - eX) * (y[i] - eY);
            }

            // return: COV(X,Y)
            return sum / size;
        }


        // returns the Pearson correlation coefficient of X and Y
        public static float pearson(List<float> x, List<float> y, int size)
        {
            // the COV(Y)
            double covariance = cov(x, y, size);

            // the VAR(X) and VAR(Y)
            double sqrtVarianceX = Math.Sqrt(var(x, size));
            //float yyy =
            double sqrtVarianceY = Math.Sqrt(var(y, size));

            return (float)(covariance / (sqrtVarianceX * sqrtVarianceY));
        }

        // performs a linear regression and returns the line equation
        public static Line linear_reg(List<Point> points, int size)
        {
            // arrays for x and y
            List<float> x = new List<float>();
            List<float> y = new List<float>();

            for (int i = 0; i < size; i++)
            {
                x.Add(points[i].x);
                y.Add(points[i].y);
            }

            double covariance = cov(x, y, size);
            double variance = var(x, size);

            double a = covariance / variance;
            double x_average = avg(x, size);
            double y_average = avg(y, size);
            double b = y_average - (a * x_average);

            return new Line((float)a, (float)b);
        }

        // returns the deviation between point p and the line equation of the points
        public static float dev(Point p, List<Point> points, int size)
        {
            Line line = linear_reg(points, size);
            float f_x = line.f(p.x);

            if (p.y > f_x)
            {
                return p.y - f_x;
            }
            else
            {
                return f_x - p.y;
            }
        }

        // returns the deviation between point p and the line
        public static float dev(Point p, Line l)
        {
            float f_x = l.f(p.x);

            if (p.y > f_x)
            {
                return p.y - f_x;
            }
            else
            {
                return f_x - p.y;
            }
        }
    }

    public class Line
    {
        float a, b;
        public Line()
        {
            this.a = 0;
            this.b = 0;
        }
        public Line(float a, float b)
        {
            this.a = a;
            this.b = b;
        }
        public float f(float x)
        {
            return a * x + b;
        }

        public float A
        {
            get { return a; }
        }

        public float B
        {
            get { return b; }
        }
    }

    public class Point
    {
        public float x, y;
        public Point(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
