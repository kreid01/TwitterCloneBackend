using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using TwitterCloneBackend.Models;
using TwitterCloneBackend.Models.Posts;
using TwitterCloneBackend.Repositories;

namespace TwitterCloneBacked.NameSpace
{

    [ApiController]
    [Route("/")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet]
        [Route("/chat")]
        public async Task<ActionResult<Chat>> GetChat(int user1, int user2)
        {
            var chat = await _messageRepository.GetChat(user1, user2);

            return Ok(chat);
        }

        [HttpGet]
        [Route("/chat/all")]
        public async Task<ActionResult<Chat>> GetAllChats()
        {
            var chats = await _messageRepository.GetAllChats();

            return Ok(chats);
        }

        [HttpGet]
        [Route("/chat/users")]
        public async Task<ActionResult<Chat>> GetChats(int user1)
        {
            var chats = await _messageRepository.GetChats(user1);

            return Ok(chats);
        }


        [HttpGet]
        [Route("/chat/messages")]
        public async Task<ActionResult<List<Message>>> GetChatMessages(int chatId)
        {
            var messages = await _messageRepository.GetMessagesForChat(chatId);

            return Ok(messages);
        }



        [HttpPost]
        [Route("/chat")]
        public async Task<ActionResult> CreateChat(Chat newChat)
        {

            var chat = new Chat
            {
            Id = newChat.Id,
            User1 = newChat.User1,
            User2 = newChat.User2,
            User1Name = newChat.User1Name,
            User2Name = newChat.User2Name,
            User1At = newChat.User1At,
            User2At = newChat.User2At,
            User1Img = newChat.User1Img,
            User2Img = newChat.User2Img,

        };

            await _messageRepository.AddChat(chat);
            return Ok(chat);
        }

        [HttpPost]
        [Route("/chat/message")]
        public async Task<ActionResult> CreateMessage(Message newMessage)
        {

            var message = new Message
            {
                Id = newMessage.Id,
                ChatId = newMessage.ChatId,
                SenderName = newMessage.SenderName,
                MessageContent = newMessage.MessageContent,
                Created = DateTime.UtcNow,

            };

            await _messageRepository.AddMessage(message);
            return Ok(message);
        }


        [HttpDelete]
        [Route("/chat/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _messageRepository.DeleteChat(id);
            return Ok();
        }
    }
}
