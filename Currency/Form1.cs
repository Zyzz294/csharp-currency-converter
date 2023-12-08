using System;
using System.Windows.Forms;

namespace Currency
{
    public partial class Form1 : Form
    {
        // Exchange rates (for example purposes; you would fetch these from an API in a real application)
        private readonly double usdToEuroRate = 0.85;
        private readonly double usdToGBPRate = 0.73;
        private readonly double usdToJPYRate = 110.25;

        private TextBox txtAmount;
        private ComboBox cboFromCurrency;
        private ComboBox cboToCurrency;
        private Button btnConvert;
        private Label lblResult;

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            // TextBox for entering the amount
            txtAmount = new TextBox();
            txtAmount.Location = new System.Drawing.Point(50, 50);
            txtAmount.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(txtAmount);

            // ComboBox for selecting the source currency
            cboFromCurrency = new ComboBox();
            cboFromCurrency.Location = new System.Drawing.Point(200, 50);
            cboFromCurrency.Size = new System.Drawing.Size(80, 20);
            this.Controls.Add(cboFromCurrency);

            // ComboBox for selecting the target currency
            cboToCurrency = new ComboBox();
            cboToCurrency.Location = new System.Drawing.Point(350, 50);
            cboToCurrency.Size = new System.Drawing.Size(80, 20);
            this.Controls.Add(cboToCurrency);

            // Button for triggering the conversion
            btnConvert = new Button();
            btnConvert.Location = new System.Drawing.Point(500, 50);
            btnConvert.Size = new System.Drawing.Size(90, 30);
            btnConvert.Text = "Convert";
            btnConvert.Click += btnConvert_Click;
            this.Controls.Add(btnConvert);

            // Label for displaying the result
            lblResult = new Label();
            lblResult.Location = new System.Drawing.Point(50, 100);
            lblResult.Size = new System.Drawing.Size(400, 20);
            this.Controls.Add(lblResult);

            // Initialize currencies in ComboBoxes
            cboFromCurrency.Items.AddRange(new object[] { "USD", "Euro", "GBP", "JPY" });
            cboToCurrency.Items.AddRange(new object[] { "USD", "Euro", "GBP", "JPY" });
            cboFromCurrency.SelectedIndex = 0;
            cboToCurrency.SelectedIndex = 1;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            ConvertCurrency();
        }

        private void ConvertCurrency()
        {
            // Get the amount to convert
            if (!double.TryParse(txtAmount.Text, out double amount))
            {
                MessageBox.Show("Invalid amount entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the selected currencies
            string fromCurrency = cboFromCurrency.SelectedItem.ToString();
            string toCurrency = cboToCurrency.SelectedItem.ToString();

            // Perform the conversion
            double result = PerformConversion(amount, fromCurrency, toCurrency);

            // Display the result
            lblResult.Text = $"{amount} {fromCurrency} = {result:F2} {toCurrency}";
        }

        private double PerformConversion(double amount, string fromCurrency, string toCurrency)
        {
            // Perform the conversion based on the fixed exchange rates
            double result = amount;

            switch (fromCurrency)
            {
                case "USD":
                    switch (toCurrency)
                    {
                        case "Euro":
                            result *= usdToEuroRate;
                            break;
                        case "GBP":
                            result *= usdToGBPRate;
                            break;
                        case "JPY":
                            result *= usdToJPYRate;
                            break;
                    }
                    break;

                case "Euro":
                    // Add conversion logic if needed
                    break;

                case "GBP":
                    // Add conversion logic if needed
                    break;

                case "JPY":
                    // Add conversion logic if needed
                    break;
            }

            return result;
        }
    }
}
