using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CodingChallenges.DataStructures;
public class TreeNode<T>(T value, TreeNode<T>? left = null, TreeNode<T>? right = null)
{
    public T val = value;
    public TreeNode<T>? left = left;
    public TreeNode<T>? right = right;
}
