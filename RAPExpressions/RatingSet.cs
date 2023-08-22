using System.Collections;

namespace RAPExpressions
{
    public class RatingSet : IList<decimal>
    {
        public RatingSet(params decimal[] values)
        {
            Ratings.AddRange(values);
        }

        protected List<decimal> Ratings { get; set; } = new();

        #region IList

        public decimal this[int index]
        { get => Ratings[index]; set { Ratings[index] = value; } }

        public int Count => Ratings.Count;

        public bool IsReadOnly => false;

        public void Add(decimal item)
        {
            Ratings.Add(item);
        }

        public void Clear()
        {
            Ratings.Clear();
        }

        public bool Contains(decimal item)
        {
            return Ratings.Contains(item);
        }

        public void CopyTo(decimal[] array, int arrayIndex)
        {
            Ratings.CopyTo(array, arrayIndex);
        }

        public IEnumerator<decimal> GetEnumerator()
        {
            return Ratings.GetEnumerator();
        }

        public int IndexOf(decimal item)
        {
            return Ratings.IndexOf(item);
        }

        public void Insert(int index, decimal item)
        {
            Ratings.Insert(index, item);
        }

        public bool Remove(decimal item)
        {
            return Ratings.Remove(item);
        }

        public void RemoveAt(int index)
        {
            Ratings.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Ratings.GetEnumerator();
        }

        #endregion IList

        #region Addition

        public static RatingSet operator +(RatingSet lhs, RatingSet rhs)
        {
            ValidateSets(lhs, rhs);
            return ApplyOp(rhs, lhs, (v1, v2) => v1 + v2);
        }

        public static RatingSet operator +(decimal lhs, RatingSet rhs)
        {
            return ApplyOp(rhs, lhs, (v1, v2) => v1 + v2);
        }

        public static RatingSet operator +(RatingSet lhs, decimal rhs)
        {
            return ApplyOp(lhs, rhs, (v1, v2) => v1 + v2);
        }

        #endregion Addition

        #region Substraction

        public static RatingSet operator -(RatingSet lhs, RatingSet rhs)
        {
            ValidateSets(lhs, rhs);
            return ApplyOp(rhs, lhs, (v1, v2) => v1 - v2);
        }

        public static RatingSet operator -(decimal lhs, RatingSet rhs)
        {
            return ApplyOp(rhs, lhs, (v1, v2) => v1 - v2);
        }

        public static RatingSet operator -(RatingSet lhs, decimal rhs)
        {
            return ApplyOp(lhs, rhs, (v1, v2) => v2 - v1);
        }

        #endregion Substraction

        #region Multiplication

        public static RatingSet operator *(RatingSet lhs, RatingSet rhs)
        {
            ValidateSets(lhs, rhs);
            return ApplyOp(rhs, lhs, (v1, v2) => v1 * v2);
        }

        public static RatingSet operator *(decimal lhs, RatingSet rhs)
        {
            return ApplyOp(rhs, lhs, (v1, v2) => v1 * v2);
        }

        public static RatingSet operator *(RatingSet lhs, decimal rhs)
        {
            return ApplyOp(lhs, rhs, (v1, v2) => v1 * v2);
        }

        #endregion Multiplication

        #region Division

        public static RatingSet operator /(RatingSet lhs, RatingSet rhs)
        {
            ValidateSets(lhs, rhs);
            return ApplyOp(rhs, lhs, (v1, v2) => v1 / v2);
        }

        public static RatingSet operator /(decimal lhs, RatingSet rhs)
        {
            return ApplyOp(rhs, lhs, (v1, v2) => v1 / v2);
        }

        public static RatingSet operator /(RatingSet lhs, decimal rhs)
        {
            return ApplyOp(lhs, rhs, (v1, v2) => v2 / v1);
        }

        #endregion Division

        private static RatingSet ApplyOp(RatingSet set1, RatingSet set2, Func<decimal, decimal, decimal> op)
        {
            RatingSet result = new();
            for (int i = 0; i < set1.Count(); i++)
            {
                result.Add(op(set1[i], set2[i]));
            }
            return result;
        }

        private static RatingSet ApplyOp(RatingSet set, decimal value, Func<decimal, decimal, decimal> op)
        {
            RatingSet result = new();
            for (int i = 0; i < set.Count(); i++)
            {
                result.Add(op(value, set[i]));
            }
            return result;
        }

        private static void ValidateSets(RatingSet lhs, RatingSet rhs)
        {
            if (lhs.Count() != rhs.Count()) throw new InvalidOperationException("Mismatched number of ratings");
        }

        public override string ToString()
        {
            return string.Join(", ", Ratings);
        }
    }
}