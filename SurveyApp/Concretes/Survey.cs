using SurveyApp.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Concretes
{
    public class SurveyUser
    {
        public SurveyUser(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }

    }

    public class Survey
    {
        private List<IQuestion> questions = new List<IQuestion>();
        public IReadOnlyList<IQuestion> Questions => questions;

        public DateTime Date { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        public int MaximumQuestionCount { get; private set; }

        public SurveyUser SurveyUser { get; private set; }


        public Survey(DateTime date, string title, string description, int maximumQuestionCount)
        {
            Date = date;
            Title = title;
            Description = description;
            MaximumQuestionCount = maximumQuestionCount;
        }

        public void SetUserInfo(string name,string surname)
        {
            this.SurveyUser = new SurveyUser(name, surname);
        }

        /// <summary>
        /// Aynı sorunun gelip gelmediğini kontrol edelim
        /// </summary>
        /// <param name="question"></param>
        public void AddQuestion(IQuestion question)
        {
            SameQuestionExists(question);

            if (this.SurveyUser == null)
            {
                throw new Exception("Anket için ad soyad bilgisi girmelisiniz");
            }

            if(Questions.Count < MaximumQuestionCount)
            {
                questions.Add(question);
            }
            else
            {
                throw new Exception("Maksimum soru adetini aşamazsınız");
            }
         
        }

        private void SameQuestionExists(IQuestion question)
        {
            bool isExist = Questions.Any(x => x.Text == question.Text);

            if (isExist)
            {
                throw new Exception("Aynı soru mevcut!");
            }


            //foreach (var item in Questions)
            //{
            //    if(item is DateTimeQuestion)
            //    {
            //       string txt = ((DateTimeQuestion)item).Text;

            //        if(question.Text == txt)
            //        {
            //            throw new Exception("Aynı soru mevcut!");
            //        }
            //    }
            //}
        }

    }
}
