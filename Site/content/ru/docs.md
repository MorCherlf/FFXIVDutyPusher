---
date: '2025-03-30T11:27:58+03:00'
title: 'Руководство по настройке'
---

## Настройки плагина

Вы можете открыть страницу настроек DutyPusher одним из следующих способов:

1. Нажмите кнопку настроек DutyPusher в центре плагинов.
2. Введите команду `/dutypusher` в игре.

![Настройки плагина](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/settings-ru.png?raw=true)

Сначала выберите канал уведомлений, который вы хотите использовать, из выпадающего меню.

Затем заполните необходимый Token/URL/Key для выбранного канала уведомлений, активируйте плагин и сохраните настройки, чтобы начать его использование.

После настройки канала уведомлений вы можете проверить статус активации DutyPusher в **DTR Bar** в верхнем правом углу основного интерфейса игры. Нажмите на значок статуса, чтобы включить или выключить его.

![DTRBar](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/dtrbar-ru.png?raw=true)

## Настройка каналов уведомлений

В настоящее время DutyPusher поддерживает следующие каналы уведомлений: **Bark**, **PushDeer** и **Официальный API Telegram Bot**.

**Если вы хотите добавить поддержку новой платформы, пожалуйста, отправьте Issue в этот репозиторий.**

Ссылки на репозитории: [Bark](https://github.com/Finb/Bark) | [PushDeer](https://github.com/easychen/pushdeer)

Telegram Bot: [Telegram Bot API](https://core.telegram.org/bots/api)

**Если вы столкнулись с проблемами при использовании этого плагина, пожалуйста, не отправляйте отзывы на любой канал уведомлений/платформу.**

**Не делитесь своим URL/Key канала с кем-либо!**

### Настройка Bark

Найдите **Bark** в App Store и установите его.

Откройте приложение Bark, нажмите **Register Device** и разрешите отправку уведомлений.

![Интерфейс Bark](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/bark-en.jpg?raw=true)

Скопируйте первый URL в Bark и вставьте его в поле Channel URL/Key в настройках DutyPusher. Нажмите **Сохранить**, чтобы начать использование.

> Дополнительные настройки
>
> - Вы можете включить **Срочные уведомления** в настройках плагина, чтобы получать push-уведомления, даже если ваше устройство находится в режиме "Не беспокоить".
> - В Bark нажмите **View All Sounds** и импортируйте этот [Звук Duty](https://github.com/MorCherlf/FFXIVDutyPusher/raw/master/Resources/ff14.caf). Убедитесь, что переименовали файл в `ff14.caf` перед импортом.

### Настройка PushDeer

iOS/iPadOS (14+)

Используйте камеру вашего устройства, чтобы отсканировать App Clip Code ниже, чтобы начать использование PushDeer.

![App Clip Code](https://github.com/easychen/pushdeer/raw/main/doc/image/clipcode.png)

Либо найдите **PushDeer** в App Store и установите его.

![Интерфейс устройства PushDeer](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/pushdeer-device-en.png?raw=true)

Откройте приложение PushDeer, перейдите на вкладку **Devices**, нажмите на плюс (+) в верхнем правом углу и разрешите отправку уведомлений.

![Интерфейс ключа PushDeer](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/pushdeer-key-en.jpg?raw=true)

Перейдите на вкладку **Key** в PushDeer, скопируйте ваш ключ и вставьте его в поле Channel URL/Key в настройках DutyPusher. Нажмите **Сохранить**, чтобы начать использование.

### Настройка Официального API Telegram Bot

Официальная документация: [Telegram Bot API](https://core.telegram.org/bots#how-do-i-create-a-bot)

**Следующие шаги могут измениться в любое время. Пожалуйста, обратитесь к официальной документации Telegram для получения актуальных инструкций.**

#### Создание бота

1. Используйте ваш аккаунт Telegram, чтобы отправить команду `/start` [@BotFather](https://t.me/botfather).
2. Затем отправьте команду `/newbot** и следуйте инструкциям, чтобы задать имя и username для вашего бота.
3. Вы получите подробную информацию о вашем боте, включая ссылку на бота (начинающуюся с `t.me/`) и токен (начинающийся с цифр: `0000000000:xxxxxxxxxxxxxxxxxxxxxxxxxxxx`).

#### Настройки плагина

![Настройки Telegram](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/settings-ru-telegram.png?raw=true)

1. Отправьте команду `/start` вашему новому боту в Telegram.
2. Скопируйте токен, предоставленный BotFather, и вставьте его в поле Token в настройках DutyPusher. Нажмите **Получить Chat ID** и дождитесь автоматического заполнения Chat ID.
3. После получения Chat ID нажмите **Тест**, чтобы убедиться, что вы можете получить сообщение от вашего бота в Telegram. Если всё работает, нажмите **Сохранить**, чтобы начать использование.

> [!TIP]
>
> Если плагин не может автоматически получить ваш Chat ID, попробуйте следующие шаги:
>
> 1. Убедитесь, что токен введён правильно.
> 2. Отправьте любое сообщение вашему боту и попробуйте получить Chat ID снова.
>
> Если вышеуказанные шаги не работают:
>
> 1. Откройте ваш браузер и перейдите по следующему URL:
>    `https://api.telegram.org/bot$YOUR_BOT_TOKEN_HERE/getUpdates`
>    Примечание: Замените `$YOUR_BOT_TOKEN_HERE` на ваш токен бота.
> 2. Найдите поле `message` -> `chat` -> `id` в JSON-ответе и скопируйте его в поле Chat ID в настройках плагина.