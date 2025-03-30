---
date: '2025-03-30T11:27:58+03:00'
title: '設定指南'
---

## 插件設定

您可以通過以下兩種方式打開DutyPusher的設定頁面：

1. 在插件中心點擊DutyPusher的設定按鈕。
2. 在遊戲內輸入`/dutypusher`指令。

![插件設定](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/settings-tw.png?raw=true)

首先，在下拉選單中選擇你想使用的推送渠道

然後在下方填寫該推送渠道所需的Token/URL/Key等內容，勾選啟用並儲存就可以開始使用了

配置好推送渠道後，您可以在遊戲主頁面右上方的**DTR Bar**中查看狒狒排本小助手的啟用狀態。點擊狀態圖標即可切換啟用或禁用狀態。

![DTRBar](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/dtrbar-tw.png?raw=true)

## 推送通道配置

目前狒狒排本小助手支援**Bark**，**PushDeer**，和**Telegram Bot 官方API**推送渠道

**如果想要增加某一平台的推送渠道，可以向此倉庫提交Issue**

Repo 連結： [Bark](https://github.com/Finb/Bark) [PushDeer](https://github.com/easychen/pushdeer)

Telegram Bot：[Telegram Bot API](https://core.telegram.org/bots/api)

**在使用本插件過程中遇到了問題，請不要向任一推送渠道/平台發送反饋**

**請不要把您的渠道URL/Key洩露給任何人！**

### Bark配置

請在App Store中搜索Bark並安裝 

打開Bark應用後，首先點擊**註冊設備**，並允許其發送通知。

![Bark界面](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/bark.jpg?raw=true)

將Bark中的第一條連結複製並貼上到DutyPusher插件設定中的渠道URL/Key中，點擊儲存即可開始使用

> 可選配置
>
> - 您可以在插件設定中勾選上時效通知，這樣即使在您的設備開啟專注模式時仍會收到排本推送
> - 您可以在Bark中點擊**查看所有鈴聲**，然後導入此[排本音效](https://github.com/MorCherlf/FFXIVDutyPusher/raw/master/Resources/ff14.caf)。請確保將鈴聲文件命名為`ff14.caf`後再導入。

### PushDeer配置

iOS/iPadOS (14+)

請使用系統相機掃描此輕App碼即可開始使用PushDeer

![enter image description here](https://github.com/easychen/pushdeer/raw/main/doc/image/clipcode.png)

或在App Store中搜索PushDeer並安裝

![PushDeer設備界面](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/pushdeer-device.jpg?raw=true)

打開PushDeer應用後，首先進入**設備**選項卡，點擊右上角的加號（+）按鈕，並允許其發送通知。

![PushDeerKey界面](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/pushdeer-key.jpg?raw=true)

點擊PushDeer選項卡Key，將您的Key複製並貼上到插件設定中的渠道URL/Key中，點擊儲存即可開始使用

### Telegram Bot Official API 配置

官方參考說明：[Telegram Bot API 文件](https://core.telegram.org/bots#how-do-i-create-a-bot)

**以下步驟可能隨時會更改，請以Telegram 官方說明為準**

#### 創建Bot

1. 使用你的Telegram 帳號向 [@BotFather](https://t.me/botfather) 發送`/start`指令
2. 然後再向其發送`/newbot`指令，根據其提示給你的Bot設置名字和username
3. 接下來你將收到關於你的Bot的詳細信息，其中包含一個指向你創建的Bot的連結`以t.me/開頭`，一串以數字開頭的Token`0000000000:xxxxxxxxxxxxxxxxxxxxxxxxxxxx`

#### 插件設定

![Telegram設定](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/settings-tw-telegram.png?raw=true)

1. 在Telegram中向你剛剛創建的Bot發送`/start`指令
2. 將BotFather發送的Token複製並貼上到插件設定中的Token中，點擊`取得 ChatID`後，等待Chat ID 中自動填充你的Chat ID
3. 當自動獲取到Chat ID後，點擊`測試`，確認是否能在你的Telegram帳號中接收到來自你剛剛創建的Bot的消息，如果一切正常點擊儲存後即可開始使用

> [!TIP]
>
> 如果插件無法自動獲取到您的Chat ID，請嘗試以下步驟：
>
> 1. 確認Token填寫正確
> 2. 向你創建的Bot發送任一消息後，再次嘗試獲取
>
> 如果以上步驟均無效：
>
> 1. 打開瀏覽器訪問以下URL：
>     `https://api.telegram.org/bot$YOUR_BOT_TOKEN_HERE/getUpdates`
>     注意：請將`$YOUR_BOT_TOKEN_HERE`替換為您的Bot Token。
> 2. 查看獲取到的JSON文本，定位到`message`-`chat`-`id`，並將其複製到插件設定中的Chat ID中即可