using Libs;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsManager : Singleton<QuestionsManager>
{
    public List<IQuestion> GetFirstLevelQuestions()
    {
        List<IQuestion> result = new List<IQuestion>(100);

        for (int i = 0; i < 101; i++)
        {
            int a = Random.Range(0, 11);
            int b = Random.Range(0, 11 - a); // гарантируем, что сумма <= 10


            List<IAnswer> answers = new List<IAnswer>(4);
            Answer correctAswer = new Answer((a + b).ToString(), true);
            answers.Add(correctAswer);

            // Генерируем 3 уникальных неправильных ответа
            while (answers.Count < 4)
            {
                Answer wrongAnswer = new Answer(Random.Range(0, 11).ToString(), false);
                bool isFind = false;
                foreach (var answer in answers)
                {
                    if (answer.GetAnswerText() == wrongAnswer.GetAnswerText())
                    {
                        isFind = true;
                        break;
                    }
                }
                if (!isFind)
                {
                    answers.Add(wrongAnswer);
                }
            }

            Question question = new Question(a + " + " + b + " = ?", Common.ShuffleList<IAnswer>(answers));
            result.Add(question);
        }

        return Common.ShuffleList<IQuestion>(result);
    }

    public List<IQuestion> GetSecondLevelQuestions()
    {
        List<IQuestion> result = new List<IQuestion>(100);

        Dictionary<int, int> valueWeight = new Dictionary<int, int>() {
            { 10, 140 },
            { 9, 120 },
            { 8, 95 },
            { 7, 75 },
            { 6, 45 },
            { 5, 35 },
            { 4, 25 },
            { 3, 20 },
            { 2, 15 },
            { 1, 10 },
            { 0, 5 },
        };

        for (int i = 0; i < 101; i++)
        {
            int a = Random.Range(0, 161);
            int v = 0;
            foreach (var weight in valueWeight)
            {
                if (a >= weight.Value)
                {
                    v = weight.Key;
                    break;
                }
            }
            int b = Random.Range(0, v); // гарантируем, что разница <= 10


            List<IAnswer> answers = new List<IAnswer>(4);
            Answer correctAswer = new Answer((v - b).ToString(), true);
            answers.Add(correctAswer);

            // Генерируем 3 уникальных неправильных ответа
            while (answers.Count < 4)
            {
                Answer wrongAnswer = new Answer(Random.Range(0, 11).ToString(), false);
                bool isFind = false;
                foreach (var answer in answers)
                {
                    if (answer.GetAnswerText() == wrongAnswer.GetAnswerText())
                    {
                        isFind = true;
                        break;
                    }
                }
                if (!isFind)
                {
                    answers.Add(wrongAnswer);
                }
            }
            Question question = new Question(v + " - " + b + " = ?", Common.ShuffleList<IAnswer>(answers));
            result.Add(question);
        }

        return Common.ShuffleList<IQuestion>(result);
    }
}
