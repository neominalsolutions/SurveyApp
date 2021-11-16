using SurveyApp.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Concretes
{
    public class RadioButtonQuestion : Question<Option>, IQuestionWithOptions

    {
        /// <summary>
        /// Seçeneklerden sadece 1 tanesi doğru olabilir
        /// </summary>
        public Option Answer { get; private set; }

        /// <summary>
        /// Birden fazla seçenek ile çalışabilir. En fazla 4 seçenek girilebilir.
        /// </summary>
        public List<Option> options = new List<Option>();
        public IReadOnlyList<Option> Options
        {
            get
            {
                return options;
            }
        }

        public RadioButtonQuestion(string text) : base(text)
        {

        }

        public override void AnswerToQuestion(Option answer)
        {
            // cevap verebilmek için options adeti en az 4 olmalıdır
            if (options.Count < 4)
            {
                throw new Exception("Cevap verebilmek için en az 4 adet seçenek olmalıdır.");
            }

            // cevap seçeneklerin içerisinde varsa girilebilir.
            if (options.Any(x => x.Name == answer.Name))
            {
                Answer = answer;
            }
            else
            {
                throw new Exception("Olmayan bir seçeneğe cevap verilemez!");
            }
        }

        /// <summary>
        /// En fazla 4 adet option girebiliriz.
        /// </summary>
        /// <param name="option"></param>
        public void AddOption(Option option)
        {

            if (options.Count >= 4)
            {
                throw new Exception("En fazla 4 adet seçenek girmelisiniz");
            }

            if(options.Any(x=> x.Name == option.Name))
            {
                throw new Exception("Aynı seçenek tekrar girilemez");
            }

            options.Add(option);

        }

    }

       
}
