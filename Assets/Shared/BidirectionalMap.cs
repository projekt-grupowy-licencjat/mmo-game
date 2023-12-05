using System.Collections.Generic;

namespace Shared
{
    public class BidirectionalMap<TKey, TValue>
    {
        private Dictionary<TKey, TValue> forward = new Dictionary<TKey, TValue>();
        private Dictionary<TValue, TKey> reverse = new Dictionary<TValue, TKey>();

        public void Add(TKey key, TValue value)
        {
            forward.Add(key, value);
            reverse.Add(value, key);
        }

        public bool RemoveByFirst(TKey key)
        {
            if (forward.TryGetValue(key, out var second))
            {
                forward.Remove(key);
                reverse.Remove(second);
                return true;
            }

            return false;
        }

        public bool RemoveBySecond(TValue value)
        {
            if (reverse.TryGetValue(value, out var first))
            {
                reverse.Remove(value);
                forward.Remove(first);
                return true;
            }

            return false;
        }
        
        public bool TryGetByFirst(TKey key, out TValue value)
        {
            return forward.TryGetValue(key, out value);
        }

        public bool TryGetBySecond(TValue value, out TKey key)
        {
            return reverse.TryGetValue(value, out key);
        }
    }
}