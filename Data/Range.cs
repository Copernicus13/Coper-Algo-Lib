#nullable enable
using System;
using System.Collections.Generic;
using System.Numerics;

namespace CoperAlgoLib.Data
{
    public class Range<T> where T : INumber<T>
    {
        private readonly Tuple<T, T> _range;

        public static readonly Range<T> Void = new Range<T>(T.Zero, T.Zero);

        public T Minimum => _range.Item1;

        public T Maximum => _range.Item2;

        public T Count => Maximum - Minimum + T.One;

        public Range(T min, T length)
        {
            _range = new Tuple<T, T>(min, min + length - T.One);
        }

        public Range((T Min, T Max) bounds)
        {
            _range = new Tuple<T, T>(bounds.Min, bounds.Max);
        }

        public bool ContainsValue(T value) =>
            Comparer<T>.Default.Compare(Minimum, value) <= 0 &&
                Comparer<T>.Default.Compare(value, Maximum) <= 0;

        public bool IsInsideRange(Range<T> range) =>
            range.ContainsValue(Minimum) && range.ContainsValue(Maximum);

        public bool ContainsRange(Range<T> range) =>
            ContainsValue(range.Minimum) && ContainsValue(range.Maximum);

        public bool IsOverlapping(Range<T> range) =>
            ContainsValue(range.Minimum) || ContainsValue(range.Maximum) ||
            range.ContainsValue(Minimum) || range.ContainsValue(Maximum);

        public Range<T> Union(Range<T> range)
        {
            if (!IsOverlapping(range))
                return Void;
            if (IsInsideRange(range))
                return range;
            if (ContainsRange(range))
                return this;
            return new Range<T>(
                Comparer<T>.Default.Compare(Minimum, range.Minimum) < 0 ?
                    Minimum : range.Minimum,
                Comparer<T>.Default.Compare(Maximum, range.Maximum) > 0 ?
                    Maximum : range.Maximum);
        }

        public Range<T> Intersect(Range<T> range)
        {
            if (!IsOverlapping(range))
                return Void;
            if (IsInsideRange(range))
                return this;
            if (ContainsRange(range))
                return range;
            return new Range<T>(
                Comparer<T>.Default.Compare(Minimum, range.Minimum) < 0 ?
                    range.Minimum : Minimum,
                Comparer<T>.Default.Compare(Maximum, range.Maximum) > 0 ?
                    range.Maximum : Maximum);
        }
    }
}
