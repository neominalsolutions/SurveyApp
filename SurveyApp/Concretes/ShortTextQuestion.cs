using SurveyApp.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Concretes
{
    public class ShortTextQuestion : Question<string>
    {
        /// <summary>
        /// Bu soru tipinin cevabını bulduk
        /// </summary>
        public string Answer { get; private set; }


        public ShortTextQuestion(string text) : base(text)
        {

        }

        public override void AnswerToQuestion(string answer)
        {
            if(answer.Length > 30)
            {
                throw new Exception("30 karakterden daha fazla bir değer giremezsiniz");
            }

            this.Answer = answer;
        }

    }
}
