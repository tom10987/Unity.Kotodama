
using UnityEngine;
using UnityEngine.UI;
using System.IO;


//------------------------------------------------------------
// TODO:
// アイテムを持っているかどうかは、別のクラス、別のファイルで管理
// ※ 制作の進捗次第では、アイテム所有フラグが不要になる可能性がある

//------------------------------------------------------------
// 解説
//
// 外部ファイルの読み書き（＝操作）という処理は、基本的に動作が重くなりやすい
// そのため、一度に操作するデータ量は少ないほうが望ましい
//
// 「アイテムの所持」以外のデータ（＝テキスト）に関しては、
// 表示することはあっても、「ゲーム内で変更」されることはない
//
// つまり、ファイル操作が発生するのは、所持のフラグのみ
// したがって、フラグ専用のファイルを作り、操作はそちらに限定するのが理想

//------------------------------------------------------------
// 具体的な処理
//
// 最初に全アイテムのフラグを取得、ウィンドウを表示するときに、
// 持っているアイテムのデータのみ読み込んで生成する

public class ItemReader : MonoBehaviour {

  GameObject _itemBox = null;

  string _inputData;

  FileStream _itemData;
  readonly string _dataPath = "Assets/Kotodama/Resources/CSV/";
  readonly string _dataName = "ItemData.csv";

  readonly string _itemBoxPath = "GameUI/MenuWindow/ItemBox";

  readonly int _dataRowNum = 5;
  string[] _col;
  string[,] _preservation;


  void Start() {
    _itemBox = Resources.Load<GameObject>(_itemBoxPath);
    ItemDataLoading();
  }

  void ItemDataLoading() {
    _itemData = new FileStream(_dataPath + _dataName, FileMode.Open, FileAccess.Read);
    StreamReader reader = new StreamReader(_itemData);
    if (reader != null) {
      while (!reader.EndOfStream) {
        _inputData = reader.ReadToEnd();
      }
      reader.Close();
    }

    string[] _row;

    _col = _inputData.Split('\n');
    Debug.Log("読み込んだ行数 : [" + _col.Length + "]");
    _preservation = new string[_col.Length, _dataRowNum];
    for (int i = 0; i < _col.Length - 1; i++) {
      _row = _col[i].Split(',');
      for (int r = 0; r < _dataRowNum; r++) {
        _preservation[i, r] = _row[r];
      }
    }

    LoadItemBox();
  }

  private void LoadItemBox() {
    for (int c = 2; c < _col.Length - 1; ++c) {
      if (_preservation[c, 1].Equals("T")) {
        CreateItemBox(_itemBox, c, 2, 3, 4);
      }
      else if (_preservation[c, 1].Equals("F")) {
        Debug.Log(">>" + c + "行目のアイテム(" + _preservation[c, 2] + ")は取得していません。");
      }
      else {
        Debug.LogError(">>" + c + "行目、未記入なんだけど！（怒）");
      }
    }
  }

  private GameObject CreateItemBox(GameObject box, int col, int name, int info, int texName) {
    GameObject itemBox = Instantiate(box);                                                  // アイテムボックスを生成します。
    itemBox.name = box.name + "[" + col + "]";                                              // アイテムボックスに名前を付けます。
    itemBox.transform.SetParent(transform);                                                 // アイテムボックスの場所を指定します。今回はスクリプトがついてるオブジェクトの真下を指定した。
    itemBox.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);                           // アイテムボックスの大きさを指定します。
    Image itemImg = itemBox.transform.Find("ItemImage").GetComponentInChildren<Image>();    // アイテムボックス内の画像表示場所を指定します
    Sprite texture = Resources.Load<Sprite>(_preservation[col, texName]);                   // 表示する画像のパスをCSVから読み込み、Resourcesフォルダ内に同名があるか検索します。
    RectTransform size = itemImg.GetComponentInChildren<RectTransform>();                   // 表示する画像のサイズを設定する場所を読み込みます。
    Text[] itemText = itemBox.GetComponentsInChildren<Text>();                              // アイテムボックスで表示するテキストの場所を指定します。
    itemText[0].text = _preservation[col, name];                                            // アイテムの名前を表示させます
    itemText[1].text = _preservation[col, info];                                            // アイテムの概要を表示させます
    itemImg.sprite = texture;                                                               // アイテムの画像を表示させます
    size.sizeDelta = new Vector2(70.0f, 70.0f);                                             // アイテムの表示サイズ（width, height）を書き換えます。
    return itemBox;                                                                         // リターン！！
  }
}
