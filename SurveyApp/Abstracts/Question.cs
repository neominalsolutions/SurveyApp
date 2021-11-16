using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Abstracts
{
    /// <summary>
    /// TAnswer hangi cevap tipi ile bu soru çalışacak bunun bilgisini generic sınıf olarak verdik
    /// </summary>
    /// <typeparam name="TAnswer"></typeparam>
    public abstract class Question<TAnswer>: IQuestion
    {
        /// <summary>
        /// Sorunun ne olduğu bilgisini tutarız
        /// </summary>
        

        public Question(string text)
        {
            this.text = text;
        }

        // fields
        private string text;

        // Property field aktarılan değeri döndürsün
        public string Text => text;

        /// <summary>
        /// uygulamada 3 farklı tipte cevabımız var
        /// string cevap
        /// datetime cevap
        /// option cevap
        /// Cevab soru tipinme göre değiştiğinden dolayı T olarak tanımladık. ve body yazmadık.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="answer"></param>
        public abstract void AnswerToQuestion(TAnswer answer);




    }
}
