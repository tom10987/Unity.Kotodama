
using UnityEngine;
using System.IO;
using System.Text;


public class FileIO : MonoBehaviour {

  string _fileName = "text.csv";
  string _filePath = "Assets/Kotodama/WorkSpace/anko1210/Resources/TEXT/";

  public void Write(string path) {
    FileStream f = new FileStream(_filePath + _fileName, FileMode.CreateNew, FileAccess.Write);
    Encoding utf8Enc = Encoding.GetEncoding("UTF-8");
    StreamWriter writer = new StreamWriter(f, utf8Enc);
    writer.WriteLine("かきくけこ");
    writer.Close();
  }

  public void ExistsText() {
    if (File.Exists(_filePath + _fileName)) {
      Debug.Log("みつかりましたよ！兼さん！");
    }
    else { Debug.Log("ファイルさんが見当たりません…"); }
  }

  public void LoadText() {
    FileStream f = new FileStream(_filePath + _fileName, FileMode.Open, FileAccess.Read);
    StreamReader reader = new StreamReader(f);
    if (reader != null) {
      while (!reader.EndOfStream) // .EndOfStream = ファイル終端
      {
        int value = reader.Read();
        string str = reader.ReadLine();
        Debug.Log("thisLoad = " + value + str);
      }
      reader.Close();
    }
  }
}
