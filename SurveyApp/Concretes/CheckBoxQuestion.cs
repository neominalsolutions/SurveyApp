using SurveyApp.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Concretes
{

    public class CheckBoxQuestion: Question<Option>, IQuestionWithOptions
    {

        /// <summary>
        /// Bu soru tipinin birden fazla cevabı olabilir. Hiçbiri seçilirse tüm diğer cevaplar silinir
        /// </summary>
        public IReadOnlyList<Option> Answers => answers;

        private List<Option> answers = new List<Option>();

        /// <summary>
        /// En fazla 5 adet seçenekten oluşabilir.
        /// </summary>
        public List<Option> options = new List<Option>();
        public IReadOnlyList<Option> Options
        {
            get
            {
                return options;
            }
        }


        public CheckBoxQuestion(string text):base(text)
        {
            options.Add(new Option(name: "Hiçbiri"));
        }

        

        

        /// <summary>
        /// Hiçbiri seçeneği otomatik olarak eklensin
        /// </summary>
        private void AddNoSelectionAnswer()
        {
            answers.Add(new Option(name: "Hiçbiri"));
        }

        public void AddOption(Option option)
        {

            if (options.Count >= 5)
            {
                throw new Exception("En fazla 5 adet seçenek girmelisiniz");
            }

            if (options.Any(x => x.Name == option.Name))
            {
                throw new Exception("Aynı seçenek tekrar girilemez");
            }

            options.Add(option);
        }

        /// <summary>
        /// Bu soru tipinde irden fazla doğru seçenek seçilebilir. Yanlış seçim cevaplardan kaldırılabilir olduğu için AnswerToQuestion tek başına yeterli değildir. Yanlış seçimlerin kaldırılabilmesi için bir method daha yapıcaz.
        /// </summary>
        /// <param name="answer"></param>
        public override void AnswerToQuestion(Option answer)
        {
            // aynı cevabı verme ihtimali için yazdık.
            if(answers.Any(x=> x.Name == answer.Name))
            {
                throw new Exception("Aynı cevap tekrar girilemez");
            }

            // Cevapların içerisinde Hiçbiri diye bir seçenek seçilmiş ise sadece Hiçbiri seçili olur.
            if(answers.Any(x=> x.Name == "Hiçbiri"))
            {
                answers.Clear();
                AddNoSelectionAnswer();
            }

            // cevap verebilmek için options adeti en az 4 olmalıdır
            if (options.Count < 5)
            {
                throw new Exception("Cevap verebilmek için en az 5 adet seçenek olmalıdır.");
            }

            // cevap seçeneklerin içerisinde varsa girilebilir.
            if (options.Any(x => x.Name == answer.Name))
            {
                answers.Add(answer);
            }
            else
            {
                throw new Exception("Olmayan bir seçeneğe cevap verilemez!");
            }
        }

        /// <summary>
        /// Yanlış bir seçim yapılırsa seçimi kaldırmak için kullandığımız method
        /// </summary>
        /// <param name="option"></param>
        public void RemoveAnswer(Option option)
        {
            
            var removeAnswer = answers.Find(x => x.Name == option.Name);

            if (removeAnswer != null)
            {
                answers.Remove(removeAnswer);
            }
            else
            {
                throw new Exception("Böyle bir cevap seçenek arasında mevcut değildir.!");
            }
        }
    }
}
