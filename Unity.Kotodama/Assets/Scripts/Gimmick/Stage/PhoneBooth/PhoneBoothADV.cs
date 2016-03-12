
using UnityEngine;


public class PhoneBoothADV : MonoBehaviour {

  EventState _publicPhone;

  void Start() {
    _publicPhone = gameObject.GetComponentInChildren<EventState>();
    _publicPhone._entry = TextPublicPhone;
  }

  void Update() {
    /*
    if (PublicPhone._isAlreadyNovel && DialButton_Ver2.IsInputSuccess)
      Check.Stop();
    else if (PublicPhone._isAlreadyNovel && !DialButton_Ver2.IsInputSuccess)
      PublicPhone._isAlreadyNovel = false;
    */
  }

  public string[,] TextPublicPhone = {
    { Command.start, "", "", "" },
    { Command.act, "InsertStart", "", "" },
    { Command.name, CharaName.mari, "" , ""},
    { Command.text, "「……これって……」", "", "" },

    { Command.name, CharaName.narrator,"",""},
    { Command.text, "公衆電話をつかいますか？", "", "" },
    { Command.jump, "つかってみる(YesUse)", "やっぱりやめる(NoUse)", "" },

    { Command.act, "YesUse", "", "" },
    { Command.text, "……………………", "", "" },
    { Command.end, "", "", "" },

    { Command.act,  "NoUse", "", "" },
    { Command.cashb, "false", "", ""},
    { Command.end, "", "", "" },
  };
}
