
using UnityEngine;

public class BoardTrigger : MonoBehaviour {

  [SerializeField]
  BoardMemo _memoPrefab = null;

  [SerializeField]
  [Tooltip("メモの色を指定")]
  Color _memoColor = Color.white;

  [SerializeField]
  [Tooltip("テキストの色を指定")]
  Color _textColor = Color.white;

  [SerializeField]
  [Multiline(10)]
  string _text = string.Empty;

  void OnTriggerEnter(Collider other) {
    if (!ObjectTag.Player.EqualTo(other.tag)) { return; }

    // TIPS: メモを生成
    var instance = Instantiate(_memoPrefab);
    instance.memo.color = _textColor;
    instance.memo.text = _text;
    instance.memoImage.color = _memoColor;
  }
}
