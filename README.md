# DutyPusher

![Logo](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/icon.png?raw=true)

------

## Whats DutyPusher?

This is a **Final Fantasy XIV** Dalamud plugin.

When you enable this plugin and configure a push channel, it will send a notification to your device when a duty queue is ready in the game.

## Notice

**To ensure the safety of your account, please avoid using repository links and plugins from untrusted sources.**

**Using any third-party plugins may result in your account being banned. Please be aware of this before using the plugin.**

**Do not share your plugin configuration file with anyone. You are solely responsible for any losses caused by this.**

**If you encounter any issues while using this plugin, please do not send feedback to Dalamud.**

Download Count in Dalamud: ![Downloads](https://img.shields.io/badge/downloads-751-brightgreen)

------

## Plugin Settings

You can open the DutyPusher settings page in one of the following ways:

1. Click the DutyPusher settings button in the Plugin Center.
2. Enter the `/dutypusher` command in the game.

![Plugin Settings](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/settings-en.png?raw=true)

First, select the push channel you want to use from the dropdown menu.

Then, fill in the required Token/URL/Key for the selected push channel, enable the plugin, and save the settings to start using it.

After configuring the push channel, you can check the activation status of DutyPusher in the **DTR Bar** at the top-right corner of the game’s main interface. Click the status icon to toggle it on or off.

![DTRBar](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/dtrbar-en.png?raw=true)

## Push Channel Configuration

Currently, DutyPusher supports the following push channels: **Bark**, **PushDeer**, and **Telegram Bot Official API**.

**If you would like to add support for a new platform, please submit an Issue to this repository.**

Repo Links: [Bark](https://github.com/Finb/Bark) | [PushDeer](https://github.com/easychen/pushdeer)

Telegram Bot: [Telegram Bot API](https://core.telegram.org/bots/api)

**If you encounter any issues while using this plugin, please do not send feedback to any push channel/platform.**

**Do not share your channel URL/Key with anyone!**

### Bark Configuration

Search for **Bark** in the App Store and install it.

Open the Bark app, click **Register Device**, and allow it to send notifications.

![Bark Interface](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/bark-en.jpg?raw=true)

Copy the first URL in Bark and paste it into the Channel URL/Key field in the DutyPusher settings. Click **Save** to start using it.

> Optional Configurations
>
> - You can enable **Time Sensitive Notifications** in the plugin settings to receive push notifications even when your device is in Focus Mode.
> - In Bark, click **View All Sounds** and import this [Duty Sound](https://github.com/MorCherlf/FFXIVDutyPusher/raw/master/Resources/ff14.caf). Make sure to rename the file to `ff14.caf` before importing it.

### PushDeer Configuration

iOS/iPadOS (14+)

Use your system camera to scan the App Clip Code below to start using PushDeer.

![App Clip Code](https://github.com/easychen/pushdeer/raw/main/doc/image/clipcode.png)

Alternatively, search for **PushDeer** in the App Store and install it.

![PushDeer Device Interface](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/pushdeer-device-en.png?raw=true)

Open the PushDeer app, go to the **Devices** tab, click the plus (+) button in the top-right corner, and allow it to send notifications.

![PushDeer Key Interface](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/pushdeer-key-en.jpg?raw=true)

Go to the **Key** tab in PushDeer, copy your key, and paste it into the Channel URL/Key field in the DutyPusher settings. Click **Save** to start using it.

### Telegram Bot Official API Configuration

Official Documentation: [Telegram Bot API](https://core.telegram.org/bots#how-do-i-create-a-bot)

**The following steps may change at any time. Please refer to the official Telegram documentation for the latest instructions.**

#### Creating a Bot

1. Use your Telegram account to send the `/start` command to [@BotFather](https://t.me/botfather).
2. Then send the `/newbot` command and follow the instructions to set a name and username for your bot.
3. You will receive detailed information about your bot, including a link to your bot (starting with `t.me/`) and a token (starting with numbers: `0000000000:xxxxxxxxxxxxxxxxxxxxxxxxxxxx`).

#### Plugin Settings

![Telegram Settings](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/settings-en-telegram.png?raw=true)

1. Send the `/start` command to your newly created bot in Telegram.
2. Copy the token provided by BotFather and paste it into the Token field in the DutyPusher settings. Click **Get Chat ID** and wait for the Chat ID to be automatically filled.
3. Once the Chat ID is retrieved, click **Test** to confirm that you can receive a message from your bot in Telegram. If everything works, click **Save** to start using it.

> [!TIP]
>
> If the plugin cannot automatically retrieve your Chat ID, try the following steps:
>
> 1. Ensure the token is entered correctly.
> 2. Send any message to your bot and try retrieving the Chat ID again.
>
> If the above steps do not work:
>
> 1. Open your browser and visit the following URL:
>    `https://api.telegram.org/bot$YOUR_BOT_TOKEN_HERE/getUpdates`
>    Note: Replace `$YOUR_BOT_TOKEN_HERE` with your bot token.
> 2. Locate the `message` -> `chat` -> `id` field in the JSON response and copy it into the Chat ID field in the plugin settings.

------

## Frequently Asked Questions (FAQ)

- **Q: Why am I not receiving push notifications?**
  A: Please check if the push channel is configured correctly and ensure that your device allows notifications.

- **Q: How do I uninstall the plugin?**
  A: Find DutyPusher in the Plugin Center, disable it, and then click the **Delete** button.

- **Q: Can you add support for [X] push channel?**
  A: Please submit an Issue to this repository with the push channel name/platform, and we will try to add it to the plugin.

------

## About DutyPusher

DutyPusher is an open-source Dalamud plugin developed by MorCherlf for *Final Fantasy XIV* (FFXIV). It aims to help players relax away from their computers while waiting in queue for dungeons. By utilizing multiple extensible push channels, players can receive immediate notifications when their queue pops, ensuring they never miss a dungeon.

**Key Features**

- **Multiple Push Channels Supported**: Currently supports Bark, PushDeer, and Telegram Bot official APIs, with plans to expand to more push channels in the future.
- **Instant Notifications**: When your dungeon queue pops, DutyPusher will immediately send a notification to your device.
- **Easy to Use**: Simple setup allows you to start using it right away.
- **Customizable Options**: Supports custom notification sounds and instant notifications (Bark).
- **Fully Open Source**: DutyPusher is fully open source. You can create your own fork or submit a Pull Request to us.
- **As Safe as Possible**: DutyPusher does not interact with the game server or directly modify/operate the game in any way. Except for sending notifications, which requires network requests to the respective push channel servers, it does not collect, record, or store any information.

## About the Developer

Hello, I’m [MorCherlf](https://link.mor.icu). I’m a programmer, gamer, music enthusiast, Furry, and more…

This is my first Dalamud plugin. If you have any suggestions or questions, feel free to submit an Issue or Pull Request on [GitHub](https://github.com/MorCherlf/FFXIVDutyPusher).

If you have any questions, you can also reach me via [email](mailto:morcherlfy@outlook.com).

## Copyright and Disclaimer

### Copyright Notice

1. **Open Source License**
   This plugin is open source under the [AGPL-3.0 License](https://www.gnu.org/licenses/agpl-3.0.html). You are free to use, modify, and distribute this plugin, provided you comply with the terms of the AGPL-3.0 license.

2. **Website Generation and Theme**
   This website is generated by [Hugo](https://gohugo.io/), and the theme is based on [hextra](https://github.com/imfing/hextra).

3. **Push Channels**
   The push channels used by this plugin are provided by their respective platforms/service providers, including but not limited to Bark, PushDeer, and Telegram Bot. These platforms/service providers retain independent intellectual property rights and responsibilities for their services.

4. **FINAL FANTASY Trademark**
   FINAL FANTASY is a registered trademark of Square Enix Holdings Co., Ltd. FINAL FANTASY XIV © 2010-2022 SQUARE ENIX CO., LTD. All rights reserved.
   **We are not affiliated with SQUARE ENIX CO., LTD.**

### Disclaimer

1. **Plugin Usage Risks**
   By using this plugin, you acknowledge and agree to the Terms of Service of *Final Fantasy XIV* (FFXIV).
   Please note that, technically, this plugin may violate FFXIV’s Terms of Service, even though we do not perform any automated operations or modifications to the game.
   You assume all risks associated with using this plugin, including but not limited to account suspension, data loss, or other consequences.

2. **Limitation of Liability**
   The developers and contributors of this plugin are not responsible for any direct or indirect damages arising from the use of this plugin, including but not limited to game account suspension, data loss, device damage, or other legal or financial liabilities.

3. **Use at Your Own Risk**
   By using this plugin, you acknowledge and accept the risks mentioned above and agree to bear all possible consequences. We recommend using the plugin cautiously and adhering to FFXIV’s Terms of Service.


------



# 狒狒排本小助手

![Logo](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/icon.png?raw=true)

------

## 这是什么？

这是一个**最终幻想14**的Dalamud(卫月)插件

当您启用此插件并配置好推送通道后，游戏内任务器搜索到任务时，此插件将会通过配置好的推送通道向您的设备发送一则通知

## 注意事项

**为了保障您的账号安全，请避免使用来源不明的仓库链接及插件。**

**任何第三方插件都可能导致您的账号遭到封禁，请您使用前知悉**

**不要将您的插件配置文件发送给任何人，如因此造成的损失，请您自己承担**

**在使用本插件过程中遇到了问题，请不要向Dalamud发送反馈**

Dalamud 中的下载量: ![Downloads](https://img.shields.io/badge/downloads-751-brightgreen)

------

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

------

## 常见问题（FAQ）

- **Q：为什么我收不到推送通知？**
  A：请检查推送渠道的配置是否正确，并确保您的设备已允许接收通知
- **Q：如何卸载插件？**
  A：在插件中心找到DutyPusher，禁用插件后点击删除按钮即可
- **Q：能不能添加xx推送渠道？**
  A：请在此Repo中提交Issue，请提供推送渠道名称/平台，我会尝试将其添加到插件中


------

## 关于狒狒排本小助手

狒狒排本小助手由MorCherlf开发的一款适用于《最终幻想XIV》FF14 的Dalamud开源插件，旨在帮助玩家在排队等待副本时远离电脑放松一下，通过可扩展的多种推送渠道，让玩家可以在排队成功时立即收到提醒，避免错过副本。

**主要特点**

- **多推送渠道支持**：目前支持Bark、PushDeer和Telegram Bot官方API，未来将持续拓展更多推送渠道。
- **即时通知**：当副本排队成功时，狒狒排本小助手会立即发送通知到您的设备。
- **简单易用**：只需简单设置即可开始使用。
- **自定义选项**：支持自定义通知音效和即时通知（Bark）。
- **完全开源**: 狒狒排本小助手完全开源，你可以创建属于你自己的分支，或向我们提交Pull Request。
- **尽可能安全**：狒狒排本小助手不与游戏服务器进行任何交互，也不直接对游戏进行任何修改/操作，除发送通知时会与对应推送渠道的服务器发送网络请求外，不收集/记录/保存任何信息

## 关于开发者

你好，我是[MorCherlf](https://link.mor.icu)，我是一名程序员/游戏玩家/音乐爱好者/Furry/……

这是我开发的第一款Dalamud 插件，如果您有任何建议或问题，欢迎在[Github](https://github.com/MorCherlf/FFXIVDutyPusher)上提交Issue或是Pull Request。

如果您有任何问题，欢迎向我发送[邮件](mailto:morcherlfy@outlook.com)

## 版权声明与免责声明

### 版权声明

1. **开源协议**
    本插件基于 [AGPL-3.0 License](https://www.gnu.org/licenses/agpl-3.0.html) 开源。您可以自由使用、修改和分发本插件，但需遵守 AGPL-3.0 协议的相关规定。
2. **网页生成与主题**
    本网页生成由 [Hugo](https://gohugo.io/) 提供，页面主题基于 [hextra](https://github.com/imfing/hextra) 构建。
3. **推送渠道**
    本插件使用的推送渠道由各自推送平台/服务商提供，包括但不限于 Bark、PushDeer 和 Telegram Bot。这些平台/服务商对其提供的服务拥有独立的知识产权和责任。
4. **FINAL FANTASY 商标**
    FINAL FANTASY 是 Square Enix Holdings Co., Ltd. 的注册商标。FINAL FANTASY XIV © 2010-2022 SQUARE ENIX CO., LTD. 保留所有权利。
    **我们与 SQUARE ENIX CO., LTD. 没有任何关联。**

### 免责声明

1. **插件使用风险**
    使用此插件默认您了解并同意《最终幻想14》（FFXIV）的服务条款。
    请注意，从技术上讲，该插件可能违反了 FFXIV 的服务条款，即使我们没有对游戏进行自动化操作或修改。
    您应自行承担使用本插件可能带来的风险，包括但不限于账号封禁、数据丢失或其他后果。
2. **责任限制**
    本插件的开发者及贡献者不对因使用本插件而产生的任何直接或间接损失负责，包括但不限于游戏账号封禁、数据丢失、设备损坏或其他法律或财务责任。
3. **自行承担风险**
    使用本插件即表示您已知晓并接受上述风险，并同意自行承担所有可能的后果。我们建议您在使用插件时谨慎行事，并遵守 FFXIV 的服务条款。

