using MihaZupan;
using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace SimpleBotWithProxy
{
    class Program
    {
        private static TelegramBotClient bot;

        [Obsolete]
        static void Main(string[] args)
        {
            var socksProxy = new HttpToSocks5Proxy("183.102.171.77", 8888);
            bot = new TelegramBotClient("983922268:AAGxXiplHabEGFUYv92pKe9VjogbPW2793I", socksProxy);

            StartBot();

            Console.ReadLine();
        }

        static void StartBot()
        {
            bot.OnUpdate += OnUpdate;
            bot.StartReceiving();
        }

        public static async void OnUpdate(object sender, UpdateEventArgs e)
        {
            if (e.Update.Message is Message message && message.Text is string text)
            {
                await bot.SendTextMessageAsync(message.Chat, "Echo:\n" + text);

            }
        }
    }
}
