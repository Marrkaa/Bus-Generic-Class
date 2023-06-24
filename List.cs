using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace L5_2.Autobusai
{
    /// <summary>
    /// General class
    /// </summary>
    /// <typeparam name="Type">type</typeparam>
    internal sealed class List<Type> : IEnumerable
    {
        Node<Type> start;
        Node<Type> d;
        Node<Type> end;

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public List() 
        {
            this.start = null;
            this.d = null;
            this.end = null;
        }

        /// <summary>
        /// Reference is assigned as list start
        /// </summary>
        public void Start() 
        {
            d = start;
        }

        /// <summary>
        /// Reference is assigned with the next list element
        /// </summary>
        public void Next() 
        {
            d = d.Next;
        }

        /// <summary>
        /// Checks if reference exists
        /// </summary>
        /// <returns>true or false</returns>
        public bool Exists() 
        {
            return d != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Type GetData() 
        {
            return d.Data;
        }

        /// <summary>
        /// Creates a new list element and adds it to the front of the list
        /// </summary>
        /// <param name="inf">new element value</param>
        public void SetDataBackwards(Type inf) 
        {
            start = new Node<Type>(inf, start);
        }

        /// <summary>
        /// Creates a new list element and adds it to the end of the list
        /// </summary>
        /// <param name="inf">new element value</param>
        public void SetDataForwards(Type inf)
        {
            Node<Type> d = new Node<Type>(inf, null);

            if (start != null)
            {
                end.Next = d;
                end = d;
            }
            else
            {
                start = d;
                end = d;
            }
        }

        /// <summary>
        /// IEnumerator method
        /// </summary>
        /// <returns>enumerator</returns>
        public IEnumerator GetEnumerator()
        {
            for (Node<Type> d = start; d != null; d = d.Next)
            {
                yield return d.Data;
            }
        }
    }
}
