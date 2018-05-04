using System;
using System.Collections.Generic;

namespace StarterBot.Helpers
{
    public static class KeyValuepairHelpers
    {
        public static Tuple<K, V> ToTuple<K, V>(this KeyValuePair<K, V> keyValuePair)
        {
            return new Tuple<K, V>(keyValuePair.Key, keyValuePair.Value);
        }
    }
}
