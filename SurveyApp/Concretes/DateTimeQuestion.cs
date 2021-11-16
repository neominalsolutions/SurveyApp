using SurveyApp.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Concretes
{
    public class DateTimeQuestion : Question<DateTime>
    {
        public DateTime Answer { get; private set; }

        public DateTimeQuestion(string text) : base(text)
        {
           
        }
        public override void AnswerToQuestion(DateTime answer)
        {
            if(answer == default)
            {
                throw new Exception("Tarih seçimi yapınız");
            }

            this.Answer = answer;
        }
    }
}
