namespace SpammerBuddy
{
    using System;
    using EloBuddy;
    using EloBuddy.SDK.Menu;
    using EloBuddy.SDK.Events;
    using EloBuddy.SDK.Menu.Values;

    internal class Program
    {

        public static Menu Menu, Emote;

        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Game_OnStart;
        }

        private static void Game_OnStart(EventArgs args)
        {

            Menu = MainMenu.AddMenu("Spammer", "Spammer");

            Menu.AddGroupLabel("Welcome to SpammerBuddy!");
            Menu.AddSeparator();
            Menu.AddLabel("v0.000001");
            Menu.AddSeparator();
            Emote = Menu.AddSubMenu("Chat Spammer", "ChatSpammer");
            Emote.AddGroupLabel("Spam a secleted text preset");
            var EmoteSpamList = Emote.Add("Chat Spamming", new Slider("EmoteList", 0, 0, 3));
            EmoteSpamList.OnValueChange += delegate
            {
                EmoteSpamList.DisplayName = new[] { "Spam: \"GG\"", "Spam: \"Outplayed\"", "Spam: \"All Your Base Are Belong To Us\"", "Spam: \"HueHueHue Mordekaiser Numero Uno\"" }
                [EmoteSpamList.CurrentValue];
            };
            Emote.Add("ChatSpamPressHotkey", new KeyBind("Configure Spamming Hotkey", false, KeyBind.BindTypes.HoldActive, 'K'));

            Game.OnUpdate += OnUpdate;
        }

        public static void OnUpdate(EventArgs args)
        {
            double tick = 0;
            tick = TimeSpan.FromTicks(Environment.TickCount).Milliseconds;

            if (ObjectManager.Player.HasBuff("Recall"))
            {
                return;
            } 
            if (Emote["ChatSpamPressHotkey"].Cast<KeyBind>().CurrentValue)
            {
                EmoteSpam();
            }
        }

        public static void EmoteSpam()
        {

            switch (Emote["Chat Spamming"].Cast<Slider>().CurrentValue)
            {
                case 0:
                    Chat.Say("GG");
                    break;
                case 1:
                    Chat.Say("Outplayed");
                    break;
                case 2:
                    Chat.Say("All Your Base Are Belong To Us");
                    break;
                case 3:
                    Chat.Say("HueHueHue Mordekaiser Numero Uno");
                    break;
            }
        }
    }
}