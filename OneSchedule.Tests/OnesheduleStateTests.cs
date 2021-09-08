using Moq;
using NUnit.Framework;
using OneSchedule.Data.Abstractions;
using OneSchedule.Domain.Abstractions.StateMachine;
using OneSchedule.Domain.Models;
using OneSchedule.Domain.StateMachine.AskState;
using OneSchedule.Domain.StateMachine.GetState;
using OneSchedule.Entities;
using OneSchedule.Exceptions.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace OneSchedule.Tests
{
    public class OnesheduleStateTests
    {
        private Mock<ITelegramBotClient> _botMoq;
        private readonly Mock<IStateContext> _stateContextMoq;

        public OnesheduleStateTests()
        {
            _botMoq = new Mock<ITelegramBotClient>();
            _stateContextMoq = new Mock<IStateContext>();
        }

        [Test]
        public async Task AskBeginDateState_IsCompleted()
        {
            _botMoq = new Mock<ITelegramBotClient>();
            var chatId = "123";
            var state = new AskBeginDateState(_botMoq.Object);
            var dto = new DtoDomain() { ChatId = chatId };

            _stateContextMoq.Setup(o => o.ContextEntity).Returns(new ContextEntity());
            _botMoq.Setup(o => o.SendTextMessageAsync(chatId, It.IsAny<string>(), ParseMode.Default, null, false, false, 0, false, null, default));

            await state.HandleAsync(_stateContextMoq.Object, dto);

            _botMoq.Verify(o => o.SendTextMessageAsync(chatId, It.IsAny<string>(), ParseMode.Default, null, false, false, 0, false, null, default), Times.Once);
            Assert.AreEqual("AskBeginDate", _stateContextMoq.Object.ContextEntity.LastState);
        }

        [Test]
        public async Task AskDescriptionState_IsCompleted()
        {
            _botMoq = new Mock<ITelegramBotClient>();
            var chatId = "123";
            var state = new AskDescriptionState(_botMoq.Object);
            var dto = new DtoDomain() { ChatId = chatId };

            _stateContextMoq.Setup(o => o.ContextEntity).Returns(new ContextEntity());
            _botMoq.Setup(o => o.SendTextMessageAsync(chatId, It.IsAny<string>(), ParseMode.Default, null, false, false, 0, false, null, default));

            await state.HandleAsync(_stateContextMoq.Object, dto);

            _botMoq.Verify(o => o.SendTextMessageAsync(chatId, It.IsAny<string>(), ParseMode.Default, null, false, false, 0, false, null, default), Times.Once);
            Assert.AreEqual("AskDescription", _stateContextMoq.Object.ContextEntity.LastState);
        }

        [Test]
        public async Task AskEndDateState_IsCompleted()
        {
            _botMoq = new Mock<ITelegramBotClient>();
            var chatId = "123";
            var state = new AskEndDateState(_botMoq.Object);
            var dto = new DtoDomain() { ChatId = chatId };

            _stateContextMoq.Setup(o => o.ContextEntity).Returns(new ContextEntity());
            _botMoq.Setup(o => o.SendTextMessageAsync(chatId, It.IsAny<string>(), ParseMode.Default, null, false, false, 0, false, null, default));

            await state.HandleAsync(_stateContextMoq.Object, dto);

            _botMoq.Verify(o => o.SendTextMessageAsync(chatId, It.IsAny<string>(), ParseMode.Default, null, false, false, 0, false, null, default), Times.Once);
            Assert.AreEqual("AskEndDate", _stateContextMoq.Object.ContextEntity.LastState);
        }

        [Test]
        public async Task AskEventListState_IsCompleted()
        {
            _botMoq = new Mock<ITelegramBotClient>();
            var chatId = "123";
            var state = new AskEventListState(_botMoq.Object);
            var dto = new DtoDomain() { ChatId = chatId };

            _stateContextMoq.Setup(o => o.ContextEntity).Returns(new ContextEntity());
            _botMoq.Setup(o => o.SendTextMessageAsync(chatId, It.IsAny<string>(), ParseMode.Default, null, false, false, 0, false, null, default));

            await state.HandleAsync(_stateContextMoq.Object, dto);

            _botMoq.Verify(o => o.SendTextMessageAsync(chatId, It.IsAny<string>(), ParseMode.Default, null, false, false, 0, false, null, default), Times.Once);
            Assert.AreEqual("AskEventList", _stateContextMoq.Object.ContextEntity.LastState);
        }

        [Test]
        public async Task AskNotificationsState_IsCompleted()
        {
            _botMoq = new Mock<ITelegramBotClient>();
            var chatId = "123";
            var state = new AskNotificationsState(_botMoq.Object);
            var dto = new DtoDomain() { ChatId = chatId };

            _stateContextMoq.Setup(o => o.ContextEntity).Returns(new ContextEntity());
            _botMoq.Setup(o => o.SendTextMessageAsync(chatId, It.IsAny<string>(), ParseMode.Default, null, false, false, 0, false, null, default));

            await state.HandleAsync(_stateContextMoq.Object, dto);

            _botMoq.Verify(o => o.SendTextMessageAsync(chatId, It.IsAny<string>(), ParseMode.Default, null, false, false, 0, false, null, default), Times.Once);
            Assert.AreEqual("AskNotifications", _stateContextMoq.Object.ContextEntity.LastState);
        }

        [Test]
        public async Task AskTitleState_IsCompleted()
        {
            _botMoq = new Mock<ITelegramBotClient>();
            var chatId = "123";
            var state = new AskTitleState(_botMoq.Object);
            var dto = new DtoDomain() { ChatId = chatId };

            _stateContextMoq.Setup(o => o.ContextEntity).Returns(new ContextEntity());
            _botMoq.Setup(o => o.SendTextMessageAsync(chatId, It.IsAny<string>(), ParseMode.Default, null, false, false, 0, false, null, default));

            await state.HandleAsync(_stateContextMoq.Object, dto);

            _botMoq.Verify(o => o.SendTextMessageAsync(chatId, It.IsAny<string>(), ParseMode.Default, null, false, false, 0, false, null, default), Times.Once);
            Assert.AreEqual("AskTitle", _stateContextMoq.Object.ContextEntity.LastState);
        }

        [Test]
        public async Task AskEventMenuState_IsCompleted()
        {
            _botMoq = new Mock<ITelegramBotClient>();
            var chatId = "123";
            var state = new AskEventMenuState(_botMoq.Object);
            var dto = new DtoDomain() { ChatId = chatId };

            _stateContextMoq.Setup(o => o.ContextEntity).Returns(new ContextEntity() { Event = new EventEntity() { Id = "55566" } });
            _botMoq.Setup(o => o.SendTextMessageAsync(chatId, It.IsAny<string>(), ParseMode.Default, null, false, false, 0, false, It.IsAny<ReplyKeyboardMarkup>(), default));

            await state.HandleAsync(_stateContextMoq.Object, dto);

            _botMoq.Verify(o => o.SendTextMessageAsync(chatId, It.IsAny<string>(), ParseMode.Default, null, false, false, 0, false, It.IsAny<ReplyKeyboardMarkup>(), default), Times.Once);
            Assert.AreEqual(null, _stateContextMoq.Object.ContextEntity.LastState);
        }

        [Test]
        public async Task AskMainMenuState_IsCompleted()
        {
            _botMoq = new Mock<ITelegramBotClient>();
            var chatId = "123";
            var state = new AskMainMenuState(_botMoq.Object);
            var dto = new DtoDomain() { ChatId = chatId };

            _stateContextMoq.Setup(o => o.ContextEntity).Returns(new ContextEntity() { Event = new EventEntity() { Id = "55566" } });
            _botMoq.Setup(o => o.SendTextMessageAsync(chatId, It.IsAny<string>(), ParseMode.Default, null, false, false, 0, false, It.IsAny<ReplyKeyboardMarkup>(), default));

            await state.HandleAsync(_stateContextMoq.Object, dto);

            _botMoq.Verify(o => o.SendTextMessageAsync(chatId, It.IsAny<string>(), ParseMode.Default, null, false, false, 0, false, It.IsAny<ReplyKeyboardMarkup>(), default), Times.Once);
            Assert.AreEqual(null, _stateContextMoq.Object.ContextEntity.LastState);
        }

        [Test]
        public async Task AskShowEventListState_IsCompleted()
        {
            var repository = new Mock<IRepository<EventEntity>>();
            repository.Setup(o => o.FindAsync(It.IsAny<Expression<Func<EventEntity, bool>>>())).Returns(Task.Run(() => new List<EventEntity>()));
            _botMoq = new Mock<ITelegramBotClient>();
            var chatId = "123";
            var state = new AskShowEventListState(_botMoq.Object, repository.Object);
            var dto = new DtoDomain() { ChatId = chatId };

            _stateContextMoq.Setup(o => o.ContextEntity).Returns(new ContextEntity() { Event = new EventEntity() { Id = "55566" } });
            _botMoq.Setup(o => o.SendTextMessageAsync(chatId, It.IsAny<string>(), ParseMode.Default, null, false, false, 0, false, It.IsAny<ReplyKeyboardMarkup>(), default));

            await state.HandleAsync(_stateContextMoq.Object, dto);

            _botMoq.Verify(o => o.SendTextMessageAsync(chatId, It.IsAny<string>(), ParseMode.Default, null, false, false, 0, false, It.IsAny<ReplyKeyboardMarkup>(), default), Times.Once);
            Assert.AreEqual(null, _stateContextMoq.Object.ContextEntity.LastState);
        }

        [Test]
        public async Task GetDescriptionState_IsCompleted()
        {
            var chatId = "123";
            var dto = new DtoDomain() { ChatId = chatId };
            var state = new GetDescriptionState();

            _stateContextMoq.Setup(o => o.ContextEntity).Returns(new ContextEntity(){Event = new EventEntity()});
            
            await state.HandleAsync(_stateContextMoq.Object, dto);

            Assert.AreEqual("GetDescription", _stateContextMoq.Object.ContextEntity.LastState);
        }
        
        [Test]
        public void GetBeginDateState_WrongDateFormat()
        {
            var chatId = "123";
            var dto = new DtoDomain() { ChatId = chatId,MessageText = "tnn"};
            var state = new GetBeginDateState();

            _stateContextMoq.Setup(o => o.ContextEntity).Returns(new ContextEntity(){Event = new EventEntity()});

            Assert.Catch<BotAppInternalException>(() => state.HandleAsync(_stateContextMoq.Object, dto));
        }

        [Test]
        public async Task GetBeginDateState_IsCompleted()
        {
            var chatId = "123";
            var dto = new DtoDomain() { ChatId = chatId, MessageText = "1995-04-07T00:00:00" };
            var state = new GetBeginDateState();

            _stateContextMoq.Setup(o => o.ContextEntity).Returns(new ContextEntity() { Event = new EventEntity() });

            await state.HandleAsync(_stateContextMoq.Object, dto);
            Assert.AreEqual("GetBeginDate", _stateContextMoq.Object.ContextEntity.LastState);
        }
    }
}