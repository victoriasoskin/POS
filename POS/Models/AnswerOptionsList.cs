using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class AnswerOptionsList
    {
        public POS_AnswerOptions[] _answersList;
        int position = -1;
        public void AddToAnswersList(List<POS_AnswerOptions> q)
        {
            int i = 0;
            _answersList = new POS_AnswerOptions[10];
            foreach (var ques in q)
            {
                _answersList[i] = ques;
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
            return (position < _answersList.Length);
        }

        //IEnumerable
        public void Reset()
        { position = 0; }

        //IEnumerable
        public object Current
        {
            get { return _answersList[position]; }
        }
    }
}