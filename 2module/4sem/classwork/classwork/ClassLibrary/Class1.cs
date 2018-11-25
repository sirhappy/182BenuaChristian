using System;

namespace ClassLibrary
{
    public class A
    {
        public virtual void getA()
        {
            Console.WriteLine("A");
        }
    }

    public class B : A {
        public override void getA()
        {
            Console.WriteLine("B");
        }
    }
}
