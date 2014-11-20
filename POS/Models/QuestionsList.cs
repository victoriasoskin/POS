using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace POS.Models
{
    public class QuestionsList:IEnumerable,IEnumerator
    {
        public POS_Question[] _questionList;
        int position = -1;
        public void  AddQuestionsList(List<POS_Question> q)
        {
           int i = 0;
            _questionList = new POS_Question[25];
            foreach(var ques in q)
            {
                _questionList[i] = ques;
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
            return (position < _questionList.Length);
        }

        //IEnumerable
        public void Reset()
        { position = 0; }

        //IEnumerable
        public object Current
        {
            get { return _questionList[position]; }
        }
        //public List<POS_Questions> ListOfQuestions = new List<POS_Questions>();
       
    }
}