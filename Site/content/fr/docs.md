---
date: '2025-03-30T11:27:58+03:00'
title: 'Guide de Configuration'
---

## Paramètres du Plugin

Vous pouvez ouvrir la page des paramètres de DutyPusher de l'une des manières suivantes :

1. Cliquez sur le bouton des paramètres de DutyPusher dans le Centre de Plugins.
2. Entrez la commande `/dutypusher` dans le jeu.

![Paramètres du Plugin](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/settings-fr.png?raw=true)

Tout d'abord, sélectionnez le canal de notification que vous souhaitez utiliser dans le menu déroulant.

Ensuite, remplissez le Token/URL/Clé requis pour le canal de notification sélectionné, activez le plugin et enregistrez les paramètres pour commencer à l'utiliser.

Après avoir configuré le canal de notification, vous pouvez vérifier l'état d'activation de DutyPusher dans la **Barre DTR** en haut à droite de l'interface principale du jeu. Cliquez sur l'icône d'état pour l'activer ou le désactiver.

![Barre DTR](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/dtrbar-fr.png?raw=true)

## Configuration des Canaux de Notification

Actuellement, DutyPusher prend en charge les canaux de notification suivants : **Bark**, **PushDeer** et **API Officielle Telegram Bot**.

**Si vous souhaitez ajouter le support d'une nouvelle plateforme, veuillez soumettre un Issue à ce dépôt.**

Liens des dépôts : [Bark](https://github.com/Finb/Bark) | [PushDeer](https://github.com/easychen/pushdeer)

Bot Telegram : [API Telegram Bot](https://core.telegram.org/bots/api)

**Si vous rencontrez des problèmes lors de l'utilisation de ce plugin, veuillez ne pas envoyer de commentaires à aucun canal de notification ou plateforme.**

**Ne partagez pas votre URL/Clé de canal avec qui que ce soit !**

### Configuration de Bark

Recherchez **Bark** dans l'App Store et installez-le.

Ouvrez l'application Bark, cliquez sur **Enregistrer l'appareil** et autorisez-la à envoyer des notifications.

![Interface Bark](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/bark-en.jpg?raw=true)

Copiez la première URL dans Bark et collez-la dans le champ URL/Clé du canal dans les paramètres de DutyPusher. Cliquez sur **Enregistrer** pour commencer à l'utiliser.

> Configurations Optionnelles
>
> - Vous pouvez activer **Notifications Urgentes** dans les paramètres du plugin pour recevoir des notifications push même lorsque votre appareil est en mode Focus.
> - Dans Bark, cliquez sur **Voir tous les sons** et importez ce [Son de Duty](https://github.com/MorCherlf/FFXIVDutyPusher/raw/master/Resources/ff14.caf). Assurez-vous de renommer le fichier en `ff14.caf` avant de l'importer.

### Configuration de PushDeer

iOS/iPadOS (14+)

Utilisez l'appareil photo de votre système pour scanner le code App Clip ci-dessous et commencer à utiliser PushDeer.

![Code App Clip](https://github.com/easychen/pushdeer/raw/main/doc/image/clipcode.png)

Alternativement, recherchez **PushDeer** dans l'App Store et installez-le.

![Interface Appareil PushDeer](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/pushdeer-device-en.png?raw=true)

Ouvrez l'application PushDeer, allez dans l'onglet **Appareils**, cliquez sur le bouton plus (+) en haut à droite et autorisez-la à envoyer des notifications.

![Interface Clé PushDeer](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/pushdeer-key-en.jpg?raw=true)

Allez dans l'onglet **Clé** dans PushDeer, copiez votre clé et collez-la dans le champ URL/Clé du canal dans les paramètres de DutyPusher. Cliquez sur **Enregistrer** pour commencer à l'utiliser.

### Configuration de l'API Officielle Telegram Bot

Documentation Officielle : [API Telegram Bot](https://core.telegram.org/bots#how-do-i-create-a-bot)

**Les étapes suivantes peuvent changer à tout moment. Veuillez vous référer à la documentation officielle de Telegram pour les instructions les plus récentes.**

#### Création d'un Bot

1. Utilisez votre compte Telegram pour envoyer la commande `/start` à [@BotFather](https://t.me/botfather).
2. Ensuite, envoyez la commande `/newbot` et suivez les instructions pour définir un nom et un nom d'utilisateur pour votre bot.
3. Vous recevrez des informations détaillées sur votre bot, y compris un lien vers votre bot (commençant par `t.me/`) et un token (commençant par des chiffres : `0000000000:xxxxxxxxxxxxxxxxxxxxxxxxxxxx`).

#### Paramètres du Plugin

![Paramètres Telegram](https://github.com/MorCherlf/FFXIVDutyPusher/blob/master/Resources/img/settings-fr-telegram.png?raw=true)

1. Envoyez la commande `/start` à votre bot nouvellement créé dans Telegram.
2. Copiez le token fourni par BotFather et collez-le dans le champ Token dans les paramètres de DutyPusher. Cliquez sur **Obtenir l'ID de chat** et attendez que l'ID de chat soit automatiquement rempli.
3. Une fois l'ID de chat récupéré, cliquez sur **Tester** pour confirmer que vous pouvez recevoir un message de votre bot dans Telegram. Si tout fonctionne, cliquez sur **Enregistrer** pour commencer à l'utiliser.

> [!TIP]
>
> Si le plugin ne parvient pas à récupérer automatiquement votre ID de chat, essayez les étapes suivantes :
>
> 1. Assurez-vous que le token est correctement entré.
> 2. Envoyez un message à votre bot et essayez de récupérer à nouveau l'ID de chat.
>
> Si les étapes ci-dessus ne fonctionnent pas :
>
> 1. Ouvrez votre navigateur et visitez l'URL suivante :
>    `https://api.telegram.org/bot$YOUR_BOT_TOKEN_HERE/getUpdates`
>    Remarque : Remplacez `$YOUR_BOT_TOKEN_HERE` par votre token de bot.
> 2. Localisez le champ `message` -> `chat` -> `id` dans la réponse JSON et copiez-le dans le champ ID de chat dans les paramètres du plugin.