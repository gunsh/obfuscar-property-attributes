using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Serialization;

namespace ConsoleApp13
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Write((Derived data) => data.Code);
            Write((Base data) => data.Code);
        }

        private static void Write<T1,T2>(Expression<Func<T1,T2>> expression)
        {
            var me = (MemberExpression) expression.Body;

            Console.WriteLine(me.Expression.Type.GetProperty(me.Member.Name).GetCustomAttribute<XmlElementAttribute>(false).ElementName);
        }
    }

    public abstract class Base
    {
        [XmlElement("Base")]
        public abstract string Code { get; set; }
    }

    public class Derived : Base
    {
        [XmlElement("Derived")]
        public override string Code { get; set; }
    }
}
