using Doggie.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System.Security.Policy;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Doggie.Controllers
{
	public class TelegramController : Controller
	{
		//public static readonly string BotToken = "7103708317:AAF7fAiGGw5a5ULbJDPJcJzMRoJ_Y4_C3eQ";
		//public static readonly TelegramBotClient BotClient = new TelegramBotClient(BotToken);
		//string token = "7103708317:AAF7fAiGGw5a5ULbJDPJcJzMRoJ_Y4_C3eQ";
		//private static TelegramBotClient botClient;
		//private static CancellationTokenSource cts;
		//	public async Task Send()
		//	{
		//		string token = "7103708317:AAF7fAiGGw5a5ULbJDPJcJzMRoJ_Y4_C3eQ";  // Bot tokeninizi buraya ekleyin
		//		botClient = new TelegramBotClient(token);

		//		cts = new CancellationTokenSource();
		//		var cancellationToken = cts.Token;
		//		var receiverOptions = new ReceiverOptions
		//		{
		//			AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
		//		};

		//		botClient.StartReceiving(
		//			HandleUpdateAsync,
		//			HandleErrorAsync,
		//			receiverOptions,
		//			cancellationToken
		//		);

		//		Console.WriteLine("Bot is up and running. Press any key to exit.");
		//		Console.ReadKey();

		//		cts.Cancel();
		//	}


		//	static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
		//	{
		//		if (update.Type == UpdateType.Message && update.Message.Type == MessageType.Text)
		//		{
		//			var message = update.Message;

		//			Console.WriteLine($"Received a '{message.Text}' message in chat {message.Chat.Id}.");

		//			// Mesajı işleme logic'inizi burada yazın
		//			await HandleMessageAsync(message);
		//		}
		//	}

		//	static async Task HandleMessageAsync(Message message)
		//	{
		//		if (message.Text == "/start")
		//		{
		//			await botClient.SendTextMessageAsync(
		//				chatId: message.Chat.Id,
		//				text: "Bot is started!"
		//			);
		//		}
		//		else
		//		{
		//			// Diğer mesajları işleme
		//			await botClient.SendTextMessageAsync(
		//				chatId: message.Chat.Id,
		//				text: $"You said: {message.Text}"
		//			);
		//		}
		//	}

		//	static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
		//	{
		//		var errorMessage = exception switch
		//		{
		//			ApiRequestException apiRequestException
		//				=> $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
		//			_ => exception.ToString()
		//		};

		//		Console.WriteLine(errorMessage);
		//		return Task.CompletedTask;
		//	}
	}

}


		


