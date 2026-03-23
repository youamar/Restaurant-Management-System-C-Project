using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Page
{
    public partial class OrderStatus : Form
    {
        private OrderStatusControl _orderStatusControl;

        public OrderStatus()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            _orderStatusControl = new OrderStatusControl(this, lststatus);
            _orderStatusControl.LoadOrderStatus();
        }
    }
}
