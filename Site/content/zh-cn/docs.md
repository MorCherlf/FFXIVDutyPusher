---
date: '2025-03-30T11:27:58+03:00'
title: '设置指南'
---

## 插件设置

您可以通过以下两种方式打开DutyPusher的设置页面：

1. 在插件中心点击DutyPusher的设置按钮。
2. 在游戏内输入`/dutypusher`指令。

![插件设置](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/settings-zh-cn.png?raw=true)

首先，在下拉菜单中选择你想使用的推送渠道

然后在下方填写该推送渠道所需的Token/URL/Key等内容，勾选启用并保存就可以开始使用了

配置好推送渠道后，您可以在游戏主页面右上方的**DTR Bar**中查看狒狒排本小助手的启用状态。点击状态图标即可切换启用或禁用状态。

![DTRBar](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/dtrbar-en.png?raw=true)

## 推送通道配置

目前狒狒排本小助手支持**Bark**，**PushDeer**，和**Telegram Bot 官方API**推送渠道

**如果想要增加某一平台的推送渠道，可以向此仓库提交Issue**

Repo 链接： [Bark](https://github.com/Finb/Bark) [PushDeer](https://github.com/easychen/pushdeer)

Telegram Bot：[Telegram Bot API](https://core.telegram.org/bots/api)

**在使用本插件过程中遇到了问题，请不要向任一推送渠道/平台发送反馈**

**请不要把您的渠道URL/Key泄露给任何人！**

### Bark配置

请在App Store中搜索Bark并安装 

打开Bark应用后，首先点击**注册设备**，并允许其发送通知。

![Bark界面](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/bark.jpg?raw=true)

将Bark中的第一条链接复制并粘贴到DutyPusher插件设置中的渠道URL/Key中，点击保存即可开始使用

> 可选配置
>
> - 您可以在插件设置中勾选上时效通知，这样即使在您的设备开启专注模式时仍会收到排本推送
> - 您可以在Bark中点击**查看所有铃声**，然后导入此[排本音效](https://github.com/MorCherlf/FFXIVDutyPusher/raw/master/Resources/ff14.caf)。请确保将铃声文件命名为`ff14.caf`后再导入。

### PushDeer配置

iOS/iPadOS (14+)

请使用系统相机扫描此轻App码即可开始使用PushDeer

![enter image description here](https://github.com/easychen/pushdeer/raw/main/doc/image/clipcode.png)

或在App Store中搜索PushDeer并安装

![PushDeer设备界面](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/pushdeer-device.jpg?raw=true)

打开PushDeer应用后，首先进入**设备**选项卡，点击右上角的加号（+）按钮，并允许其发送通知。

![PushDeerKey界面](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/pushdeer-key.jpg?raw=true)

点击PushDeer选项卡Key，将您的Key复制并粘贴到插件设置中的渠道URL/Key中，点击保存即可开始使用



### Telegram Bot Official API 配置

官方参考说明：[Telegram Bot API 文档](https://core.telegram.org/bots#how-do-i-create-a-bot)

**以下步骤可能随时会更改，请以Telegram 官方说明为准**

#### 创建Bot

1. 使用你的Telegram 账号向 [@BotFather](https://t.me/botfather) 发送`/start`指令
2. 然后再向其发送`/newbot`指令，根据其提示给你的Bot设置名字和username
3. 接下来你将收到关于你的Bot的详细信息，其中包含一个指向你创建的Bot的链接`以t.me/开头`，一串以数字开头的Token`0000000000:xxxxxxxxxxxxxxxxxxxxxxxxxxxx`

#### 插件设置

![Telegram设置](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/settings-zh-cn-telegram.png?raw=true)

1. 在Telegram中向你刚刚创建的Bot发送`/start`指令
2. 将BotFather发送的Token复制并粘贴到插件设置中的Token中，点击`获取 ChatID`后，等待Chat ID 中自动填充你的Chat ID
3. 当自动获取到Chat ID后，点击`测试`，确认是否能在你的Telegram账号中接收到来自你刚刚创建的Bot的消息，如果一切正常点击保存后即可开始使用

> [!TIP]
>
> 如果插件无法自动获取到您的Chat ID，请尝试以下步骤：
>
> 1. 确认Token填写正确
> 2. 向你创建的Bot发送任一消息后，再次尝试获取
>
> 如果以上步骤均无效：
>
> 1. 打开浏览器访问以下URL：
>     `https://api.telegram.org/bot$YOUR_BOT_TOKEN_HERE/getUpdates`
>     注意：请将`$YOUR_BOT_TOKEN_HERE`替换为您的Bot Token。
> 2. 查看获取到的JSON文本，定位到`message`-`chat`-`id`，并将其复制到插件设置中的Chat ID中即可