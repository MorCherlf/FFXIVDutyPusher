---
date: '2025-03-30T11:27:58+03:00'
draft: true
title: '설정 가이드'
---

## 플러그인 설정

DutyPusher 설정 페이지는 다음 방법 중 하나로 열 수 있습니다:

1. 플러그인 센터에서 DutyPusher 설정 버튼을 클릭합니다.
2. 게임 내에서 `/dutypusher` 명령어를 입력합니다.

![플러그인 설정](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/settings-ko.png?raw=true)

먼저, 드롭다운 메뉴에서 사용할 푸시 채널을 선택합니다.

그런 다음, 선택한 푸시 채널에 필요한 Token/URL/Key를 입력하고, 플러그인을 활성화한 후 설정을 저장하여 사용을 시작합니다.

푸시 채널을 구성한 후, 게임 메인 인터페이스의 오른쪽 상단에 있는 **DTR Bar**에서 DutyPusher의 활성화 상태를 확인할 수 있습니다. 상태 아이콘을 클릭하여 활성화 또는 비활성화를 전환할 수 있습니다.

![DTRBar](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/dtrbar-en.png?raw=true)

## 푸시 채널 구성

현재 DutyPusher는 다음 푸시 채널을 지원합니다: **Bark**, **PushDeer**, **Telegram Bot Official API**.

**새로운 플랫폼 지원을 추가하고 싶다면, 이 저장소에 Issue를 제출해 주세요.**

저장소 링크: [Bark](https://github.com/Finb/Bark) | [PushDeer](https://github.com/easychen/pushdeer)

Telegram Bot: [Telegram Bot API](https://core.telegram.org/bots/api)

**이 플러그인 사용 중 문제가 발생하면 어떤 푸시 채널/플랫폼에도 피드백을 보내지 마십시오.**

**채널 URL/Key를 다른 사람과 공유하지 마십시오!**

### Bark 구성

App Store에서 **Bark**를 검색하여 설치합니다.

Bark 앱을 열고, **Register Device**를 클릭한 후 알림 전송을 허용합니다.

![Bark 인터페이스](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/bark-en.jpg?raw=true)

Bark에서 첫 번째 URL을 복사하여 DutyPusher 설정의 Channel URL/Key 필드에 붙여넣습니다. **저장**을 클릭하여 사용을 시작합니다.

> 선택적 구성
>
> - 플러그인 설정에서 **시간 민감 알림**을 활성화하여 기기가 Focus 모드일 때도 푸시 알림을 받을 수 있습니다.
> - Bark에서 **View All Sounds**를 클릭하고 이 [Duty 사운드](https://github.com/MorCherlf/FFXIVDutyPusher/raw/master/Resources/ff14.caf)를 가져옵니다. 파일을 `ff14.caf`로 이름을 변경한 후 가져오는 것을 확인하세요.

### PushDeer 구성

iOS/iPadOS (14+)

시스템 카메라를 사용하여 아래 App Clip 코드를 스캔하여 PushDeer 사용을 시작합니다.

![App Clip 코드](https://github.com/easychen/pushdeer/raw/main/doc/image/clipcode.png)

또는 App Store에서 **PushDeer**를 검색하여 설치합니다.

![PushDeer 디바이스 인터페이스](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/pushdeer-device-en.png?raw=true)

PushDeer 앱을 열고, **Devices** 탭으로 이동한 후 오른쪽 상단의 더하기 (+) 버튼을 클릭하여 알림 전송을 허용합니다.

![PushDeer Key 인터페이스](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/pushdeer-key-en.jpg?raw=true)

PushDeer에서 **Key** 탭으로 이동하여 키를 복사하고, DutyPusher 설정의 Channel URL/Key 필드에 붙여넣습니다. **저장**을 클릭하여 사용을 시작합니다.

### Telegram Bot Official API 구성

공식 문서: [Telegram Bot API](https://core.telegram.org/bots#how-do-i-create-a-bot)

**다음 단계는 언제든지 변경될 수 있습니다. 최신 지침은 공식 Telegram 문서를 참조하십시오.**

#### 봇 생성

1. Telegram 계정을 사용하여 [@BotFather](https://t.me/botfather)에게 `/start` 명령어를 보냅니다.
2. 그런 다음 `/newbot` 명령어를 보내고 지시에 따라 봇의 이름과 사용자 이름을 설정합니다.
3. 봇에 대한 상세 정보를 받게 되며, 이는 봇 링크(`t.me/`로 시작)와 토큰(숫자로 시작: `0000000000:xxxxxxxxxxxxxxxxxxxxxxxxxxxx`)을 포함합니다.

#### 플러그인 설정

![Telegram 설정](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/settings-ko-telegram.png?raw=true)

1. Telegram에서 새로 생성한 봇에게 `/start` 명령어를 보냅니다.
2. BotFather가 제공한 토큰을 복사하여 DutyPusher 설정의 Token 필드에 붙여넣습니다. **Get Chat ID**를 클릭하고 Chat ID가 자동으로 채워질 때까지 기다립니다.
3. Chat ID가 검색되면, **Test**를 클릭하여 Telegram에서 봇으로부터 메시지를 받을 수 있는지 확인합니다. 모든 것이 작동하면 **저장**을 클릭하여 사용을 시작합니다.

> [!TIP]
>
> 플러그인이 Chat ID를 자동으로 검색할 수 없는 경우, 다음 단계를 시도해 보십시오:
>
> 1. 토큰이 올바르게 입력되었는지 확인합니다.
> 2. 봇에게 아무 메시지나 보내고 Chat ID를 다시 검색해 보십시오.
>
> 위의 단계가 작동하지 않는 경우:
>
> 1. 브라우저를 열고 다음 URL을 방문합니다:
>    `https://api.telegram.org/bot$YOUR_BOT_TOKEN_HERE/getUpdates`
>    참고: `$YOUR_BOT_TOKEN_HERE`를 봇 토큰으로 대체합니다.
> 2. JSON 응답에서 `message` -> `chat` -> `id` 필드를 찾아 플러그인 설정의 Chat ID 필드에 복사합니다.