
###### タイトル：魍魎の街（仮）
###### チーム名：コトダマ

---
### 制作ルール

---
**命名規則について**
- パスカルケース
> 単語区切りで、全ての単語の頭文字を大文字にする --- `GameObject`

- キャメルケース
> 単語区切りで、最初だけ小文字、残りの単語の頭文字を大文字にする --- `gameObject`

---
- 型名（クラス、構造体、列挙型）、ファイル名：パスカルケース
~~~
class PlayerMove;
struct PlayerData;
PlayerMove.cs
~~~

---
- メンバ変数：アンダーバー始まりのキャメルケース
~~~
private int _moveSpeed;
~~~

---
- プロパティ：パスカルケース
~~~
public int MoveSpeed { get; }

private int _jumpPower;   // メンバ変数なので、メンバ変数のルール
public int JumpPower { get { return _jumpPower; }; }
~~~

---
- メソッド：キャメルケース
~~~
public int getMoveSpeed() { return _moveSpeed; }
~~~

---
- ローカル変数：アンダーバー終わりのキャメルケース
~~~
int moveSpeed_;
~~~

---
---
- 担当

> 実際のゲームで使用するシーンとは別に、  
> 個人の作業専用シーンとフォルダを用意しています。  
> 普段の制作では、そちらを利用するようにしてください。  
> 個人のフォルダ内であれば、好きなように使ってかまいません。

> タイトル、リザルトなど、単体で制作可能なシーンを担当する場合は、  
> 担当しているシーンを直接変更してもかまいません。

---
- プレハブの管理

> 各シーンごとに、プレハブ管理用のフォルダを用意しています。  
> 作った `GameObject` は必ずプレハブ化してください。  
> 自分が担当しているシーンと同じフォルダに、作ったプレハブを保存してください。

---
- プレハブ管理の注意点

> プレハブの中身をネストしすぎないようにしてください。  
> 深い部分にあるデータの編集がしにくくなるためです。  

> 別のプレハブを含めたプレハブを作らないようにしてください。  
> もともと作っていたほうのプレハブのリンクが壊れてしまうためです。

---
- スクリプトについて

> 個人の作業用フォルダ内に作って大丈夫です。  
> どこに何があるか、わかりやすくなるように管理してもらえると助かります。

---
#### 参考リンク

Unity  Android実機テストの方法
- [Qiita: Unity Remote4を使った実機テストの方法][Link_qiita]

Unity  Android実機テストのために準備するもの
- [Android SDK (SDK Tools Only)][Link_AndroidSDK]  
> **他のダウンロードオプション** を選択、  
> `Windows` の欄から、`.exe` のほうをダウンロードして実行してください

- [Java SE Development Kit(x64)][Link_JDK]  
> `Accept Lisence ...` にチェックを入れてから、  
> `Windows-x64.exe` をダウンロードして実行してください

---

[Link_qiita]: http://qiita.com/cabbage/items/783142ba7d75f32299ad
[Link_AndroidSDK]: http://developer.android.com/intl/ja/sdk/index.html
[Link_JDK]: http://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html

