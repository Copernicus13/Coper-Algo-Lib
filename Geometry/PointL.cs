//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a T4 template.
//
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

namespace CoperAlgoLib.Geometry
{
    public struct PointL : IEquatable<PointL>
    {
        public long X;
        public long Y;

        public PointL(long x, long y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj) => obj is PointL other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(X, Y);

        public bool Equals(PointL other) => X == other.X && Y == other.Y;

        public static bool operator ==(PointL lhs, PointL rhs) => lhs.Equals(rhs);

        public static bool operator !=(PointL lhs, PointL rhs) => !lhs.Equals(rhs);
    }
}
