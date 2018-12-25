using System;

namespace SomeNamespace
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)] //  Inherited = false, не наследуется в классах наследниках. AttributeTargets.All - может применяться ко всем членам класса и к самому типу 
    internal class AuthorAttribute : Attribute
    {
        public string V { get; internal set; }
        

        public AuthorAttribute(string v)
        {
            this.V = v;
        }

        
    }
}