using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcelImporter : MonoBehaviour
{
    public TextAsset txt;
    Dictionary<string, string> excel = new Dictionary<string, string>();
    string[,] Sentence;
    int lineSize, rowSize;

    private void Start()
    {
        string currentText = txt.text.Substring(0, txt.text.Length);
        string[] line = currentText.Split('\n');
        lineSize = line.Length;
        rowSize = line[0].Split('\t').Length;
        Sentence = new string[lineSize, rowSize];
        for (int i = 0; i < lineSize; i++)
        {
            string[] row = line[i].Split('\t');
            for (int j = 0; j < rowSize; j++)
            {
                Sentence[i, j] = row[j];
                Debug.Log(i + "," + j + "," + Sentence[i, j]);
            }
        }

    }

}
