using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CodingChallenges.DataStructures;
internal class MyNode<T>(T value, MyNode<T> next = null)
{
    public T Value = value;
    public MyNode<T> Next = next;
}
