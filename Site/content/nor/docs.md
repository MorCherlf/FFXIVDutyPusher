---
date: '2025-03-30T11:27:58+03:00'
draft: true
title: 'Installasjonsveiledning'
---

## Pluggin-innstillinger

Du kan åpne innstillingssiden for DutyPusher på en av følgende måter:

1. Klikk på DutyPusher-innstillingsknappen i Plugin-senteret.
2. Skriv inn kommandoen `/dutypusher` i spillet.

![Pluggin-innstillinger](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/settings-no.png?raw=true)

Først, velg push-kanalen du ønsker å bruke fra rullegardinmenyen.

Deretter, fyll ut den nødvendige Token/URL/Nøkkel for den valgte push-kanalen, aktiver plugginen, og lagre innstillingene for å begynne å bruke den.

Etter at du har konfigurert push-kanalen, kan du sjekke aktivitetsstatusen til DutyPusher i **DTR Bar** øverst til høyre i spillets hovedgrensesnitt. Klikk på statusikonet for å slå den av eller på.

![DTRBar](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/dtrbar-no.png?raw=true)

## Push-kanal konfigurasjon

For øyeblikket støtter DutyPusher følgende push-kanaler: **Bark**, **PushDeer**, og **Telegram Bot Offisiell API**.

**Hvis du ønsker å legge til støtte for en ny plattform, vennligst send inn en Issue til dette repositoryet.**

Repo-lenker: [Bark](https://github.com/Finb/Bark) | [PushDeer](https://github.com/easychen/pushdeer)

Telegram Bot: [Telegram Bot API](https://core.telegram.org/bots/api)

**Hvis du opplever problemer mens du bruker denne plugginen, vennligst ikke send tilbakemelding til noen push-kanal/plattform.**

**Del ikke kanal-URL/Nøkkel med noen!**

### Bark konfigurasjon

Søk etter **Bark** i App Store og installer den.

Åpne Bark-appen, klikk på **Registrer enhet**, og tillat den å sende varsler.

![Bark-grensesnitt](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/bark-en.jpg?raw=true)

Kopier den første URL-en i Bark og lim den inn i Kanal-URL/Nøkkel-feltet i DutyPusher-innstillingene. Klikk på **Lagre** for å begynne å bruke den.

> Valgfrie konfigurasjoner
>
> - Du kan aktivere **Tidsfølsomme varsler** i pluggin-innstillingene for å motta push-varsler selv når enheten din er i Fokus-modus.
> - I Bark, klikk på **Vis alle lyder** og importer denne [Duty-lyden](https://github.com/MorCherlf/FFXIVDutyPusher/raw/master/Resources/ff14.caf). Sørg for å omdøpe filen til `ff14.caf` før du importerer den.

### PushDeer konfigurasjon

iOS/iPadOS (14+)

Bruk systemkameraet ditt til å skanne App Clip-koden under for å begynne å bruke PushDeer.

![App Clip-kode](https://github.com/easychen/pushdeer/raw/main/doc/image/clipcode.png)

Alternativt, søk etter **PushDeer** i App Store og installer den.

![PushDeer enhetsgrensesnitt](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/pushdeer-device-en.png?raw=true)

Åpne PushDeer-appen, gå til **Enheter**-fanen, klikk på pluss (+) -knappen øverst til høyre, og tillat den å sende varsler.

![PushDeer nøkkelgrensesnitt](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/pushdeer-key-en.jpg?raw=true)

Gå til **Nøkkel**-fanen i PushDeer, kopier nøkkelen din, og lim den inn i Kanal-URL/Nøkkel-feltet i DutyPusher-innstillingene. Klikk på **Lagre** for å begynne å bruke den.

### Telegram Bot Offisiell API konfigurasjon

Offisiell dokumentasjon: [Telegram Bot API](https://core.telegram.org/bots#how-do-i-create-a-bot)

**Følgende trinn kan endres når som helst. Vennligst se den offisielle Telegram-dokumentasjonen for de siste instruksjonene.**

#### Opprette en bot

1. Bruk Telegram-kontoen din til å sende `/start`-kommandoen til [@BotFather](https://t.me/botfather).
2. Send deretter `/newbot`-kommandoen og følg instruksjonene for å sette et navn og brukernavn for boten din.
3. Du vil motta detaljert informasjon om boten din, inkludert en lenke til boten din (starter med `t.me/`) og en token (starter med tall: `0000000000:xxxxxxxxxxxxxxxxxxxxxxxxxxxx`).

#### Pluggin-innstillinger

![Telegram-innstillinger](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/settings-no-telegram.png?raw=true)

1. Send `/start`-kommandoen til den nylig opprettede boten din i Telegram.
2. Kopier tokenen som ble gitt av BotFather og lim den inn i Token-feltet i DutyPusher-innstillingene. Klikk på **Hent Chat ID** og vent til Chat ID-en automatisk fylles ut.
3. Når Chat ID-en er hentet, klikk på **Test** for å bekrefte at du kan motta en melding fra boten din i Telegram. Hvis alt fungerer, klikk på **Lagre** for å begynne å bruke den.

> [!TIP]
>
> Hvis plugginen ikke automatisk kan hente Chat ID-en din, prøv følgende trinn:
>
> 1. Sørg for at tokenen er skrevet inn riktig.
> 2. Send en hvilken som helst melding til boten din og prøv å hente Chat ID-en på nytt.
>
> Hvis trinnene ovenfor ikke fungerer:
>
> 1. Åpne nettleseren din og besøk følgende URL:
>    `https://api.telegram.org/bot$YOUR_BOT_TOKEN_HERE/getUpdates`
>    Merk: Erstatt `$YOUR_BOT_TOKEN_HERE` med bot-tokenen din.
> 2. Finn `message` -> `chat` -> `id`-feltet i JSON-svaret og kopier det inn i Chat ID-feltet i pluggin-innstillingene.