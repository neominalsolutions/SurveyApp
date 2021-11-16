using SurveyApp.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Abstracts
{
    public interface IQuestionWithOptions
    {
        /// <summary>
        /// Bu arayüz ile Question sınıflarına Options ekleme özelliği kazandıracağız
        /// </summary>
        /// <param name="option"></param>
        void AddOption(Option option);
        IReadOnlyList<Option> Options { get; }
    }
}
