using Libs;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsManager : Singleton<QuestionsManager>
{
    public List<IQuestion> GenerateLevel(LevelSettings settings)
    {
        List<IQuestion> result = new List<IQuestion>(100);

        for (int i = 0; i < 101; i++)
        {
            int a = 0;
            int b = 0;
            string ex = "";
            int answer = 0;

            if (settings.type == LevelType.Sum)
            {
                a = Random.Range(0, settings.maxValue + 1);
                b = Random.Range(0, settings.maxValue + 1 - a);
                ex = " + ";
                answer = a + b;
            }
            else if (settings.type == LevelType.Dif) {
                a = Random.Range(0, settings.maxValue + 1);
                b = Random.Range(0, a);
                ex = " - ";
                answer = a - b;

            } else if (settings.type == LevelType.SumAndDif) {
                int sumOrDif = Random.Range(0, 2);
                if (sumOrDif > 0)
                {
                    a = Random.Range(0, settings.maxValue + 1);
                    b = Random.Range(0, settings.maxValue + 1 - a);
                    ex = " + ";
                    answer = a + b;
                }
                else {
                    a = Random.Range(0, settings.maxValue + 1);
                    b = Random.Range(0, a);
                    ex = " - ";
                    answer = a - b;
                }
            }

            List<IAnswer> answers = new List<IAnswer>(4);
            Answer correctAswer = new Answer(answer.ToString(), true);
            answers.Add(correctAswer);

            // Генерируем 3 уникальных неправильных ответа
            while (answers.Count < 4)
            {
                Answer wrongAnswer = new Answer(Random.Range(0, settings.maxValue + 1).ToString(), false);
                bool isFind = false;
                foreach (var answerModel in answers)
                {
                    if (answerModel.GetAnswerText() == wrongAnswer.GetAnswerText())
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

            Question question = new Question(a + ex + b + " = ?", Common.ShuffleList<IAnswer>(answers));
            result.Add(question);
        }

        return Common.ShuffleList<IQuestion>(result);
    }

}
