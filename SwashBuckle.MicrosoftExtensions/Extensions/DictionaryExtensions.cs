using System.Collections.Generic;

namespace SwashBuckle.MicrosoftExtensions.Extensions
{
    internal static class DictionaryExtensions
    {
        internal static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IEnumerable<KeyValuePair<TKey, TValue>> values)
        {
            foreach (var value in values)
            {
                if(!dictionary.ContainsKey(value.Key))
                    dictionary.Add(value.Key, value.Value);
            }
        }
        
    }
}