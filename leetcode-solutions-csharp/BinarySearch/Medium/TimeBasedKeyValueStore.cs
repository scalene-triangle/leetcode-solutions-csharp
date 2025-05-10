namespace leetcode_solutions_csharp.BinarySearch.Medium;

public class TimeBasedKeyValueStore
{
    /*
	* 981. Time Based Key-Value Store
	* Design a time-based key-value data structure that can store multiple values for the same key at different time stamps and retrieve the key's value at a certain timestamp.
        Implement the TimeMap class:

        - TimeMap() Initializes the object of the data structure.
        - void set(String key, String value, int timestamp) Stores the key key with the value value at the given time timestamp.
        - String get(String key, int timestamp) Returns a value such that set was called previously, with timestamp_prev <= timestamp. If there are multiple such values, it returns the value associated with the largest timestamp_prev. If there are no values, it returns "".
	*/

    public void Run()
    {
        TimeMap timeMap = new TimeMap();
        timeMap.Set("foo", "bar", 1);
        Console.WriteLine(timeMap.Get("foo", 1)); // return "bar"
        Console.WriteLine(timeMap.Get("foo", 3)); // return "bar"
        timeMap.Set("foo", "bar2", 4);
        Console.WriteLine(timeMap.Get("foo", 4)); // return "bar2"
        Console.WriteLine(timeMap.Get("foo", 5)); // return "bar2"
    }
    public class TimeMap
    {
        const int BucketSize = 100;

        private Dictionary<string, List<(int, string[])>> key2Values;

        private MyComparer comparer = new MyComparer();

        public TimeMap()
        {
            this.key2Values = new Dictionary<string, List<(int, string[])>>();
        }

        public void Set(string key, string value, int timestamp)
        {
            int bucketId = timestamp / BucketSize;
            int index = timestamp % BucketSize;
            if (!this.key2Values.TryGetValue(key, out List<(int, string[])> buckets))
            {
                buckets = new List<(int, string[])>();
                this.key2Values.Add(key, buckets);
            }

            string[] values = null;
            var pos = buckets.BinarySearch((bucketId, null), this.comparer);
            if (pos < 0)
            {
                pos = ~pos;
                values = new string[BucketSize];
                values[index] = value;
                buckets.Insert(pos, (bucketId, values));
            }
            else
            {
                values = buckets[pos].Item2;
                values[index] = value;
            }
        }

        public string Get(string key, int timestamp)
        {
            if (!this.key2Values.TryGetValue(key, out List<(int, string[])> buckets))
            {
                return string.Empty;
            }

            int bucketId = timestamp / BucketSize;
            int index = timestamp % BucketSize;
            var pos = buckets.BinarySearch((bucketId, null), this.comparer);
            if (pos < 0)
            {
                if (bucketId == 0)
                    return string.Empty;

                pos = ~pos;
                return buckets[pos - 1].Item2.Last(val => !string.IsNullOrEmpty(val));
            }
            else
            {
                var values = buckets[pos].Item2;
                for (int i = index; i >= 0; --i)
                {
                    if (values[i] != null)
                        return values[i];
                }

                return string.Empty;
            }
        }
    }

    public class MyComparer : IComparer<(int, string[])>
    {
        public int Compare((int, string[]) x, (int, string[]) y)
        {
            return x.Item1 - y.Item1;
        }
    }
}
