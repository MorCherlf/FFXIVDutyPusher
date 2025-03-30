---
date: '2025-03-30T11:27:58+03:00'
draft: true
title: '設定ガイド'
---

## プラグイン設定

DutyPusherの設定ページは以下の方法で開くことができます:

1. プラグインセンターでDutyPusherの設定ボタンをクリックする。
2. ゲーム内で`/dutypusher`コマンドを入力する。

![プラグイン設定](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/settings-ja.png?raw=true)

まず、ドロップダウンメニューから使用したいプッシュチャネルを選択してください。

次に、選択したプッシュチャネルに必要なToken/URL/Keyを入力し、プラグインを有効にして設定を保存すると使用を開始できます。

プッシュチャネルの設定が完了したら、ゲームのメインインターフェースの右上にある**DTR Bar**でDutyPusherの有効状態を確認できます。ステータスアイコンをクリックして有効/無効を切り替えてください。

![DTRBar](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/dtrbar-ja.png?raw=true)

## プッシュチャネル設定

現在、DutyPusherは以下のプッシュチャネルをサポートしています: **Bark**、**PushDeer**、**Telegram Bot公式API**。

**新しいプラットフォームのサポートを追加したい場合は、このリポジトリにIssueを提出してください。**

リポジトリリンク: [Bark](https://github.com/Finb/Bark) | [PushDeer](https://github.com/easychen/pushdeer)

Telegram Bot: [Telegram Bot API](https://core.telegram.org/bots/api)

**このプラグインの使用中に問題が発生した場合、プッシュチャネル/プラットフォームにフィードバックを送信しないでください。**

**チャネルURL/Keyを他人と共有しないでください！**

### Bark設定

App Storeで**Bark**を検索してインストールしてください。

Barkアプリを開き、**Register Device**をクリックして通知の送信を許可します。

![Barkインターフェース](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/bark-ja.jpg?raw=true)

Barkの最初のURLをコピーし、DutyPusher設定のChannel URL/Key欄に貼り付けて、**Save**をクリックすると使用を開始できます。

> オプション設定
>
> - プラグイン設定で**Time Sensitive Notifications**を有効にすると、デバイスがフォーカスモード中でもプッシュ通知を受信できます。
> - Barkで**View All Sounds**をクリックし、[このダンジョン音](https://github.com/MorCherlf/FFXIVDutyPusher/raw/master/Resources/ff14.caf)をインポートしてください。インポート前にファイル名を`ff14.caf`に変更してください。

### PushDeer設定

iOS/iPadOS (14+)

システムカメラで以下のApp ClipコードをスキャンしてPushDeerを使用開始できます。

![App Clipコード](https://github.com/easychen/pushdeer/raw/main/doc/image/clipcode.png)

または、App Storeで**PushDeer**を検索してインストールしてください。

![PushDeerデバイスインターフェース](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/pushdeer-device-en.png?raw=true)

PushDeerアプリを開き、**Devices**タブで右上のプラス（+）ボタンをクリックして通知の送信を許可します。

![PushDeerキーインターフェース](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/pushdeer-key-en.jpg?raw=true)

PushDeerの**Key**タブでキーをコピーし、DutyPusher設定のChannel URL/Key欄に貼り付けて、**Save**をクリックすると使用を開始できます。

### Telegram Bot公式API設定

公式ドキュメント: [Telegram Bot API](https://core.telegram.org/bots#how-do-i-create-a-bot)

**以下の手順は変更される可能性があります。最新の手順についてはTelegramの公式ドキュメントを参照してください。**

#### Botの作成

1. Telegramアカウントで[@BotFather](https://t.me/botfather)に`/start`コマンドを送信します。
2. 次に`/newbot`コマンドを送信し、指示に従ってBotの名前とユーザー名を設定します。
3. Botの詳細情報が送信されます。これにはBotへのリンク（`t.me/`で始まる）とトークン（数字で始まる: `0000000000:xxxxxxxxxxxxxxxxxxxxxxxxxxxx`）が含まれます。

#### プラグイン設定

![Telegram設定](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/settings-ja-telegram.png?raw=true)

1. Telegramで新しく作成したBotに`/start`コマンドを送信します。
2. BotFatherから提供されたトークンをコピーし、DutyPusher設定のToken欄に貼り付けます。**Get Chat ID**をクリックし、Chat IDが自動的に入力されるのを待ちます。
3. Chat IDが取得されたら、**Test**をクリックしてTelegramでBotからのメッセージを受信できるか確認します。すべて正常に動作する場合、**Save**をクリックして使用を開始できます。

> [!TIP]
>
> プラグインが自動的にChat IDを取得できない場合、以下の手順を試してください:
>
> 1. トークンが正しく入力されていることを確認します。
> 2. Botに任意のメッセージを送信し、再度Chat IDを取得してみます。
>
> 上記の手順でも解決しない場合:
>
> 1. ブラウザで以下のURLにアクセスします:
>    `https://api.telegram.org/bot$YOUR_BOT_TOKEN_HERE/getUpdates`
>    注: `$YOUR_BOT_TOKEN_HERE`をBotのトークンに置き換えてください。
> 2. JSONレスポンス内の`message` -> `chat` -> `id`フィールドを見つけ、プラグイン設定のChat ID欄にコピーします。