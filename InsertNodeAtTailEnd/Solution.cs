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

namespace InsertNodeAtTailEnd
{
    class Solution
    {

        public static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
        {
            while (node != null)
            {
                textWriter.Write(node.data);

                node = node.next;

                if (node != null)
                {
                    textWriter.Write(sep);
                }
            }
        }

        // Complete the insertNodeAtTail function below.
        static SinglyLinkedListNode insertNodeAtTail(SinglyLinkedListNode head, int data)
        {
            var node = new SinglyLinkedListNode(data);
            if(head == null) return node;

            var current = head;
            while(current?.next != null)
                current = current.next;
                
            current.next = node;
            return head;
        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int llistCount = Convert.ToInt32(Console.ReadLine());
            var input = new List<string>();
            for (int i = 0; i < llistCount; i++)
                input.Add(Console.ReadLine());

            var llist = ConvertToLinkedList(input);

            PrintSinglyLinkedList(llist.head, "\n", textWriter);
            textWriter.WriteLine();

            textWriter.Flush();
            textWriter.Close();
        }

        public static SinglyLinkedList ConvertToLinkedList(IEnumerable<string> input)
        {
            var lines = input.ToList();
            SinglyLinkedList llist = new SinglyLinkedList();

            for (int i = 0; i < lines.Count; i++)
            {
                int llistItem = Convert.ToInt32(lines[i]);
                SinglyLinkedListNode llist_head = insertNodeAtTail(llist.head, llistItem);
                llist.head = llist_head;
            }

            return llist;
        }
    }
}