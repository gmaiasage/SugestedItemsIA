using SugestedItemsIA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {

        RecommendationItems recommendationItems;
        public Form1() {
            InitializeComponent();
            recommendationItems = new RecommendationItems();
        }

        private void button1_Click(object sender, EventArgs e) {
            var result = recommendationItems.GetItemSugetions("1");
            Console.WriteLine(result);
        }

        private void button2_Click(object sender, EventArgs e) {
            var result = recommendationItems.GetTopSales(1);
            Console.WriteLine(result);
        }
    }
}
