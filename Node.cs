using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_2.Autobusai
{
    /// <summary>
    /// Node class
    /// </summary>
    /// <typeparam name="Type">type</typeparam>
    internal sealed class Node<Type>
    {
        /// <summary>
        /// Object data
        /// </summary>
        public Type Data { get; set; }

        /// <summary>
        /// Next object data
        /// </summary>
        public Node<Type> Next { get; set; }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public Node() 
        {
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="data">Class object</param>
        /// <param name="adress">Node class object</param>
        public Node(Type data, Node<Type> adress) 
        {
            this.Data = data;
            this.Next = adress;
        }
    }
}
