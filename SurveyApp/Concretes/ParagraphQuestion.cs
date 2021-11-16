using SurveyApp.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Concretes
{
    public class ParagraphQuestion : Question<string>
    {
        /// <summary>
        /// Bu soru tipinin cevabını bulduk
        /// </summary>
        public string Answer { get; private set; }

        public ParagraphQuestion(string text) : base(text)
        {

        }
        public override void AnswerToQuestion(string answer)
        {
            if (answer.Length > 200)
            {
                throw new Exception("200 karakterden daha fazla bir değer giremezsiniz");
            }

            this.Answer = answer;
        }
    }
}
