namespace taskadonet4
{
    public partial class Form1 : Form
    {
        private CarsContext context;
        private Car selectedCar;

        public Form1()
        {
            InitializeComponent();
            context = new CarsContext();
            UpdateListBox(context.Cars.ToList());
        }

        private void UpdateListBox(List<Car> cars)
        {
            listBox1.SelectedItem = null;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            button2.Enabled = false;
            button3.Enabled = false;
            listBox1.DataSource = null;
            listBox1.DataSource = cars;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                Car car = new Car()
                {
                    Mark = textBox1.Text,
                    Model = textBox2.Text,
                    Year = (int)numericUpDown1.Value,
                    StNumber = (int)numericUpDown2.Value,
                };
                if (context.Cars.FirstOrDefault(c => c.Mark == car.Mark && c.Model == car.Model && c.Year == car.Year && c.StNumber == car.StNumber) == null)
                {
                    context.Cars.Add(car);
                    context.SaveChanges();
                    UpdateListBox(context.Cars.ToList());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            context.Cars.Remove(context.Cars.FirstOrDefault(c => c.Mark == selectedCar.Mark && c.Model == selectedCar.Model && c.Year == selectedCar.Year && c.StNumber == selectedCar.StNumber));
            Car car = new Car()
            {
                Mark = textBox1.Text,
                Model = textBox2.Text,
                Year = (int)numericUpDown1.Value,
                StNumber = (int)numericUpDown2.Value,
            };
            if (context.Cars.FirstOrDefault(c => c.Mark == car.Mark && c.Model == car.Model && c.Year == car.Year && c.StNumber == car.StNumber) == null)
            {
                context.Cars.Add(car);
                context.SaveChanges();
                UpdateListBox(context.Cars.ToList());
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            context.Cars.Remove(context.Cars.FirstOrDefault(c => c.Mark == selectedCar.Mark && c.Model == selectedCar.Model && c.Year == selectedCar.Year && c.StNumber == selectedCar.StNumber));
            context.SaveChanges();
            UpdateListBox(context.Cars.ToList());
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                selectedCar = listBox1.SelectedItem as Car;
                textBox1.Text = selectedCar.Mark;
                textBox2.Text = selectedCar.Model;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            context.Dispose();
        }
    }
}
