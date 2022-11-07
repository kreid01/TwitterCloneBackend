namespace TwitterCloneBackend.Hubs
{
    public class NewMessage
    {
       public string messageContent { get; set; }
        public string senderName { get; set; }

        public int chatId { get; set; }

        public string created { get; set; }
    }
}
