# 狒狒排本小助手
这是一个**最终幻想14**的Dalamud(卫月)插件
可以当你游戏内任务器搜索到任务时，给你的设备发送一则通知

## 仓库链接

    https://raw.githubusercontent.com/MorCherlf/FFXIVDutyPusher/master/Release/DutyPusher.json
请将此链接复制到Dalamud的Custom Plugin Repositories中，点击后面的加号并保存设置

**请不要使用来源不明的仓库链接及插件，可能会损害您的账号财产安全！！！**
**任何第三方插件都可能导致您的账号遭到封禁，请您使用前知悉！！！**
**不要将您的插件配置文件发送给任何人，如因此造成的损失，请您自己承担！！！**

## 插件安装
**在使用本插件过程中遇到了问题，请不要向Dalamud发送反馈！！！**
首先请你确认是否已使用Dalamud 
如需使用Dalamud，最简单的方法是使用XIVLanucher启动游戏
[XIVLanucher](https://goatcorp.github.io/)  [XIVLanucher CN](https://ottercorp.github.io/)

打开Dalamud的设置页面
点击选项卡*测试版*
在自定义插件仓库中，将仓库链接复制到URL列表中，点击后面的加号和页面上的保存按钮
之后，打开插件中心，搜索DutyPusher安装就完成了

在插件中心点击DutyPusher的设置按钮或是在游戏内输入/dutypusher指令均可打开DutyPusher的设置页面

## 手机配置
目前狒狒排本小助手支持**Bark**和**PushDeer**两个推送渠道，其两者日前均仅支持iOS/iPadOS/macOS端
Github 链接： [Bark](https://github.com/Finb/Bark) [PushDeer](https://github.com/easychen/pushdeer)
**在使用本插件过程中遇到了问题，请不要向Bark/PushDeer发送反馈！！！**
**请不要把您的渠道URL/Key泄露给任何人！！！**
### Bark配置
请在App Store中搜索Bark并安装 
打开Bark后首先请点击注册设备，并允许其发送通知
打开DutyPusher的设置页面，推送渠道选择Bark
![Bark界面](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/bark.jpg?raw=true)
将Bark中的第一条链接复制并粘贴到DutyPusher插件设置中的渠道URL/Key中，点击保存即可开始使用

> 可选配置
> 可以勾选时效通知，即使在您的设备开启专注模式后仍会收到推送
> 可以在Bark中点击**查看所有铃声**并导入[排本音效](https://github.com/MorCherlf/FFXIVDutyPusher/raw/master/Resources/ff14.caf)，请将铃声命名为ff14.caf后导入

### PushDeer配置
iOS/iPadOS (14+)
请使用系统相机扫描此轻App码即可开始使用PushDeer
![enter image description here](https://github.com/easychen/pushdeer/raw/main/doc/image/clipcode.png)
或在App Store中搜索PushDeer并安装

![PushDeer设备界面](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/pushdeer-device.jpg?raw=true)
打开PushDeer后首先请在设备选项卡中点击右上角加号，并允许其发送通知
打开DutyPusher的设置页面，推送渠道选择PushDeer
![PushDeerKey界面](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/pushdeer-key.jpg?raw=true)
点击PushDeer选项卡Key，将您的Key复制并粘贴到DutyPusher插件设置中的渠道URL/Key中，点击保存即可开始使用
