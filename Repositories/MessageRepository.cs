using Microsoft.EntityFrameworkCore;
using System;
using TwitterCloneBackend.Context;
using TwitterCloneBackend.Models;

namespace TwitterCloneBackend.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IDataContext _context;

        public MessageRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task AddChat(Chat chat)
        {
            _context.Chats.Add(chat);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Chat>> GetAllChats()
        {
            return await _context.Chats.ToListAsync();
        }


        public async Task DeleteChat(int id)
        {
            var itemToDelete = await _context.Chats.FindAsync(id);
            if (itemToDelete == null)
                throw new NullReferenceException();

            _context.Chats.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }
        public async Task<Chat> GetChat(int user1, int user2)
        {
          var chat = await  _context.Chats.Where(_ => (_.User1 == user1 || _.User1 == user2) && (_.User2 == user1 || _.User2 == user2)).FirstOrDefaultAsync();

            return chat;
        }

        public async Task<List<Chat>> GetChats(int user1)
        {
            var chat = await _context.Chats.Where(_ => (_.User1 == user1 || _.User2 == user1)).ToListAsync();

            return chat;
        }

        public async Task AddMessage(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Message>> GetMessagesForChat(int chatId)
        {
            var messages = new List<Message>();

            messages = await _context.Messages.Where(_ => _.ChatId == chatId).ToListAsync();

            messages.Reverse();

            return messages;
        }

    }
}
