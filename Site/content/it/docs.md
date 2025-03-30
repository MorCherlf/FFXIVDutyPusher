---
date: '2025-03-30T11:27:58+03:00'
draft: true
title: 'Guida alle Impostazioni'
---

## Impostazioni del Plugin

Puoi aprire la pagina delle impostazioni di DutyPusher in uno dei seguenti modi:

1. Clicca sul pulsante delle impostazioni di DutyPusher nel Centro Plugin.
2. Inserisci il comando `/dutypusher` nel gioco.

![Impostazioni del Plugin](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/settings-it.png?raw=true)

Per prima cosa, seleziona il canale di notifica che desideri utilizzare dal menu a tendina.

Successivamente, inserisci il Token/URL/Chiave richiesto per il canale di notifica selezionato, abilita il plugin e salva le impostazioni per iniziare a utilizzarlo.

Dopo aver configurato il canale di notifica, puoi verificare lo stato di attivazione di DutyPusher nella **Barra DTR** nell'angolo superiore destro dell'interfaccia principale del gioco. Clicca sull'icona dello stato per attivarlo o disattivarlo.

![Barra DTR](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/dtrbar-it.png?raw=true)

## Configurazione dei Canali di Notifica

Attualmente, DutyPusher supporta i seguenti canali di notifica: **Bark**, **PushDeer** e **API Ufficiale Telegram Bot**.

**Se desideri aggiungere il supporto per una nuova piattaforma, invia un Issue a questo repository.**

Link ai repository: [Bark](https://github.com/Finb/Bark) | [PushDeer](https://github.com/easychen/pushdeer)

Telegram Bot: [API Telegram Bot](https://core.telegram.org/bots/api)

**Se riscontri problemi durante l'uso di questo plugin, non inviare feedback a nessun canale di notifica/piattaforma.**

**Non condividere il tuo URL/Chiave del canale con nessuno!**

### Configurazione di Bark

Cerca **Bark** nell'App Store e installalo.

Apri l'app Bark, clicca su **Registra Dispositivo** e consenti l'invio di notifiche.

![Interfaccia di Bark](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/bark-en.jpg?raw=true)

Copia il primo URL in Bark e incollalo nel campo URL/Chiave del canale nelle impostazioni di DutyPusher. Clicca su **Salva** per iniziare a utilizzarlo.

> Configurazioni Opzionali
>
> - Puoi abilitare **Notifiche Tempodipendenti** nelle impostazioni del plugin per ricevere notifiche push anche quando il dispositivo è in Modalità Focus.
> - In Bark, clicca su **Visualizza Tutti i Suoni** e importa questo [Suono del Dungeon](https://github.com/MorCherlf/FFXIVDutyPusher/raw/master/Resources/ff14.caf). Assicurati di rinominare il file in `ff14.caf` prima di importarlo.

### Configurazione di PushDeer

iOS/iPadOS (14+)

Usa la fotocamera del tuo sistema per scansionare il codice App Clip qui sotto per iniziare a utilizzare PushDeer.

![Codice App Clip](https://github.com/easychen/pushdeer/raw/main/doc/image/clipcode.png)

In alternativa, cerca **PushDeer** nell'App Store e installalo.

![Interfaccia Dispositivo PushDeer](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/pushdeer-device-en.png?raw=true)

Apri l'app PushDeer, vai alla scheda **Dispositivi**, clicca sul pulsante più (+) in alto a destra e consenti l'invio di notifiche.

![Interfaccia Chiave PushDeer](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/pushdeer-key-en.jpg?raw=true)

Vai alla scheda **Chiave** in PushDeer, copia la tua chiave e incollala nel campo URL/Chiave del canale nelle impostazioni di DutyPusher. Clicca su **Salva** per iniziare a utilizzarlo.

### Configurazione dell'API Ufficiale Telegram Bot

Documentazione Ufficiale: [API Telegram Bot](https://core.telegram.org/bots#how-do-i-create-a-bot)

**I seguenti passaggi potrebbero cambiare in qualsiasi momento. Fai riferimento alla documentazione ufficiale di Telegram per le istruzioni più recenti.**

#### Creazione di un Bot

1. Usa il tuo account Telegram per inviare il comando `/start** a [@BotFather](https://t.me/botfather).
2. Invia poi il comando `/newbot** e segui le istruzioni per impostare un nome e un username per il tuo bot.
3. Riceverai informazioni dettagliate sul tuo bot, inclusi un link al tuo bot (che inizia con `t.me/`) e un token (che inizia con numeri: `0000000000:xxxxxxxxxxxxxxxxxxxxxxxxxxxx`).

#### Impostazioni del Plugin

![Impostazioni Telegram](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/settings-it-telegram.png?raw=true)

1. Invia il comando `/start** al tuo bot appena creato su Telegram.
2. Copia il token fornito da BotFather e incollalo nel campo Token nelle impostazioni di DutyPusher. Clicca su **Ottieni Chat ID** e attendi che il Chat ID venga compilato automaticamente.
3. Una volta ottenuto il Chat ID, clicca su **Test** per confermare che puoi ricevere un messaggio dal tuo bot su Telegram. Se tutto funziona, clicca su **Salva** per iniziare a utilizzarlo.

> [!TIP]
>
> Se il plugin non riesce a recuperare automaticamente il tuo Chat ID, prova i seguenti passaggi:
>
> 1. Assicurati che il token sia inserito correttamente.
> 2. Invia un messaggio qualsiasi al tuo bot e prova a recuperare nuovamente il Chat ID.
>
> Se i passaggi sopra non funzionano:
>
> 1. Apri il tuo browser e visita il seguente URL:
>    `https://api.telegram.org/bot$YOUR_BOT_TOKEN_HERE/getUpdates`
>    Nota: Sostituisci `$YOUR_BOT_TOKEN_HERE` con il token del tuo bot.
> 2. Trova il campo `message` -> `chat` -> `id` nella risposta JSON e copialo nel campo Chat ID nelle impostazioni del plugin.