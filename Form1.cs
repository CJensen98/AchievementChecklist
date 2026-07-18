using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace AchievementChecklist;

public partial class Form1 : Form
{
    private readonly string datapath = "userData.txt";


    public Form1()
    {
        InitializeComponent();
         
        var label = new Label { Text = "Enter text:", Location = new Point(10, 10), AutoSize = true };
        Controls.Add(label);

        var textBox = new TextBox { Location = new Point(10, 40), Width = 200 };
        Controls.Add(textBox);


        var button = new Button { Text = "Submit", Location = new Point(10, 70) };
        Controls.Add(button);

        var box = new CheckedListBox { Location = new Point(10, 130), Width = 200, Height = 100 };
        Controls.Add(box);


        var checkBox = new CheckBox { Text = "Check me", Location = new Point(10, 100) };
        checkBox.CheckedChanged += (s, e) => MessageBox.Show(checkBox.Checked ? "Checked!" : "Unchecked!");
        Controls.Add(checkBox);

        EnsuredataFileExists();

        
        
        var lines = File.ReadAllLines(datapath);
        box.Items.AddRange(lines);

        button.Click += (s, e) => 
        {
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                string text = textBox.Text;
                box.Items.Add(text);
                File.AppendAllText(datapath, text + Environment.NewLine);
                textBox.Clear();
            }
        };

        box.ItemCheck += (s, e) =>
        {
            string checkedItem = box.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked)
            {
                box.Items[e.Index] = checkedItem + " (Completed)";
            }
        };

        // button.Click += (s, e) => box.Items.AddRange(items.ToArray());
        // box.Items.AddRange(new[] { "Option 1", "Option 2", "Option 3" });

        

        // textBox.TextChanged += (s, e) => label.Text = $"You entered: {textBox.Text}";
    }

    private void InitilizeControls()
    {
        var label = new Label { Text = "Enter text:", Location = new Point(10, 10), AutoSize = true };
        Controls.Add(label);

        var textBox = new TextBox { Location = new Point(10, 40), Width = 200 };
        Controls.Add(textBox);

        var button = new Button { Text = "Submit", Location = new Point(10, 70) };
        Controls.Add(button);

        var box = new CheckedListBox { Location = new Point(10, 130), Width = 200, Height = 100 };
        Controls.Add(box);
    }

    private void EnsuredataFileExists()
    {
        if (!File.Exists(datapath))
        {
            File.Create(datapath).Close();
        }
    }


}
