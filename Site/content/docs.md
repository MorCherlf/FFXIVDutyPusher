---
date: '2025-06-14T02:10:00+03:00'
title: 'Setting Guide'
---

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

Currently, DutyPusher supports the following push channels: **Bark**, **PushDeer**, **Telegram Bot Official API**, and **Ntfy.sh**.

**If you would like to add support for a new platform, please submit an Issue to this repository.**

Repo Links: [Bark](https://github.com/Finb/Bark) | [PushDeer](https://github.com/easychen/pushdeer)

Telegram Bot: [Telegram Bot API](https://core.telegram.org/bots/api)

Ntfy.sh: [Ntfy.sh Official Site](https://ntfy.sh/)

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

### Ntfy.sh Configuration

You can access the Ntfy.sh application from: [Ntfy.sh Official Site](https://ntfy.sh/)

Official Documents：[Ntfy.sh Official Documents](https://docs.ntfy.sh/subscribe/phone/#overview)

The document of this part is to be done, please using with the discription in the game plugin.

P.S. If you are using Ntfy.sh Official Server, please choose an unique topic as your notification topic.