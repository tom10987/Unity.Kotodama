using UnityEngine;

public class ManholeScript : MonoBehaviour
{
    [SerializeField]
    private string _playerObjName = "Player";
    private GameObject _player;

    private GameObject _upMap;
    private GameObject _downMap;
    private GameObject _item;

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

    public void IsDestination(string name)
    {
        /// <summary>
        /// 行先はどこですかの関数
        /// </summary>

        /// まずマップが切り替わったらマリちゃんの位置を変更します
        if (ManholePosition.pos.ContainsKey(name))
        { ChangePosition(ManholePosition.pos[name]); }
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
        var upMap = Resources.Load<GameObject>("Map/Maps/Manhole/ManholeStage_Ver2");
        var downMap = Resources.Load<GameObject>("Map/Maps/Manhole/ManholeDownStage_Ver2");
        var item = Resources.Load<GameObject>("Map/Maps/Manhole/Item");
        if (_upMap == null) { _upMap = Instantiate(upMap); }
        _upMap.name = "Up";
        if (_downMap == null) { _downMap = Instantiate(downMap); }
        _downMap.name = "Down";
        if (_item == null) { _item = Instantiate(item); }
        _item.name = "Item";
        _upMap.SetActive(true);
        _downMap.SetActive(true);
        _item.SetActive(true);
    }

    public void DestroyStage()
    {
        Destroy(_downMap.gameObject);
        Destroy(_upMap.gameObject);
        Destroy(_item.gameObject);
        _upMap = _downMap = _item = null;
    }

}
