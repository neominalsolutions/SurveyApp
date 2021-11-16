using SurveyApp.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Concretes
{

    public enum YesNoTypes
    {
        Evet,
        Hayır
    }

    /// <summary>
    /// Bekar mısınız ? Evet yada Hayır
    /// </summary>
    public class YesNoQuestion : Question<Option>, IQuestionWithOptions
    {
        public Option Answer { get; private set; }

        public List<Option> options = new List<Option>();
        public IReadOnlyList<Option> Options
        {
            get
            {
                return options;
            }
        }

        public YesNoQuestion(string text) : base(text)
        {
            var t = new Option(name: "Evet");
            var f = new Option(name: "Hayır");
            AddOption(t);
            AddOption(f);
        }

        /// <summary>
        /// Bu tipteki soruya Yes ve No tipinde Option girilmesini kontrol ettik.
        /// </summary>
        /// <param name="option"></param>
        public void AddOption(Option option)
        {

            OptionCountGreaterThenTwo();
            SameOptionExists(option);


            if (option.Name == YesNoTypes.Evet.ToString() || option.Name == YesNoTypes.Hayır.ToString())
            {
                options.Add(option);
            }
            else
            {
                throw new Exception("Evet yada Hayır tipinde bir seçenek girmelisiniz");
            }
        }

        /// <summary>
        /// Options sayısı 2 den fazla olmamalıdır 
        /// </summary>
        private void OptionCountGreaterThenTwo()
        {
            if (options.Count >= 2)
            {
                throw new Exception("En fazla 2 seçenek girebilirsiniz");
            }
        }

        /// <summary>
        /// Aynı optiondan bir daha girilmemelidir.
        /// </summary>
        /// <param name="option"></param>
        private void SameOptionExists(Option option)
        {
            var existingOption = options.Find(x => x.Name == option.Name);

            if (existingOption != null)
            {
                throw new Exception("Aynı seçeneği daha Önce giriniz");
            }
        }

        /// <summary>
        /// Option verilen cevap Name evet yada Hayır dışında başka birşey olamaz
        /// </summary>
        /// <param name="answer"></param>
        public override void AnswerToQuestion(Option answer)
        {
            if (answer.Name == YesNoTypes.Evet.ToString() || answer.Name == YesNoTypes.Hayır.ToString())
            {
                Answer = answer;

            }
            else
            {

                throw new Exception("Evet yada Hayır cevabından birini seçmelisiniz");
            }
        }
    }
}
