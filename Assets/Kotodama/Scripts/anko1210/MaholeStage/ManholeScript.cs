using UnityEngine;

public class ManholeScript : MonoBehaviour
{
    PopUpCanvas popupCanvas { get { return PopUpCanvas.instance; } }
    EffectSequencer effectSequencer { get { return EffectSequencer.instance; } }

    [SerializeField]
    private string _playerObjName = "Player";
    private GameObject _player;

    private GameObject _upMap;
    private GameObject _downMap;

    private Transform _rightFloor;
    private Collider _rightWall;
    private Transform _leftFloor;
    private Collider _leftWall;

    private float _min = -2.55f;
    private float _max = -1.55f;

    void Start()
    {
        RESET();
    }

    public void ChangePosition(Vector3 pos)
    {
        /// プレイヤーの座標を変更する関数
        _player.transform.localPosition = pos;
    }

    public void IsDestination()
    {
        /// <summary>
        /// 行先はどこですかの関数
        /// </summary>

        /// まずマップが切り替わったらマリちゃんの位置を変更します
        if (ManholePosition.pos.ContainsKey(popupCanvas._str))
        { ChangePosition(ManholePosition.pos[popupCanvas._str]); }
        /// nameが該当しない場合はスタート地点に戻します
        else { ChangePosition(StartPosition.ManholeStage); }
    }

    public void MoveFloor()
    {
        _rightWall.enabled = !_rightWall.enabled;
        _leftWall.enabled = !_leftWall.enabled;

        if (_leftWall.enabled)
        {
            _leftFloor.localPosition = new Vector3(0f, _min);
            _rightFloor.localPosition = new Vector3(0f, _max);
        }
        else
        {
            _leftFloor.localPosition = new Vector3(0f, _max);
            _rightFloor.localPosition = new Vector3(0f, _min);
        }

    }

    public void RESET()
    {
        ReadingPrefab();
        _rightFloor = GameObject.Find("RightRoads").GetComponentInChildren<Transform>();
        _rightWall = GameObject.Find("RightRoadWall").GetComponentInChildren<Collider>();
        _leftFloor = GameObject.Find("LeftRoads").GetComponentInChildren<Transform>();
        _leftWall = GameObject.Find("LeftRoadWall").GetComponentInChildren<Collider>();
        _leftWall.enabled = false;
        _rightWall.enabled = true;
        _leftFloor.localPosition = new Vector3(0f, _max);
        _rightFloor.localPosition = new Vector3(0f, _min);
        _player = GameObject.Find(_playerObjName);
        ChangePosition(StartPosition.ManholeStage);
    }

    /// <summary>
    /// もしプレハブのインスペクターが壊れた場合
    /// </summary>
    void ReadingPrefab()
    {
        var upMap = Resources.Load<GameObject>("Map/Stage/Manhole/ManholeStage_Ver2");
        var downMap = Resources.Load<GameObject>("Map/Stage/Manhole/ManholeDownStage_Ver2");
        if (_upMap == null) { _upMap = Instantiate(upMap); }
        _upMap.name = "Up";
        if (_downMap == null) { _downMap = Instantiate(downMap); }
        _downMap.name = "Down";
        _upMap.SetActive(true);
        _downMap.SetActive(true);
    }



    /// <summary>
    /// ボタンの処理
    /// </summary>
    public void IsFloorMove()
    {
        popupCanvas._isChoice = true;
        MoveFloor();
    }

    public void IsWarpMari()
    {
        popupCanvas._isChoice = true;
        effectSequencer.FadeStart(IsDestination, 0.5f);
    }



}
