using SurveyApp.Abstracts;
using SurveyApp.Concretes;
using System;
using System.Collections.Generic;

namespace SurveyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<IQuestion> questions = new List<IQuestion>();


            ShortTextQuestion sT = new ShortTextQuestion(text:"Adınızı giriniz");
            sT.AnswerToQuestion("Berkay");

            ParagraphQuestion pT = new ParagraphQuestion(text: "Biyografinizi yazınız");
            pT.AnswerToQuestion("Etiam sit amet neque mauris.");

            questions.Add(sT);
            questions.Add(pT);
                

            DateTimeQuestion dT = new(text: "Doğum Tarihinizi giriniz");
            dT.AnswerToQuestion(DateTime.Now.AddYears(-34));

            questions.Add(dT);


            YesNoQuestion yT = new YesNoQuestion(text: "Sigara kullanıyor musunuz?");
            yT.AnswerToQuestion(new Option(name:"Evet"));

            RadioButtonQuestion rT = new RadioButtonQuestion(text:"En sevdiğiniz renk");
            rT.AddOption(new Option(name: "Beyaz"));
            rT.AddOption(new Option(name: "Mavi"));
            rT.AddOption(new Option(name: "Sarı"));
            rT.AddOption(new Option(name: "Kırmızı"));

            rT.AnswerToQuestion(new Option(name: "Kırmızı"));
            //rT.AnswerToQuestion(new Option(name: "Gri")); // Hata veremeli olmayan bir option cevap olarak verildi.

            CheckBoxQuestion cT = new CheckBoxQuestion(text: "Hobileriniz");
            cT.AddOption(new Option(name: "Futbol"));
            cT.AddOption(new Option(name: "Kitap Okuma"));
            cT.AddOption(new Option(name: "Dans"));
            cT.AddOption(new Option(name: "Muzik"));
            // cT.AddOption(new Option(name: "Yüzme")); // Bu hata veremeli en fazla 5 adet option girebiliriz. zaten bir tanesi Hiçbiri olarak giriliyor.

            cT.AnswerToQuestion(new Option(name: "Dans"));
            // cT.AnswerToQuestion(new Option(name: "Yüzme"));

            // hata almam gerekiyor.
            var s = new Survey(DateTime.Now, "Survey 1", "Deneme Anket", 3);
            s.SetUserInfo("ali", "can");
            //s.AddQuestion(cT);
            s.AddQuestion(sT);
            s.AddQuestion(sT);
            //s.AddQuestion(pT);







            //Option o = new Option(name:"A");
            //Option o1 = new Option(name: "A");
            //HashSet<Option> options = new HashSet<Option>();

            //options.Add(o);
            //options.Add(o);
            //options.Add(o1);


            //List<Abstracts.Question<string>> qList = new List<Abstracts.Question<string>>();
            ////qList.Add(new Question<string>());
            //qList.Add(new ShortTextQuestion());


            //foreach (var item in qList)
            //{
            //    if(item is ShortTextQuestion)
            //    {
            //        Console.WriteLine(((ShortTextQuestion)item).Answer);
            //    }
            //    else if(item is DateTimeQuestion)
            //    {
            //        Console.WriteLine(((DateTimeQuestion)item).Answer.ToShortDateString());
            //    }

            //}
        }
    }
}
