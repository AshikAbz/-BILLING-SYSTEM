using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace WpfBilling
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double bread = 30;
        double rice = 26;
        double wheat = 20;
        double sugar = 40;
        public MainWindow()
        {
            InitializeComponent();
        }
       
        public class Product
        {
            public string Slno { get; set; }
            public string Bread { get; set; }
            public string Rice { get; set; }
            public string Wheat { get; set; }
            public string sugar { get; set; }
            public string Total { get; set; }
        }
        private void Btn_Tot(object sender, RoutedEventArgs e)
        {
            double[] b = new double[7]; //array creation
            if (string.IsNullOrEmpty(txtbread.Text)) // Textbox Value Null Or Empty   Condition Checking and It's True TextBox Value Become "0"  
            { 
                txtbread.Text = "0";
            }
            b[0] = Convert.ToDouble(txtbread.Text);
            if (string.IsNullOrEmpty(txtrice.Text))
            {
                txtrice.Text = "0";
            }
            b[1] = Convert.ToDouble(txtrice.Text);

            if (string.IsNullOrEmpty(txtwheat.Text))
            {
                txtwheat.Text = "0";
            }
            b[2] = Convert.ToDouble(txtwheat.Text);
            if (string.IsNullOrEmpty(txtsugar.Text))
            {
                txtsugar.Text = "0";
            }
            b[3] = Convert.ToDouble(txtsugar.Text);
            b[4] = b[0] + b[1] + b[2]+b[3];
            txttot.Text = Convert.ToString(b[4]);

            double[] items = new double[7];
            items[0] = b[0] * bread; //store the multiplication result  of array b[] and declared variables values in array items[].  
            items[1] = b[1] * rice;
            items[2] = b[2] * wheat;
            items[3] = b[3] * sugar;
            items[4] = items[0] + items[1] + items[2] + items[3];
            txttot1.Text = Convert.ToString(items[4]); //store total valus of array in textbox

            txtbread1.Text = Convert.ToString(items[0]); //assigning Items[]array's value  To secondTextBox 
            txtrice1.Text = Convert.ToString(items[1]);
            txtwheat1.Text = Convert.ToString(items[2]);
            txtsugar1.Text = Convert.ToString(items[3]);
            txttot1.Text = Convert.ToString(items[4]);

        }
       
        private void Btn_Receipt(object sender, RoutedEventArgs e)
        {
            Product Dt = new Product(); //create an Object To Call Class Properties
            Dt.Bread =Convert.ToString (txtbread1.Text); //calling the properties from the above created class
            Dt.Rice = Convert.ToString(txtrice1.Text);
            Dt.Wheat = Convert.ToString(txtwheat1.Text);
            Dt.sugar = Convert.ToString(txtsugar1.Text);
            Dt.Total= Convert.ToString(txttot1.Text);
           dgv.Items.Add(Dt);        //add all textbox values into datagrid     
           Dt.Slno = dgv.Items.Count.ToString();// Sl no operations doing like 1,2,3...   

        }
        private void Btn_Reset(object sender, RoutedEventArgs e)
        {
            txtbread.Text = "0"; //set default value "0" when click it
            txtrice.Text = "0";
            txtwheat.Text = "0";
            txtsugar.Text = "0";
            txttot.Text = "0";
            txtbread1.Text = "0";
            txtrice1.Text = "0";
            txtwheat1.Text = "0";
            txtsugar1.Text = "0";
            txttot1.Text = String.Empty;
           // dgv.Items.Clear();

        }

        private void Btn_exit(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Close Application?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
               
            }
            else
            {
                Close();
            }
        }
        private void Btn_Print(object sender, RoutedEventArgs e)
        {
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(stack, "My First Print Job");
                }
            }
        }
        private void txtbread_TextChanged(object sender, TextChangedEventArgs e)
         {
            if (string.IsNullOrEmpty(txtbread.Text)) 
            {
                txtbread.Text ="0";
            }
            double i = Convert.ToDouble(txtbread.Text);          
            txtbread1.Text = String.Format("{0:c2}", i * bread);        //multiplication process are doing here
        }

        private void txtrice_TextChanged(object sender, TextChangedEventArgs e)
           {
            if (string.IsNullOrEmpty(txtrice.Text))
            {
                txtrice.Text = "0";
            }

            double i = Convert.ToDouble(txtrice.Text);
            txtrice1.Text = String.Format("{0:c2}", i * rice);
        }

        private void txtwheat_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtwheat.Text))
            {
                txtwheat.Text = "0";
            }

            double i = Convert.ToDouble(txtwheat.Text);
            txtwheat1.Text = String.Format("{0:c2}", i * wheat);
        }

        private void txtsugar_TextChanged(object sender, TextChangedEventArgs e)
          {
            if (string.IsNullOrEmpty(txtsugar.Text))
            {
                txtsugar.Text = "0";
            }

            double i = Convert.ToDouble(txtsugar.Text);
            txtsugar1.Text = String.Format("{0:c2}", i * sugar);

        }
       

        private void txttot_TextChanged(object sender, TextChangedEventArgs e)
        {
   
            
        }

        private void dgv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var data = dgv.SelectedItem;
            string Bread = (dgv.SelectedCells[1].Column.GetCellContent(data) as TextBlock).Text; // to show data grid value in textbox 
            txtbread.Text = Bread;
            txtbread.IsEnabled = true;

            string Rice = (dgv.SelectedCells[2].Column.GetCellContent(data) as TextBlock).Text;
            txtrice.Text = Rice;
            txtrice.IsEnabled = true;

            string Wheat = (dgv.SelectedCells[3].Column.GetCellContent(data) as TextBlock).Text;
            txtwheat.Text = Wheat;

            string sugar = (dgv.SelectedCells[4].Column.GetCellContent(data) as TextBlock).Text;
            txtsugar.Text = sugar;

            string Total = (dgv.SelectedCells[5].Column.GetCellContent(data) as TextBlock).Text;
            txttot.Text = Total;

        }
        private void PreviewTextInput1(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);  //to set maximum numbers allowed in textbox(in xaml we also wrote  PreviewTextInput="PreviewTextInput1" MaxLength="10"
        }

        private void PreviewTextInput2(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void PreviewTextInput3(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void PreviewTextInput4(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

    
    }
  
}
