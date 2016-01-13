
using UnityEngine;
using UnityEngine.UI;


public class BoardMemo : MonoBehaviour {

  EnemyManager enemy { get { return EnemyManager.instance; } }

  [SerializeField]
  Text _memo = null;
  public Text memo { get { return _memo; } }

  [SerializeField]
  Image _memoImage = null;
  public Image memoImage { get { return _memoImage; } }


  /// <summary> タッチされたらメモを削除する </summary>
  public void OnTouch() {
    Destroy(gameObject);
    GameManager.instance.ReStart();
  }
}
