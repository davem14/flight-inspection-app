using flight_inspection_app.vm.statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flight_inspection_app.vm.correlation_classes
{
    class Correlation
    {
        public static Dictionary<int, CorrelationDetails> findCorrelations(List<string> chunksNames, Dictionary<int, List<float>> map)
        {
            Dictionary<int, CorrelationDetails> correlations = new Dictionary<int, CorrelationDetails>();

            int numOfCategory = chunksNames.Count;

            for (int i = 0; i < numOfCategory; i++)
            {
                correlations.Add(i, new CorrelationDetails());
                correlations[i].CorrelationValue = Single.NaN;
            }

            for (int i = 0; i < numOfCategory; i++)
            {
                for (int j = 1; j < numOfCategory; j++)
                {
                    if (i != j)
                    {
                        int numberOfRow = map[i].Count;
                        float correlation = Statistics.pearson(map[i], map[j], numberOfRow);
                        List<Point> ps = new List<Point>();
                        if (Single.IsNaN(correlation) && Single.IsNaN(correlations[i].CorrelationValue))
                        {
                            correlations[i].CorrelationValue = Single.NaN;
                            correlations[i].CorrelationWith = -1;
                            correlations[i].Warning = "Warning: There is no correlation with any athor category!";
                        }
                        else
                        {
                            if (Single.IsNaN(correlations[i].CorrelationValue) || Math.Abs(correlation) > correlations[i].CorrelationValue)
                            {
                                for (int k = 0; k < numberOfRow; k++)
                                {
                                    ps.Add(new Point(map[i][k], map[j][k]));
                                }
                                correlations[i].CorrelationValue = Math.Abs(correlation);
                                correlations[i].CorrelationWith = j;
                                correlations[i].Points = ps;
                                correlations[i].RegressionLine = Statistics.linear_reg(ps, ps.Count);
                                if (Math.Abs(correlation) < 0.9)
                                {
                                    correlations[i].Warning = "Warning: The correlation is " + correlation.ToString() + ", this is a low correlation";
                                }
                                else
                                {
                                    correlations[i].Warning = "The correlation is " + correlation.ToString();
                                }
                            }
                        }
                    }
                }
            }
            return correlations;
        }
    }

    public class CorrelationDetails
    {
        float correlationValue = -1;
        public float CorrelationValue
        {
            get { return correlationValue; }
            set { correlationValue = value; }
        }

        int correlationWith;
        public int CorrelationWith
        {
            get { return correlationWith; }
            set { correlationWith = value; }
        }

        List<Point> points;
        public List<Point> Points
        {
            get { return points; }
            set { points = value; }
        }

        string warning;
        public string Warning
        {
            get { return warning; }
            set { warning = value; }
        }

        Line regressionLine;
        public Line RegressionLine
        {
            get { return regressionLine; }
            set { regressionLine = value; }
        }

        IList<Func<double, double>> normalArea = new List<Func<double, double>>();
        public IList<Func<double, double>> NormalArea
        {
            get { return normalArea; }
            set { normalArea = value; }
        }
    }
}
