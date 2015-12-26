
using UnityEngine;


//------------------------------------------------------------
// TIPS:
// 子オブジェクトの Transform をまとめて登録してください
//
// FindObject[s]OfType<RootManager>() を使用して、
// ヒエラルキーにある RootManager を全て取得することができます

public class RootManager : MonoBehaviour {

  [SerializeField]
  Transform[] _spots = null;
  public Transform[] spots { get { return _spots; } }


  //------------------------------------------------------------
  // 使用方法のサンプル

  void sample() {
    // 全部取得  ※複数系の s が付いていることに注意
    var objects = FindObjectsOfType<RootManager>();
    if (objects.Length > 0) {
      EnemyManager.instance.CreateEnemy(new Vector3(0f, 0f, 0f), objects[0].spots);
    }

    // FindObjectsOfType で取得した配列の中身は、
    // ヒエラルキー上の並び方の影響を受けるため、
    // 同じ 0 でも順番が変わって、中身が違う可能性がある

    // 解決例
    // あらかじめ、取得するオブジェクトに名前をつけておき、
    // 名前を使って取得したいオブジェクトを指定する

    // ヒエラルキーに hoge, fuga というオブジェクトがあるとき、
    // hoge のほうを取り出したい

    // 全部取得してから、hoge を探す
    // FIXME:
    // RootManager は確実に取り出せるが、検索する必要がある
    // また、名前を間違えると、エラーは発生しないが、生成ができない
    var rootObjects = FindObjectsOfType<RootManager>();
    foreach (var rootObject in rootObjects) {
      if (rootObject.name == "hoge") {
        EnemyManager.instance.CreateEnemy(new Vector3(0f, 0f, 0f), rootObject.spots);
      }
    }

    // hoge を直接探す
    // FIXME:
    // hoge が存在しない場合、
    // あるいは hoge に RootManager が設定されてない場合の null チェックが必要になる
    var hoge = GameObject.Find("hoge");
    if (hoge != null) {
      var rootObject = hoge.GetComponent<RootManager>();
      if (rootObject == null) { return; }
      EnemyManager.instance.CreateEnemy(new Vector3(0f, 0f, 0f), rootObject.spots);
    }

    // CreateEnemy() を呼び出すスクリプト、
    // および登録するオブジェクトのデータは各自で作成をお願いします
  }
}
