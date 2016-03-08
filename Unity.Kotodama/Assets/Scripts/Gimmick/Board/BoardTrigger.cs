
using UnityEngine;


public class BoardTrigger : MonoBehaviour {

  EnemyManager enemy { get { return EnemyManager.instance; } }

  [SerializeField]
  GameObject _memoPrefab = null;

  [SerializeField]
  [Tooltip("メモの色を指定")]
  Color _memoColor = Color.white;

  [SerializeField]
  [Tooltip("テキストの色を指定")]
  Color _textColor = Color.white;

  // FIXME:
  // インスペクター上の編集がしにくいので、自動的にボックスを拡大する方法を調べる
  [SerializeField]
  [Multiline(7)]
  string _text = string.Empty;


  void OnTriggerEnter(Collider other) {
    if (other.tag != ObjectTag.Player.ToString()) { return; }

    // TIPS: メモを生成
    var instance = Instantiate(_memoPrefab).GetComponent<BoardMemo>();
    instance.memo.color = _textColor;
    instance.memo.text = _text;
    instance.memoImage.color = _memoColor;

    // TIPS: プレイヤーと敵キャラを停止する
    PlayerState.instance.Stop();
    GameManager.instance.Pause();
  }
}
