using Dalamud.Plugin.Services;
using FFXIVClientStructs.FFXIV.Common.Lua;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DutyPusher.PushChannels
{
    public class NtfyChannel: IPushChannel
    {
        public List<string> emojiList = new List<string>()
        {
            "grinning", "smiley", "smile", "grin", "laughing", "sweat_smile", "rofl", "joy", "slightly_smiling_face",
            "upside_down_face", "wink", "blush", "innocent", "smiling_face_with_three_hearts", "heart_eyes",
            "star_struck", "kissing_heart", "kissing", "relaxed", "kissing_closed_eyes", "kissing_smiling_eyes",
            "smiling_face_with_tear", "yum", "stuck_out_tongue", "stuck_out_tongue_winking_eye", "zany_face",
            "stuck_out_tongue_closed_eyes", "hugs", "hand_over_mouth", "cowboy_hat_face", "partying_face", "sunglasses",
            "smiley_cat", "smile_cat", "joy_cat", "heart_eyes_cat", "kissing_cat", "cupid", "gift_heart",
            "sparkling_heart", "heartpulse", "heartbeat", "heart", "orange_heart", "yellow_heart", "green_heart",
            "blue_heart", "purple_heart", "brown_heart", "black_heart", "white_heart", "monkey_face", "dog", "wolf",
            "fox_face", "raccoon", "cat", "lion", "tiger", "hedgehog", "bear", "polar_bear", "koala", "panda_face",
            "sloth", "otter", "penguin", "owl", "whale", "octopus", "snail", "bee", "cactus", "watermelon", "grapes",
        };

        private static Random _random = new Random();

        private string GetRandomEmoji()
        {
            if (emojiList == null || emojiList.Count == 0)
            {
                return "cactus"; 
            }
            int randomIndex = _random.Next(emojiList.Count);
            return emojiList[randomIndex];
        }


        private readonly HttpClient httpClient;
        private readonly string server;
        private readonly string topic;
        private readonly int priority; // 3 = default, 4 = high priority, 5 = max
        private readonly bool emoji;

        public NtfyChannel(string server, string topic, int priority, bool emoji)
        {
            httpClient = new HttpClient();
            this.server = server;
            this.topic = topic;
            this.priority = priority;
            this.emoji = emoji;
        }

        public async Task SendAsync(string title, string content, IPluginLog pluginLog)
        {
            var url = $"{server}{topic}/publish?message={content}&title={title}&priority={priority}&icon=https://cdn2.steamgriddb.com/icon/5f268dfb0fbef44de0f668a022707b86/32/256x256.png";
            if (emoji)
            {
                string randomEmoji = GetRandomEmoji();
                if (!string.IsNullOrEmpty(randomEmoji))
                {
                    url = url + $"&tag={randomEmoji}";
                }
            }
            pluginLog.Debug(url);
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}
