using TwitterCloneBackend.Models;

namespace TwitterCloneBackend.Repositories
{
    public interface IMessageRepository
    {

            Task<Chat> GetChat(int user1, int user2);

            Task DeleteChat(int id);
            
            Task <List<Chat>> GetAllChats();

            Task AddMessage(Message message);

            Task <List<Message>> GetMessagesForChat(int chatId);

        Task<List<Chat>> GetChats(int user1);

            Task AddChat(Chat chat);

    }

}
