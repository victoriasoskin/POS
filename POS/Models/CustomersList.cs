using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class CustomersList : IEnumerable, IEnumerator
    {
        public List<Customer> CustList {get;set;}

        public Customer[] _customerList;
        int position = -1;
        public void AddToAnswersList(List<Customer> c)
        {
            int i = 0;
            int count = c.Count;
            _customerList = new Customer[count];
            foreach (var ques in c)
            {
                _customerList[i] = ques;
                i++;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        //IEnumerator
        public bool MoveNext()
        {
            position++;
            return (position < _customerList.Length);
        }

        //IEnumerable
        public void Reset()
        { position = 0; }

        //IEnumerable
        public object Current
        {
            get { return _customerList[position]; }
        }
    }
}