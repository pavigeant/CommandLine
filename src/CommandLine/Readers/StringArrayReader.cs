using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CommandLine.Readers
{
    public class StringArrayReader : Reader<string[]>
    {
        public override void AssignProperty<TTarget>(ArgumentEnumerator enumerator, TTarget target, Dictionary<string, PropertyDescriptor> properties, PropertyDescriptor property, string argument)
        {
            var followingArguments = new List<string>();
            string name;
            while ((name = CleanArgument(enumerator.Peek())) != null && !properties.ContainsKey(name) && enumerator.MoveNext())
            {
                followingArguments.Add((string)enumerator.Current);
            }

            if (followingArguments.Count > 0)
                property.SetValue(target, followingArguments.ToArray());
            else
                RaiseError(Errors.MissingArgumentAfter, argument); // error because there are no more arguments
        }
    }
}