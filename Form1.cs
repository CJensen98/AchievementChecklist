using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace AchievementChecklist;

public partial class Form1 : Form
{
    
    string path = "userData.txt";

    public Form1()
    {
        InitializeComponent();
            
        var label = new Label { Text = "Enter text:", Location = new Point(10, 10), AutoSize = true };
        Controls.Add(label);

        var textBox = new TextBox { Location = new Point(10, 40), Width = 200 };
        Controls.Add(textBox);

        var button = new Button { Text = "Submit", Location = new Point(10, 70) };
        // button.Click += (s, e) => MessageBox.Show("stop clicking me");
        Controls.Add(button);

        // var checkBox = new CheckBox { Text = "Check me", Location = new Point(10, 100) };
        // checkBox.CheckedChanged += (s, e) => MessageBox.Show(checkBox.Checked ? "Checked!" : "Unchecked!");
        // Controls.Add(checkBox);

        if(!File.Exists(path))
        {
            File.Create(path).Close();
        }

        var box = new CheckedListBox { Location = new Point(10, 130), Width = 200, Height = 100 };
        var lines = File.ReadAllLines(path);
        box.Items.AddRange(lines);

        button.Click += (s, e) => 
        {
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                string text = textBox.Text;
                box.Items.Add(text);
                File.AppendAllText(path, text + Environment.NewLine);
                textBox.Clear();
            }
        };

        // button.Click += (s, e) => box.Items.AddRange(items.ToArray());
        // box.Items.AddRange(new[] { "Option 1", "Option 2", "Option 3" });

        
        box.SelectedIndexChanged += (s, e) => MessageBox.Show($"Selected: {box.SelectedItem}");
        Controls.Add(box);

        // textBox.TextChanged += (s, e) => label.Text = $"You entered: {textBox.Text}";
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        // This method is called when the form loads. You can add any initialization code here.
    } 
}
