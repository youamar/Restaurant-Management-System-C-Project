using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class;

namespace Main_Page
{
    internal class MailBoxControl
    {

        private Button[] buttons;
        private List<MessageModel> messages;

        public MailBoxControl(Button[] buttons)
        {
            this.buttons = buttons;
        }

        public void LoadData()
        {
            MessageService _messageService = new MessageService("VegeMeat");
            messages = _messageService.GetMessages(SessionManager.Instance.CustomerId);


            for (int i = 0; i < buttons.Length; i++)
            {
                if (i < messages.Count)
                {
                    buttons[i].Text = $"{messages[i].reservation_id} :\n{messages[i].message}";
                    buttons[i].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    buttons[i].Visible = true;

                }
                else
                {
                    buttons[i].Visible = false;
                }
            }
        }
    }
}
