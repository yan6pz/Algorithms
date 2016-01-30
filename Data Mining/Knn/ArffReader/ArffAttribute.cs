namespace ArffSharp
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class ArffAttribute
    {
        public string Name { get; private set; }
        public ReadOnlyCollection<string> NominalValues { get; private set; }

        public ArffAttribute(string name, IList<string> nominalValues)
        {
            this.Name = name;
            this.NominalValues = new ReadOnlyCollection<string>(nominalValues);
        }
    }
}
