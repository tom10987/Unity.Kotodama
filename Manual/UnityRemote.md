
### Android 向けビルド環境の準備

`Unity` で `Android` 向けビルドをできるようにするには、下記２点が必須となります。  
- **`Java SE Development Kit`**
- **`Android SDK`**

**インストールは、必ず `Java` から始めてください。**  
`Android SDK` が `Java` に依存しているため、インストール時に `Java` のフォルダを検索するためです。

---
#### `Java SE Development Kit`
[**こちらのページ**][Link_JDK]に移動、リンク先の `JDK` のダウンロードボタンをクリックしてください。

プラットフォームごとのダウンロード一覧が表示されるので、  
`Java SE Development Kit ****` にある `Accept License Agreement` の項目にチェックを入れてから、  
`Windows x64` の項目にあるダウンロードリンクよりファイルをダウンロードしてください。

> `****` は、バージョン番号が表示されます。  
> `8u60` であれば、問題ありません。

ダウンロードしたファイルを実行、インストールが完了したら `Finish` をクリックして大丈夫です。

---
#### `Android SDK`
[**こちらのページ**][Link_AndroidSDK]に移動、リンク先の **他のダウンロードオプション** をクリックしてください。

`SDK Tools Only` の `Windows` の項目から、`.exe` 形式のファイルをダウンロードしてください。  
実行すると、`SDK Manager` のインストールが開始されます。  
**保存先のフォルダをメモに残すなど、必ず覚えておいてください。**

保存先のフォルダを開き、`SDK Manager.exe` を **右クリックして、「管理者として実行」** を選択してください。

すでにいくつかの項目にチェックが入っているはずなので、  
そのまま画面右下のほうにある `Install` をクリックしてインストール開始です。  
元の画面に戻ったときに、チェックの入っていた項目が全て `Installed` に変わっていたら大丈夫です。

---
#### `Unity Editor` 側の設定

---
#### 参考リンク

- [Qiita: Unity Remote4 を使った実機テストの方法][Link_qiita]  
- [Java SE Downloads][Link_JDK]  
- [Android SDK][Link_AndroidSDK]

---

[Link_qiita]: http://qiita.com/cabbage/items/783142ba7d75f32299ad
[Link_JDK]: http://www.oracle.com/technetwork/java/javase/downloads/index.html
[Link_AndroidSDK]: http://developer.android.com/intl/ja/sdk/index.html

