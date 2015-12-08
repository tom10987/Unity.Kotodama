
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;


//------------------------------------------------------------
// XXX:
// ベータ発表後まで、このスクリプトを変更しないこと！

//------------------------------------------------------------
// TODO:
// データ構造を変更、変更に伴う処理の仕様変更
// 演出面の強化

//------------------------------------------------------------
// データ構造案
//
// キャラ立ち絵の表示位置（あらかじめ基準位置を決めておき、番号で位置を指定する形）
// キャラ立ち絵の表示フラグ（表示するかどうかのフラグのみ）
// 背景表示フラグ（フラグのみ）
// 背景画像のパス（上記フラグが立っていれば、パスを参照して画像読み込み）
// 発言キャラ名
// 発言内容（＝テキスト）
//
// 選択肢の有無（フラグのみ）
// （以下、選択肢フラグが立っている場合のみ指定）
// 選択肢の数
// 選択肢のテキスト（はい、いいえのようなもの）
// 選択肢の結果（＝分岐先）
//
// 上記を基本的なデータ構造として、１パート分の配列にまとめる
// １回に表示するテキストを基準に、それぞれのフラグを指定、管理する
//
// 注釈にあるとおり、テキスト、パス以外は基本的にフラグとして管理するのみ
// リソースは最初に必要なものだけ読み込み、フラグを参照して切り替える

public class StoryManager : MonoBehaviour {

  [SerializeField]
  [Tooltip("テキストを表示するためのボックスを指定")]
  Text _textBox = null;

  [SerializeField]
  [Tooltip("キャラクター名を表示するためのボックスを指定")]
  Text _nameBox = null;

  // TODO: json の内部構造に合わせたデータ構造にする
  // TODO: 立ち絵表示位置を決める
  // TODO: 表示位置と ID の関連付けを行う
  struct StoryData {

    // TIPS: 構造体は初期化が面倒なので、あらかじめ空のオブジェクトを用意
    static public readonly StoryData empty = new StoryData {
      text = string.Empty,
      name = string.Empty,
      actor = new List<int>(),
      posID = new List<int>(),
      bgDraw = 0,
      selectButton = new List<KeyValuePair<string, int>>(),
    };

    public string text { get; set; }
    public string name { get; set; }

    // TIPS: actor.Count = 0 -> 何も表示しないというフラグとして扱える
    public List<int> actor { get; set; }
    public List<int> posID { get; set; }

    // TODO: 表示するリソースのパスも json のデータとして含めるか検討する
    // TIPS: 表示する背景の ID
    // FIXME: json が bool 型を扱えるか未検証のため、int 型で代用
    // FIXME: bool 型は扱えたはずなので、検証待ち
    public int bgDraw { get; set; }

    // TIPS: 選択肢とその分岐先のペア
    public List<KeyValuePair<string, int>> selectButton { get; set; }
  }

  List<StoryData> _data = null;
  IEnumerator _iterator = null;

  int currentIndex { get; set; }

  readonly string fileExtension = ".json";

  // TODO: json のデータ構造に合わせたキーを作る
  // FIXME: 時間ないので、現状のキーを流用
  readonly string textKey = "Texts";


  //------------------------------------------------------------
  // public method

  public void Next() {
    if (_iterator != null && _iterator.MoveNext()) { return; }
    gameObject.SetActive(false);
  }

  public void LoadJson(string fileName) {
    if (_textBox == null) { Debug.LogError("textBox is null"); return; }
    if (_nameBox == null) { Debug.LogError("nameBox is null"); return; }

    // 初期化
    _data = new List<StoryData>();

    // json 読み込みと変換
    var json = File.ReadAllText(GeneratePath(fileName), Encoding.UTF8);
    var node = JsonNode.Parse(json);

    // 読み込んだ json のデータを格納
    foreach (var data in node[textKey]) {

      // 空オブジェクトのコピーを作る
      var temp = StoryData.empty;

      temp.text = data["text"].Get<string>();
      temp.name = data["speaker"].Get<string>();

      // TODO: json のデータ構造を変えたら、それに合わせたデータ読み込みの処理を作る

      Debug.Log("text = " + temp.text);
      Debug.Log("name = " + temp.name);

      _data.Add(temp);
    }

    _textBox.text = GeneratePath(fileName);

    _iterator = GetIterator();
    _iterator.MoveNext();
  }


  //------------------------------------------------------------
  // system

  string GeneratePath(string name) {
    var assetsPath = Application.dataPath + "/Kotodama/Resources/Json/";
    return assetsPath + name + fileExtension;
  }

  IEnumerator GetIterator() {
    currentIndex = 0;
    while (currentIndex < (uint)_data.Count) {

      // TODO: テキスト以外に読み込んだデータの反映

      _nameBox.enabled = (_data[currentIndex].name != string.Empty);

      _textBox.text = _data[currentIndex].text;
      _nameBox.text = _data[currentIndex].name;

      yield return null;
      ++currentIndex;
    }
  }
}
