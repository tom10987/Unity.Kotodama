
//using UnityEngine;


//------------------------------------------------------------
// FIXME:
// gameObject.enabled = true の状態でゲームを起動しないと、
// Activate() を呼び出した時に null 参照になる

public class Adventure : SingletonBehaviour<Adventure> {

  StoryManager _manager = null;


  //------------------------------------------------------------
  // public method

  /// <summary>
  /// json ファイルを読み込んでアドベンチャーモード起動
  /// </summary>
  public void Activate(string jsonName) {
    gameObject.SetActive(true);
    _manager.LoadJson(jsonName);
  }


  //------------------------------------------------------------
  // Behaviour

  protected override void Awake() { base.Awake(); }

  void Start() {
    _manager = GetComponent<StoryManager>();
    gameObject.SetActive(false);
  }

  // FIXME: 選択肢に対応していない
  // TODO: 選択肢に対応できる仕組みを作る
  void Update() {
    if (TouchController.IsTouchBegan()) { _manager.Next(); }
  }
}
