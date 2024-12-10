using System;

namespace Geometry
{
    public class Vector
    {
        public double X;
        public double Y;

        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public Vector Add(Vector other)
        {
            return Geometry.Add(this, other);
        }

        public bool Belongs(Segment seg)
        {
            return Geometry.IsVectorInSegment(this, seg);
        }
    }


    public class Segment
    {
        public Vector Begin;
        public Vector End;

        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public bool Contains(Vector vec)
        {
            return Geometry.IsVectorInSegment(vec, this);
        }
    }

    public class Geometry
    {
        public static double GetLength(Vector vec)
        {
            return Math.Sqrt(vec.X * vec.X + vec.Y * vec.Y);
        }

        public static Vector Add(Vector vec1, Vector vec2)
        {
            return new Vector { X = vec1.X + vec2.X, Y = vec1.Y + vec2.Y };
        }

        public static double GetLength(Segment seg)
        {
            double lengthX = seg.End.X - seg.Begin.X;
            double lengthY = seg.End.Y - seg.Begin.Y;
            return Math.Sqrt(lengthX * lengthX + lengthY * lengthY);
        }

        public static bool IsVectorInSegment(Vector vec, Segment seg)
        {
            if (seg.Begin.X == seg.End.X && seg.Begin.Y == seg.End.Y)
            {
                return vec.X == seg.Begin.X && vec.Y == seg.Begin.Y;
            }

            double crossProduct = (vec.Y - seg.Begin.Y) * (seg.End.X - seg.Begin.X) -
                                  (vec.X - seg.Begin.X) * (seg.End.Y - seg.Begin.Y);

            if (Math.Abs(crossProduct) > 1e-10) return false;

            double dotProduct = (vec.X - seg.Begin.X) * (seg.End.X - seg.Begin.X) +
                                (vec.Y - seg.Begin.Y) * (seg.End.Y - seg.Begin.Y);
            if (dotProduct < 0) return false;

            double squaredLengthSegment = GetLength(seg) * GetLength(seg);
            return dotProduct <= squaredLengthSegment;
        }
    }
}