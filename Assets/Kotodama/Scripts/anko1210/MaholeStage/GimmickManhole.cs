using UnityEngine;

public class GimmickManhole : MonoBehaviour {

    PlayerStatus state { get {  return PlayerStatus.instance; } }
    PopUpCanvas popup { get { return PopUpCanvas.instance; } }
    ItemState itemState;

    [SerializeField]
    public string _itemName;
    private bool _isWindowView;

    void Start()
    {
        _isWindowView = false;
        if (_itemName == "")
        {
            Debug.Log("なにも入っていないけど大丈夫？");
        }         
    }

    void OnTriggerStay(Collider col)
    {
        Debug.Log(this.gameObject.name);
        if (col.gameObject.tag.Equals(ObjectTag.player))
        {
            if (TouchController.IsTouchEnded())
            {
                if (_itemName == "")
                {
                    popup.CreatePopUpWindowVerGimmick("もじもじ", Test);
                    _isWindowView = true;
                }
                else
                {
                    itemState = GameObject.Find(_itemName).gameObject.GetComponentInChildren<ItemState>();
                    if (itemState.hasItem)
                    {
                        popup.CreatePopUpWindowVerGimmick("もじもじもじ", Test);
                        _isWindowView = true;
                    }
                    else
                    {
                        popup.CreatePopUpWindow("失敗した");
                        popup._count = 1f;
                        popup.IsCancel();
                    }
                }
            }            
        }
    }

    public void Test()
    {
    }
}
