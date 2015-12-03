using UnityEngine;
using System.IO;
using System.Text;

public class FileIO : MonoBehaviour
{
    //public void loggggSave(int num, string txt)
    //{
    //    StreamWriter sw;
    //    FileInfo fi;
    //    fi = new FileInfo(Application.dataPath + "FileName.csv");
    //    sw = fi.AppendText();
    //    sw.WriteLine("test output");
    //    sw.Flush();
    //    sw.Close();
    //}

    string fileName = "text.csv";
    string filePath = "Assets/Kotodama/WorkSpace/anko1210/Resources/TEXT/";

    public void WritingText()
    {
        FileStream f = new FileStream(filePath+fileName, FileMode.CreateNew, FileAccess.Write);
        Encoding utf8Enc = Encoding.GetEncoding("UTF-8");
        StreamWriter writer = new StreamWriter(f, utf8Enc);
        writer.WriteLine("かきくけこ");
        writer.Close();
    }

    public void ExistsText()
    {
        if (File.Exists(filePath+fileName))
        {
            Debug.Log("みつかりましたよ！兼さん！");
        }
        else { Debug.Log("ファイルさんが見当たりません…"); }
    }

    public void LoadText()
    {
        FileStream f = new FileStream(filePath + fileName, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(f);
        if (reader != null)
        {
            while (!reader.EndOfStream) // .EndOfStream = ファイル終端
            {
                int sttr = reader.Read();
                //string str = reader.ReadLine();
                //Debug.Log("thisLoad = " + str);
            }
            reader.Close();
        }

    }
}