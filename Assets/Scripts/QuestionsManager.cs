using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Libs;

public class QuestionsManager : Singleton<QuestionsManager>
{
    public List<Question> GetFirstLevelQuestions() {
        List<Question> result = new List<Question>(100);

        for (int i = 0; i < 100; i++) {
            int a = Random.Range(0, 11);
            int b = Random.Range(0, 11 - a); // гарантируем, что сумма <= 10
            Question question = new Question();
            question.question = a + " + " + b + " = ?";


            List<Answer> answers = new List<Answer>(4);
            Answer correctAswer = new Answer();
            correctAswer.isCorrect = true;
            correctAswer.answer = (a + b).ToString();
            answers.Add(correctAswer);

            // Генерируем 3 уникальных неправильных ответа
            while (answers.Count < 4)
            {
                Answer wrongAnswer = new Answer();
                wrongAnswer.isCorrect = false;
                wrongAnswer.answer = Random.Range(0, 11).ToString();

                bool isFind = false;
                foreach (var answer in answers) {
                    if (answer.answer == wrongAnswer.answer) {
                        isFind = true;
                        break;
                    }
                }
                if (!isFind){
                    answers.Add(wrongAnswer);
                }
             }
            question.asnwers = Common.ShuffleList<Answer>(answers);
            result.Add(question);
        }

        return Common.ShuffleList<Question>(result);
    }

    public List<Question> GetSecondLevelQuestions()
    {
        List<Question> result = new List<Question>(10);

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

        for (int i = 0; i < 10; i++)
        {
            int a = Random.Range(0, 161);
            int v = 0;
            foreach (var weight in valueWeight) {
                if (a >= weight.Value) {
                    v = weight.Key;
                    break;
                }
            }
            int b = Random.Range(0, v); // гарантируем, что разница <= 10
            Question question = new Question();
            question.question = v + " - " + b + " = ?";


            List<Answer> answers = new List<Answer>(4);
            Answer correctAswer = new Answer();
            correctAswer.isCorrect = true;
            correctAswer.answer = (v - b).ToString();
            answers.Add(correctAswer);

            // Генерируем 3 уникальных неправильных ответа
            while (answers.Count < 4)
            {
                Answer wrongAnswer = new Answer();
                wrongAnswer.isCorrect = false;
                wrongAnswer.answer = Random.Range(0, 11).ToString();

                bool isFind = false;
                foreach (var answer in answers)
                {
                    if (answer.answer == wrongAnswer.answer)
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
            question.asnwers = Common.ShuffleList<Answer>(answers);
            result.Add(question);
        }

        return Common.ShuffleList<Question>(result);
    }
}
