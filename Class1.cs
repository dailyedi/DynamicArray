using System.Collections;

namespace DynamicArray
{
    public class DynamicArray
    {

    }

    public class DynamicArrayItem
    {

    }

    public class DynamicArrayField
    {

    }

    public class DynamicArrayValue
    {

    }

    public class DynamicArraySubValue
    {

    }

    public class DynamicArrayText
    {

    }

    public class DynamicArraySubTextL1<T> where T : IList<string>
    {
        private T _l1Items;

        public T L1Items
        {
            get => _l1Items;
            set
            {
                _l1Items = value;
                L2Items = value.Select(l1 => new DynamicArraySubTextL2<T>(l1)).ToList();
            }
        }

        private List<DynamicArraySubTextL2<T>> L2Items;


        public DynamicArraySubTextL1(string L1) => L1Items = (T)(IList<string>)(typeof(T).IsArray ?
            L1.Split(CONSTANTS.L1Separator).ToArray() :
            L1.Split(CONSTANTS.L1Separator).ToList());
        public DynamicArraySubTextL1(T L1Items) => this.L1Items = L1Items;

        public string GetSubTextL1(int i) => this[i];
        public string GetSubTextL2(int i, int j) => this[i, j];
        public string GetSubTextL3(int i, int j, int k) => this[i, j, k];
        public char GetSubTextL3Char(int i, int j, int k, int l) => this[i, j, k, l];

        public string this[int i] => L1Items[i];
        public string this[int i1, int i2] => L2Items[i1][i2];
        public string this[int i1, int i2, int i3] => L2Items[i1][i2, i3];
        public char this[int i1, int i2, int i3, int i4] => L2Items[i1][i2, i3, i4];
        public override string ToString() => string.Join(CONSTANTS.L1Separator, L1Items);
    }

    public class DynamicArraySubTextL2<T> where T : IList<string>
    {
        private T _l2Items;

        public T L2Items
        {
            get => _l2Items;
            set
            {
                _l2Items = value;
                L3Items = value.Select(l2 => new DynamicArraySubTextL3<T>(l2)).ToList();
            }
        }

        private List<DynamicArraySubTextL3<T>> L3Items;

        public DynamicArraySubTextL2(string L2) => L2Items = (T)(IList<string>)(typeof(T).IsArray ?
            L2.Split(CONSTANTS.L2Separator).ToArray() :
            L2.Split(CONSTANTS.L2Separator).ToList());
        public DynamicArraySubTextL2(T L2Items) => this.L2Items = L2Items;

        public string GetSubTextL2(int i) => this[i];
        public string GetSubTextL3(int i, int j) => this[i, j];
        public char GetSubTextL3Char(int i, int j, int k) => this[i, j, k];

        public string this[int i] => L2Items[i];

        public string this[int i1, int i2] => L3Items[i1][i2];

        public char this[int i1, int i2, int i3] => L3Items[i1][i2, i3];

        public override string ToString() => string.Join(CONSTANTS.L2Separator, L2Items);
    }

    public class DynamicArraySubTextL3<T> where T : IList<string>
    {
        public T L3Items;

        public DynamicArraySubTextL3(string L3) => L3Items = (T)(IList<string>)(typeof(T).IsArray ?
            L3.Split(CONSTANTS.L3Separator).ToArray() :
            L3.Split(CONSTANTS.L3Separator).ToList());

        public DynamicArraySubTextL3(T L3Items) => this.L3Items = L3Items;

        public string GetSubTextL3(int i) => this[i];

        public char GetSubTextL3Char(int i, int j) => this[i][j];

        public string this[int i] => L3Items[i];

        public char this[int i1, int i2] => this[i1][i2];

        public override string ToString() => string.Join(CONSTANTS.L3Separator, L3Items);
    }

    public static class CONSTANTS
    {
        public static readonly char ItemSeparator = Convert.ToChar(255);
        public static readonly char FieldSeparator = Convert.ToChar(254);
        public static readonly char ValueSeparator = Convert.ToChar(253);
        public static readonly char SubValueSeparator = Convert.ToChar(252);
        public static readonly char TextSeparator = Convert.ToChar(251);
        public static readonly char L1Separator = Convert.ToChar(250);
        public static readonly char L2Separator = Convert.ToChar(249);
        public static readonly char L3Separator = Convert.ToChar(248);
    }
}