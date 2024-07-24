using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CodingChallenges.DataStructures;
internal class MyLinkedList<T>
{
    private MyNode<T> _head = null; 
    private MyNode<T> _tail = null;

    public MyLinkedList(List<T> types)
    {
        foreach (T type in types)
        {
            AddAtTail(type);
        }
    }

    public void AddAtTail(T value)
    {
        MyNode<T> newNode = new(value);
        if (_head == null)
        {
            _head = _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            _tail = newNode;
        }
    }
}
