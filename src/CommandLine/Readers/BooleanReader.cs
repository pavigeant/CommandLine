using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CommandLine.Readers
{
    public class BooleanReader : Reader<bool>
    {
        public override void AssignProperty<TTarget>(ArgumentEnumerator enumerator, TTarget target, Dictionary<string, PropertyDescriptor> properties, PropertyDescriptor property, string argument)
        {
            property.SetValue(target, true);
        }
    }
}