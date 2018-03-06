using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CommandLine
{
    public class PropertyCollection<T>
    {
        private readonly string[] _args;

        public PropertyCollection(string[] args)
        {
            _args = args;
        }

        private Dictionary<string, PropertyDescriptor> GetProperties()
        {
            var properties = TypeDescriptor.GetProperties(typeof(T));
            var dictionary = new Dictionary<string, PropertyDescriptor>(properties.Count, StringComparer.InvariantCultureIgnoreCase);

            foreach (PropertyDescriptor property in properties)
                dictionary[property.Name] = property;

            return dictionary;
        }

        public string[] Extras { get; private set; }
    }
}