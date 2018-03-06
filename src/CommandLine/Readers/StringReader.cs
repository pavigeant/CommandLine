using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CommandLine.Readers
{
    public class StringReader : Reader<string>
    {
        public override void AssignProperty<TTarget>(ArgumentEnumerator enumerator, TTarget target, Dictionary<string, PropertyDescriptor> properties, PropertyDescriptor property, string argument)
        {
            string name;
            if ((name = CleanArgument(enumerator.Peek())) != null && !properties.ContainsKey(name) && enumerator.MoveNext())
                property.SetValue(target, (string)enumerator.Current);
            else
                RaiseError(Errors.MissingArgumentAfter, argument); // error because there are no more arguments
        }
    }
}