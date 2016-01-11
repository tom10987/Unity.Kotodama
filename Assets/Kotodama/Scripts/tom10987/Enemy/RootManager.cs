
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
}
