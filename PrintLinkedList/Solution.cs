using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace PrintLinkedList
{
    class Solution
    {

        // Complete the printLinkedList function below.
        public static void printLinkedList(SinglyLinkedListNode head)
        {
            var current = head;
            do{
                Console.WriteLine(current.data);
                current = current.next;
            }while(current != null && current != head);
        }

        static void Main(string[] args)
        {
            int llistCount = Convert.ToInt32(Console.ReadLine());
            var lines = new List<string>();
            for (int i = 0; i < llistCount; i++)
                lines.Add(Console.ReadLine());

            var llist = ConvertToLinkedList(lines);

            printLinkedList(llist.head);
        }

        public static SinglyLinkedList ConvertToLinkedList(IEnumerable<string> input)
        {
            var lines = input.ToList();
            SinglyLinkedList llist = new SinglyLinkedList();

            for (int i = 0; i < lines.Count; i++)
            {
                int llistItem = Convert.ToInt32(lines[i]);
                llist.InsertNode(llistItem);
            }

            return llist;
        }
    }
}