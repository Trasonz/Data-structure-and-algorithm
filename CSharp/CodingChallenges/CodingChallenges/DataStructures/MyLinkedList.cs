using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CodingChallenges.DataStructures;

public class MyLinkedList<T>
{
    public MyNode<T>? Head;
    public MyNode<T>? Tail;

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

        if (Head == null)
        {
            Head = Tail = newNode;
        }
        else
        {
            Tail!.Next = newNode;
            Tail = newNode;
        }
    }
}
