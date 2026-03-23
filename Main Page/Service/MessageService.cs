using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOOP;

namespace Main_Page
{
    internal class MessageService
    {
        private readonly MessageRepository _messageRepository;

        public MessageService(string connectionString)
        {
            _messageRepository = new MessageRepository(connectionString);
        }

        public List<MessageModel> GetAllMessages()
        {
            return _messageRepository.GetAllMessages();
        }

        public List<MessageModel> GetMessages(string customer_id)
        {
            return _messageRepository.GetMessages(customer_id);
        }

        public bool AddMessage(string message_id, string message, string reservation_id)
        {
            var messageModel = new MessageModel { message_id = message_id, message = message, reservation_id = reservation_id };
            return _messageRepository.AddMessage(messageModel);
        }
    }
}
