using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

class Program
{
    private static ITelegramBotClient _botClient;
    private static ReceiverOptions _opt;
    private static int _adminChatId;

    public static async Task Main(string[] args)
    {
        _botClient = new TelegramBotClient(Environment.GetEnvironmentVariable("TELEGRAM_API_KEY"));
        _adminChatId = int.Parse(Environment.GetEnvironmentVariable("ADMIN_ID_CHAT"));
        _opt = new ReceiverOptions
        {
            AllowedUpdates = new[]
            {
                UpdateType.Message,
            }
        };
        using var cts = new CancellationTokenSource();
        _botClient.StartReceiving(UpdateHandler, ErrorHandler, _opt, cts.Token);
        var me = await _botClient.GetMe();
        Console.WriteLine($"Hello, {me.FirstName}!");
        await Task.Delay(-1);
    }

    private static async Task UpdateHandler(ITelegramBotClient client, Update update, CancellationToken token)
    {
        try
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                {
                    var message = update.Message;
                    var user = message.From;

                    Console.WriteLine($"{user.FirstName} {user.LastName}: {message.Text}");

                    var chat = message.Chat;
                    switch (message.Type)
                    {
                        case MessageType.Text:
                        {
                            switch (message.Text)
                            {
                                case "/start":
                                {
                                    await client.SendMessage(chat.Id, "Всем привет");
                                    await client.SendMessage(_adminChatId,
                                        $"{user.FirstName} {user.LastName}: {message.Text}");
                                    return;
                                }
                                case "В-12":
                                {
                                    await client.SendMessage(_adminChatId,
                                        $"{user.FirstName} {user.LastName}: {message.Text}");
                                    await client.SendMessage(chat.Id,
                                        "<b>В-12 Федорова Екатерина Петровна</b>\n\nЗа дверью слышится короткая перепалка переходящая в звук шагов. Дверь открывает раздраженная девушка. Ее вид становится еще более недружелюбным, когда она видит ваше удостоверение.\n\n- Я уже отвечала на все вопросы. Никого и ничего подозрительного. Вернулся поздно, как обычно. С ним был мужчина в полицейской форме, наверное коллега. Отмечали поди что-то, веселые были. Это все? У меня дела.\n\nНе попрощавшись, она хлопает дверью перед вашим лицом.",
                                        ParseMode.Html);
                                    return;
                                }
                                case "С-82":
                                    await client.SendMessage(_adminChatId,
                                        $"{user.FirstName} {user.LastName}: {message.Text}");
                                    await client.SendMessage(chat.Id,
                                        "<b>С-82 Полицейский участок \u21164</b>\n\nВ четвертом отделе вам явно не рады. Взглянув из-под бровей суровый сотрудник сообщает, что вам придется подождать пару минут. Однако ожидание затягивается. Пока время неторопливо ползет, вы успеваете изучить серые стены участка и всех находящихся в этом унылом коридоре людей, однако выявить хоть что-то интересное не удается. Наконец усталый голос вновь подзывает вас к стойке и протягивает тонкое дело с фотографией юной девочки на обложке.",
                                        ParseMode.Html);
                                    return;
                                case "Ю-52":
                                    await client.SendMessage(_adminChatId,
                                        $"{user.FirstName} {user.LastName}: {message.Text}");
                                    await client.SendMessage(chat.Id,
                                        "<b>Ю-52 Морг \u211612</b>\n\nХолодная тишина морга приветливо принимает в свои объятия. Шаги гулким эхом разносятся по коридору, извещая всех о вашем прибытии. Работники тут не сильно приветливее полицейских. Протягивая вам результаты осмотра тела, один из них роняет короткую фразу:\n\n- Господа, у нас тут все уже раз десять проверено. Не знаю, что нового вы хотите найти, но ищите вы не там. Если интересны подробности можете сходить в больницу. Там девочку пытались спасти, в тридцать четвертой это было. Может они что скажут.",
                                        ParseMode.Html);
                                    return;
                                case "Ю-4":
                                    await client.SendMessage(_adminChatId,
                                        $"{user.FirstName} {user.LastName}: {message.Text}");
                                    await client.SendMessage(chat.Id,
                                        "<b>Ю-4 Бар \"Лабиринт\"</b>\n\nШум и запах алкоголя слегка притупляют мысли. Расталкивая нерасторопных посетителей, плавно качающихся в каком-то подобии танца, вы пробираетесь к барной стойке. Стоящий за ней мужчина безусловно не единственный, кто проводит в этом заведении каждый день, но из всех, пожалуй, только он при этом сохраняет трезвую память. Взглянув на показанное вами фото, он расплывается в улыбке:\n\n- Был у нас этот товарищ. Частенько заходил. конкретный день интересует?\n\nВы озвучиваете ему дату, на что тот слегка поднимает брови:\n\n- Да, запомнил конечно. Он аж два раза заходил. Обычно так только вечером пива с товарищем выпить, тоже полицейский. А тут заглянул днем, опять не один. Второго? Юрий вроде звали, сейчас проверю, он же и оплачивал.\n\nСпустя несколько минут он появляется, держа в руках выписку.\n\n- Кузнецов Юрий Евгеньевич. Хорошие ребята, спокойные, не буянят. А вы чего интересуетесь, случилось что?",
                                        ParseMode.Html);
                                    return;
                                case "З-12":
                                    await client.SendMessage(_adminChatId,
                                        $"{user.FirstName} {user.LastName}: {message.Text}");
                                    await client.SendMessage(chat.Id,
                                        "<b>З-12 Главное управление полиции</b>\n\nУслышав ваш запрос работница удивленно приподнимает брови.\n\n- И зачем вам понадобилась эта выписка? Мне больше заняться нечем, бумагу на вас тратить.\n\nЗакатив глаза она уходит, вновь оставляя вас в сером коридоре. Однако в этот раз ожидание длится не так долго, и спустя несколько минут вы держите в руках еще теплые листы бумаги со списками всех сотрудников. Напоследок смерив вас недовольным взглядом, сотрудница вновь исчезает за дверью.",
                                        ParseMode.Html);
                                    return;
                                case "С-7":
                                    await client.SendMessage(_adminChatId,
                                        $"{user.FirstName} {user.LastName}: {message.Text}");
                                    await client.SendMessage(chat.Id,
                                        "<b>С-7 Городской сад</b>\n\nС двух сторон вымощенной тропинки стоят тонкие деревца, закрывающие своими кронами от солнца. Прекрасный день, чтобы насладиться прогулкой, но, увы, обремененный долгом службы.  Обойдя здание администрации, вы обнаруживаете приятной внешности девушку, которая к счастью оказывается нужным вам человеком.\n\n- Вы знаете, я здесь не так давно. Прошлую заведующую сократили, как и многих других работников, у них там что-то произошло. Говорят, полиция вмешалась. - она понижает голос, - вы знаете, тут нашли девочку, упала с высоты. Но вроде кто-то из старых работников видел, что не сама она упала. Бедная Анечка, совсем маленькая была. Хоть не знала ее совсем, а жалко как родную, - девушка тихо всхлипывает, прикрывая лицо рукой. - говорили, что сам прокурор четвертого это дело вел, Воронов Дмитрий, хороший специалист. Но только странно это выглядит, после того, как его сына с этой девочкой видели. Хотя уже и не важно, он и сам, говорят, погиб недавно. \n\nПроводив скорбящую назад, вы отправляетесь дальше по следу.",
                                        ParseMode.Html);
                                    return;
                                case "В-8":
                                    await client.SendMessage(_adminChatId,
                                        $"{user.FirstName} {user.LastName}: {message.Text}");
                                    await client.SendMessage(chat.Id,
                                        "<b>В-8 Морг \u211623</b>\n\n- Интересное дело господа. Не ожидал вас у себя конечно.\n\nПатологоанатом провожает вас к хранилищу, где уже лежит заранее подготовленное тело.\n\n- Итак, причина смерти удушение чем-то тонким, скорее всего шнурком. Пара синяков, нанесены посмертно. Ничего странного, вероятно вымещали злость. Предположительно нападавший стоял сзади и воспользовался фактором неожиданности. Больше мне вам сказать нечего, подробности лучше у того, кто вел дело узнавайте.",
                                        ParseMode.Html);
                                    return;
                                case "Ю-131":
                                    await client.SendMessage(_adminChatId,
                                        $"{user.FirstName} {user.LastName}: {message.Text}");
                                    await client.SendMessage(chat.Id,
                                        "<b>Ю-131 Полицейский архив</b>\n\nПорядком вымотавшись за день, вы с трудом открываете тяжелую дверь архива, готовясь к уже привычному не слишком теплому приему. Однако вас встречает приветливо улыбающаяся девушка:\n\n- Добрый день! Пришли узнать что-то конкретное?\n\n<b>Если вы хотите получить информацию о каком-либо деле введите фамилию и имя без пробелов через нижнее подчеркивание после адреса. Пример: Ю-131_ивановиван</b>",
                                        ParseMode.Html);
                                    return;
                                case "Ю-131_вороновдмитрий":
                                    await client.SendMessage(_adminChatId,
                                        $"{user.FirstName} {user.LastName}: {message.Text}");
                                    await client.SendMessage(chat.Id,
                                        "<b>Ю-131_вороновдмитрий</b>\n\nСлегка удивившись, услышав ваш запрос, девушка удаляется за нужной папкой. И вот вы уже держите в руках, как хочется надеется, ответ на все ваши вопросы.",
                                        ParseMode.Html);
                                    return;
                                case "Ю-2":
                                    await client.SendMessage(_adminChatId,
                                        $"{user.FirstName} {user.LastName}: {message.Text}");
                                    await client.SendMessage(chat.Id,
                                        "<b>Ю-2 Колесниченко Иван Александрович</b>\n\nОбычное многоквартирное здание, в уже привычных серых тонах. Поднявшись на нужный этаж - по лестнице, ведь лифт тут не работает уже какое-то время вы находите нужную квартиру. Внутри убрано, скромная мебель и никаких предметов роскоши - дом явно обычного человека. Обойдя комнаты вы не замечаете ничего примечательного, кроме лежащего на столе ножа-бабочки. Похоже к ним у задержанного страсть. У двери вы еще раз оборачиваетесь, чтобы бегло окинуть взглядом комнату. Небольшая кухня, плита, чайник, холодильник с магнитами привезенными из путешествий. Один из них держит прикрепленную открытку: какой-то красный цветок, от двери не разглядеть. Захлопнув дверь, вы покидаете здание.",
                                        ParseMode.Html);
                                    return;
                                case "С-14_ивановмихаил":
                                    await client.SendMessage(_adminChatId,
                                        $"{user.FirstName} {user.LastName}: {message.Text}");
                                    await client.SendMessage(chat.Id,
                                        "<b>С-14_ивановмихаил</b>\n\nМенеджер быстро набирает что-то на клавиатуре и через пару секунд сообщает, что нужный вам человек трудится в участке номер два. Если поспешить, то можно застать его сегодня",
                                        ParseMode.Html);
                                    return;
                                case "З-2":
                                    await client.SendMessage(_adminChatId,
                                        $"{user.FirstName} {user.LastName}: {message.Text}");
                                    await client.SendMessage(chat.Id,
                                        "<b>З-2 Полицейский участок \u21162</b>\n\nВойдя, вы сразу замечаете нужного вам человека. Иванов раздает указания патрульным. Подождав, пока он освободится вы подходите, доставая удостоверение.\n\n- Да Господа, чем обязан? Интересное дело вы выбрали. Спешу огорчить, раскрыли на днях. Мои ребята задержали одного, парень явно не в себе. Нашли его в том же подъезде, с ножом разгуливал. Поди под веществами был. Увидел дверь открытую ну и зашел. Ну и увезли его. Раз хотите езжайте конечно, но я бы на вашем месте время не тратил.\n\nПопрощавшись с новым знакомым, вы выходите на улицу чтобы поймать такси.",
                                        ParseMode.Html);
                                    return;
                                case "С-14":
                                    await client.SendMessage(_adminChatId,
                                        $"{user.FirstName} {user.LastName}: {message.Text}");
                                    await client.SendMessage(chat.Id, "<b>С-14 Полицейский отдел экспертиз</b>\n\nЕсли вы хотите узнать, в каком участке числится сотрудник полиции, то напишите его фамилию и имя без пробелов через нижнее подчеркивание после адреса. Пример: С-14_ивановиван", ParseMode.Html);
                                    return;
                                case "В-122":
                                    await client.SendMessage(_adminChatId,
                                        $"{user.FirstName} {user.LastName}: {message.Text}");
                                    await client.SendMessage(chat.Id, "<b>В-122 Полицейский участок \u21165</b>\n\nДежурный провожает вас до небольшой камеры, внутри которой едва угадывается человек. Тени закрывают его лицо, но стоит вам подойти ближе заключенный бросается на прутья, прижавшись к ним лицом.\n\n- Опять вы! Вы меня сюда упекли! Я этого так не оставлю, из-под земли достану вас! Вы у меня все получите!\n\nШум стихает, похоже ему все же удалось разглядеть ваше лицо.\n\n- Так это не вы меня здесь бросили. Нет, вы поймите, это что такое творится! Зашел погреться, дождь лил за окном, а они! Схватили, поволокли, не объяснили ничего. И теперь сижу здесь. Мне ведь даже не говорят в чем обвиняют! А я добросовестный гражданин, я налоги плачу!\n\nЕго одолевает ярость, и вы отступаете на шаг назад - как раз вовремя, потому что прутья вновь подвергаются удару. Если этот человек и не виновен, то с головой у него явно не все в порядке.", ParseMode.Html);
                                    return;
                                default:
                                    await client.SendMessage(_adminChatId,
                                        $"{user.FirstName} {user.LastName}: {message.Text}");
                                    await client.SendMessage(chat.Id, "Неверный запрос");
                                    return;
                                    
                            }
                            return;
                        }
                    }

                    return;
                }
                default:
                {
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static Task ErrorHandler(ITelegramBotClient botClient, Exception exception, CancellationToken ct)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException =>
                $"Error {apiRequestException.ErrorCode}: {apiRequestException.Message}",
            _ => exception.ToString()
        };
        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }
}