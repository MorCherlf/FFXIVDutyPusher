---
date: '2025-03-30T11:27:58+03:00'
title: 'Einstellungsanleitung'
---

## Plugin-Einstellungen

Sie können die DutyPusher-Einstellungsseite auf eine der folgenden Arten öffnen:

1. Klicken Sie auf die DutyPusher-Einstellungsschaltfläche im Plugin-Center.
2. Geben Sie den Befehl `/dutypusher` im Spiel ein.

![Plugin-Einstellungen](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/settings-de.png?raw=true)

Wählen Sie zunächst den Push-Kanal aus, den Sie verwenden möchten, aus dem Dropdown-Menü.

Füllen Sie dann das erforderliche Token/URL/Schlüssel für den ausgewählten Push-Kanal aus, aktivieren Sie das Plugin und speichern Sie die Einstellungen, um es zu verwenden.

Nach der Konfiguration des Push-Kanals können Sie den Aktivierungsstatus von DutyPusher in der **DTR-Leiste** in der oberen rechten Ecke der Hauptoberfläche des Spiels überprüfen. Klicken Sie auf das Status-Symbol, um es ein- oder auszuschalten.

![DTR-Leiste](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/dtrbar-de.png?raw=true)

## Push-Kanal-Konfiguration

Derzeit unterstützt DutyPusher die folgenden Push-Kanäle: **Bark**, **PushDeer** und **Telegram Bot Offizielle API**.

**Wenn Sie Unterstützung für eine neue Plattform hinzufügen möchten, reichen Sie bitte ein Issue in diesem Repository ein.**

Repo-Links: [Bark](https://github.com/Finb/Bark) | [PushDeer](https://github.com/easychen/pushdeer)

Telegram Bot: [Telegram Bot API](https://core.telegram.org/bots/api)

**Wenn Sie beim Verwenden dieses Plugins auf Probleme stoßen, senden Sie bitte kein Feedback an einen Push-Kanal/Plattform.**

**Teilen Sie Ihre Kanal-URL/Schlüssel nicht mit anderen!**

### Bark-Konfiguration

Suchen Sie im App Store nach **Bark** und installieren Sie es.

Öffnen Sie die Bark-App, klicken Sie auf **Gerät registrieren** und erlauben Sie das Senden von Benachrichtigungen.

![Bark-Oberfläche](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/bark-en.jpg?raw=true)

Kopieren Sie die erste URL in Bark und fügen Sie sie in das Feld Kanal-URL/Schlüssel in den DutyPusher-Einstellungen ein. Klicken Sie auf **Speichern**, um es zu verwenden.

> Optionale Konfigurationen
>
> - Sie können **Zeitkritische Benachrichtigungen** in den Plugin-Einstellungen aktivieren, um Push-Benachrichtigungen zu erhalten, auch wenn Ihr Gerät im Fokusmodus ist.
> - Klicken Sie in Bark auf **Alle Sounds anzeigen** und importieren Sie diesen [Duty-Sound](https://github.com/MorCherlf/FFXIVDutyPusher/raw/master/Resources/ff14.caf). Stellen Sie sicher, dass die Datei in `ff14.caf` umbenannt wird, bevor Sie sie importieren.

### PushDeer-Konfiguration

iOS/iPadOS (14+)

Verwenden Sie Ihre Systemkamera, um den App-Clip-Code unten zu scannen, um PushDeer zu verwenden.

![App-Clip-Code](https://github.com/easychen/pushdeer/raw/main/doc/image/clipcode.png)

Alternativ können Sie im App Store nach **PushDeer** suchen und es installieren.

![PushDeer-Geräteoberfläche](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/pushdeer-device-en.png?raw=true)

Öffnen Sie die PushDeer-App, gehen Sie zum **Geräte**-Tab, klicken Sie auf das Plus (+) in der oberen rechten Ecke und erlauben Sie das Senden von Benachrichtigungen.

![PushDeer-Schlüsseloberfläche](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/pushdeer-key-en.jpg?raw=true)

Gehen Sie zum **Schlüssel**-Tab in PushDeer, kopieren Sie Ihren Schlüssel und fügen Sie ihn in das Feld Kanal-URL/Schlüssel in den DutyPusher-Einstellungen ein. Klicken Sie auf **Speichern**, um es zu verwenden.

### Telegram Bot Offizielle API-Konfiguration

Offizielle Dokumentation: [Telegram Bot API](https://core.telegram.org/bots#how-do-i-create-a-bot)

**Die folgenden Schritte können sich jederzeit ändern. Bitte beziehen Sie sich auf die offizielle Telegram-Dokumentation für die neuesten Anweisungen.**

#### Erstellen eines Bots

1. Verwenden Sie Ihr Telegram-Konto, um den Befehl `/start` an [@BotFather](https://t.me/botfather) zu senden.
2. Senden Sie dann den Befehl `/newbot` und folgen Sie den Anweisungen, um einen Namen und einen Benutzernamen für Ihren Bot festzulegen.
3. Sie erhalten detaillierte Informationen über Ihren Bot, einschließlich eines Links zu Ihrem Bot (beginnend mit `t.me/`) und eines Tokens (beginnend mit Zahlen: `0000000000:xxxxxxxxxxxxxxxxxxxxxxxxxxxx`).

#### Plugin-Einstellungen

![Telegram-Einstellungen](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/settings-de-telegram.png?raw=true)

1. Senden Sie den Befehl `/start` an Ihren neu erstellten Bot in Telegram.
2. Kopieren Sie das von BotFather bereitgestellte Token und fügen Sie es in das Token-Feld in den DutyPusher-Einstellungen ein. Klicken Sie auf **Chat-ID erhalten** und warten Sie, bis die Chat-ID automatisch ausgefüllt wird.
3. Sobald die Chat-ID abgerufen wurde, klicken Sie auf **Test**, um zu bestätigen, dass Sie eine Nachricht von Ihrem Bot in Telegram erhalten können. Wenn alles funktioniert, klicken Sie auf **Speichern**, um es zu verwenden.

> [!TIP]
>
> Wenn das Plugin Ihre Chat-ID nicht automatisch abrufen kann, versuchen Sie die folgenden Schritte:
>
> 1. Stellen Sie sicher, dass das Token korrekt eingegeben wurde.
> 2. Senden Sie eine beliebige Nachricht an Ihren Bot und versuchen Sie, die Chat-ID erneut abzurufen.
>
> Wenn die obigen Schritte nicht funktionieren:
>
> 1. Öffnen Sie Ihren Browser und besuchen Sie die folgende URL:
>    `https://api.telegram.org/bot$YOUR_BOT_TOKEN_HERE/getUpdates`
>    Hinweis: Ersetzen Sie `$YOUR_BOT_TOKEN_HERE` mit Ihrem Bot-Token.
> 2. Suchen Sie das Feld `message` -> `chat` -> `id` in der JSON-Antwort und kopieren Sie es in das Chat-ID-Feld in den Plugin-Einstellungen.