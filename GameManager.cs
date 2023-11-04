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
    public TextMesh[] textMeshes; // TextMesh ������Ʈ �迭


    public int minValue = 1; // ���� ���� �ּҰ�
    public int maxValue = 5; // ���� ���� �ִ밪

    List<string> TextArray = new List<string>();

    public string[] answer;

    // Start is called before the first frame update
    void Start()
    {
        TextArray.Add("(), {}, '', <>, [], (), �ڷ����");
        TextArray.Add("NUI, CLI, GUI, VUI, OUI, NUI, ���� �ν�");
        TextArray.Add("Precention, Avoidance, Detection, Recovery, Backtracking, Avoidance, ���డ �˰���");
        TextArray.Add("ALTER, GRANT, ROLLBACK, UPDATE, INSERT, ALTER, DDL ��ɾ�");
        TextArray.Add("128, 64, 256, 32, 512, 64, DES ��Ʈ");

        string AnswerText = TextArray[0];
        answer = AnswerText.Split(',');

        RightAnswer.text = answer[5];
        QuizText.text = answer[6];

        // �ߺ� ���� ���� ���� ����
        List<int> randomValues = GenerateRandomValues(minValue, maxValue, textMeshes.Length);

        // ������ ���� ���� j�� �ְ�, ���� �� ��ġ�� answer�� �޾ƿ� TextMesh ������Ʈ�� text �Ӽ��� �Ҵ�
        for (int i = 0; i < textMeshes.Length; i++)
        {
            int j = randomValues[i];
            textMeshes[i].text = answer[j];
            //Debug.Log("j : "+j);
        }
    }
    List<int> GenerateRandomValues(int min, int max, int count)
    {
        // �ߺ� ���� ���� ���� ������ ����Ʈ ����
        List<int> randomValues = new List<int>();

        // ���� ���� ����
        while (randomValues.Count < count)
        {
            int value = Random.Range(min, max + 1); // ���� �� ����

            // �ߺ����� ���� ���� ����Ʈ�� �߰�
            if (!randomValues.Contains(value))
            {
                randomValues.Add(value);
            }
        }

        return randomValues;
    }
}
