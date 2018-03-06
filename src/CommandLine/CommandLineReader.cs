using CommandLine.Readers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CommandLine
{
    public class CommandLineReader
    {
        private readonly IList<IReader> _readers;

        public CommandLineReader()
        {
            _readers = LoadReaders();
        }

        public static T Parse<T>(string[] args)
            where T : new()
        {
            var reader = CreateReader();
            return reader.Read<T>(args);
        }

        private static CommandLineReader CreateReader() =>
            new CommandLineReader();

        private IList<IReader> LoadReaders() =>
            new List<IReader>() { new BooleanReader(), new StringReader(), new StringArrayReader() };

        public T Read<T>(string[] args)
            where T : new()
        {
            var target = new T();
            var properties = GetProperties<T>();
            AssignArguments(target, properties, args);

            // For each public property in the type T, use the property name as a delimiter
            var enumerator = new ArgumentEnumerator(args);
            while (enumerator.MoveNext())
            {
                var argument = (string)enumerator.Current;
                var name = CleanArgument(argument);
                if (properties.TryGetValue(name, out PropertyDescriptor property) &&
                    TryGetReader(property, out IReader reader))
                {
                    reader.AssignProperty(enumerator, target, properties, property, argument);
                }
            }

            return target;
        }

        private bool TryGetReader(PropertyDescriptor property, out IReader reader)
        {
            reader = _readers.FirstOrDefault(r => r.Handles(property.PropertyType));
            return reader != null;
        }

        private void AssignArguments<T>(T target, Dictionary<string, PropertyDescriptor> properties, string[] args)
        {
            // if one of the properties is called Arguments or Args and is an array of string, assign args to it
            if (properties.TryGetValue("Arguments", out PropertyDescriptor property) ||
                properties.TryGetValue("Args", out property))
            {
                property.SetValue(target, args);
            }
        }

        private string CleanArgument(string arg)
        {
            if (arg.StartsWith("--"))
                arg = arg.Substring(2);
            else if (arg.StartsWith("-"))
                arg = arg.Substring(1);
            else if (arg.StartsWith("/"))
                arg = arg.Substring(1);

            return arg;
        }

        private Dictionary<string, PropertyDescriptor> GetProperties<T>()
        {
            var properties = TypeDescriptor.GetProperties(typeof(T));
            var dictionary = new Dictionary<string, PropertyDescriptor>(properties.Count, StringComparer.InvariantCultureIgnoreCase);

            foreach (PropertyDescriptor property in properties)
                dictionary[property.Name] = property;

            return dictionary;
        }
    }
}