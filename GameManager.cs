using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Diagnostics;
using Random = UnityEngine.Random;
using Unity.VisualScripting;
using System.Reflection;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI QuizText;
    public TextMeshProUGUI RightAnswer;
    public TextMesh[] textMeshes; // TextMesh 컴포넌트 배열


    public int minValue = 1; // 랜덤 값의 최소값
    public int maxValue = 5; // 랜덤 값의 최대값

    List<string> TextArray = new List<string>();

    public string[] answer;

    // Start is called before the first frame update
    void Start()
    {
        TextArray.Add("(), {}, '', <>, [], (), 자료사전");
        TextArray.Add("NUI, CLI, GUI, VUI, OUI, NUI, 동작 인식");
        TextArray.Add("Precention, Avoidance, Detection, Recovery, Backtracking, Avoidance, 은행가 알고리즘");
        TextArray.Add("ALTER, GRANT, ROLLBACK, UPDATE, INSERT, ALTER, DDL 명령어");
        TextArray.Add("128, 64, 256, 32, 512, 64, DES 비트");

        string AnswerText = TextArray[0];
        answer = AnswerText.Split(',');

        RightAnswer.text = answer[5];
        QuizText.text = answer[6];

        // 중복 없는 랜덤 값을 생성
        List<int> randomValues = GenerateRandomValues(minValue, maxValue, textMeshes.Length);

        // 생성한 랜덤 값을 j에 넣고, 랜덤 값 위치를 answer로 받아와 TextMesh 컴포넌트의 text 속성에 할당
        for (int i = 0; i < textMeshes.Length; i++)
        {
            int j = randomValues[i];
            textMeshes[i].text = answer[j];
            //Debug.Log("j : "+j);
        }
    }
    List<int> GenerateRandomValues(int min, int max, int count)
    {
        // 중복 없는 랜덤 값을 저장할 리스트 생성
        List<int> randomValues = new List<int>();

        // 랜덤 값을 생성
        while (randomValues.Count < count)
        {
            int value = Random.Range(min, max + 1); // 랜덤 값 생성

            // 중복되지 않은 값만 리스트에 추가
            if (!randomValues.Contains(value))
            {
                randomValues.Add(value);
            }
        }

        return randomValues;
    }
}
