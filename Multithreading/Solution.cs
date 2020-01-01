public class Solution
{
    public double FindMedianSortedArrays(int[] num1, int[] num2)
    {
        int ps, pb, ms, mb, median, l, u;
        int[] smaller; int[] bigger;

        var size = num1.Length + num2.Length;

        if (num1.Length == 1 && num2.Length == 1)
        {
            return (((double)num1[0] + (double)num2[0]) / 2);
        }
        else if (num1.Length < num2.Length)
        {
            smaller = num1;
            bigger = num2;
            ps = num1.Length;
            pb = num2.Length;
        }
        else
        {
            smaller = num2;
            bigger = num1;
            ps = num2.Length;
            pb = num1.Length;
        }

        median = ps + (pb + 1 - ps) / 2;
        l = 0;
        u = ps - 1;
        ms = l + (u - l) / 2;
        mb = median - ms - 2;

        while (l < ps && u >= 0)
        {
            if ((ms + 1 == ps && smaller[ms] < bigger[mb + 1])
            || smaller[ms] <= bigger[mb + 1] && bigger[mb] <= smaller[ms + 1])
            {
                return GetMedian(ms, mb, smaller, bigger, size);
            }
            else if (smaller[ms] > bigger[mb + 1])
            {
                u = ms - 1;
            }
            else if (bigger[mb] > smaller[ms + 1])
            {
                l = ms + 1;
            }

            ms = l + (u - l) / 2;
            mb = median - ms - 2;
        }

        double medianfinal = 0.0;

        if (u < 0)
        {
            ms = -1; mb = median - ms - 2;
            var median1 = bigger[mb];

            if (size % 2 == 1)
            {
                return median1;
            }

            double median2 = 0.0;

            median2 = (mb + 1) < pb && (ms + 1) < ps ? (bigger[mb + 1] < smaller[ms + 1] ? bigger[mb + 1] : smaller[ms + 1]) : ((mb + 1) == pb ? smaller[ms + 1] : bigger[mb + 1]);

            medianfinal = ((double)median1 + (double)median2) / 2;

        }

        return medianfinal;
    }

    public double GetMedian(int ms, int mb, int[] smaller, int[] bigger, int size)
    {

        var median1 = (mb >= 0) ? bigger[mb] > smaller[ms] ? bigger[mb] : smaller[ms] : smaller[ms];

        if (size % 2 == 1)
        {
            return median1;
        }

        double median2 = 0.0;

        if (ms + 1 == smaller.Length)
        {
            median2 = bigger[mb + 1];
        }
        else
        {
            median2 = bigger[mb + 1] < smaller[ms + 1] ? bigger[mb + 1] : smaller[ms + 1];
        }

        double finalmedium = ((double)median1 + (double)median2) / 2;

        return finalmedium;
    }
}