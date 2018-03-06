using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CommandLine.Readers
{
    public interface IReader
    {
        bool Handles(Type propertyType);

        void AssignProperty<TTarget>(ArgumentEnumerator enumerator, TTarget target, Dictionary<string, PropertyDescriptor> properties, PropertyDescriptor property, string argument);
    }

    public abstract class Reader<T> : IReader
    {
        public bool Handles(Type propertyType) => typeof(T) == propertyType;

        public abstract void AssignProperty<TTarget>(ArgumentEnumerator enumerator, TTarget target, Dictionary<string, PropertyDescriptor> properties, PropertyDescriptor property, string argument);

        protected void RaiseError(string error, params string[] values)
        {
            throw new CommandLineParserException(string.Format(error, values));
        }

        protected string CleanArgument(string arg)
        {
            if (arg == null)
                return null;

            if (arg.StartsWith("--"))
                arg = arg.Substring(2);
            else if (arg.StartsWith("-"))
                arg = arg.Substring(1);
            else if (arg.StartsWith("/"))
                arg = arg.Substring(1);

            return arg;
        }
    }
}