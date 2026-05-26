using System.ComponentModel.Design;

namespace AchievementChecklist;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
            
        var label = new Label { Text = "Enter text:", Location = new Point(10, 10), AutoSize = true };
        Controls.Add(label);

        var textBox = new TextBox { Location = new Point(10, 40), Width = 200 };
        Controls.Add(textBox);

        var button = new Button { Text = "Submit", Location = new Point(10, 70) };
        button.Click += (s, e) => MessageBox.Show("stop clicking me");
        Controls.Add(button);

        var checkBox = new CheckBox { Text = "Check me", Location = new Point(10, 100) };
        checkBox.CheckedChanged += (s, e) => MessageBox.Show(checkBox.Checked ? "Checked!" : "Unchecked!");
        Controls.Add(checkBox);

        var box = new ListBox { Location = new Point(10, 130), Width = 200, Height = 100 };
        box.Items.AddRange(new[] { "Option 1", "Option 2", "Option 3" });
        box.SelectedIndexChanged += (s, e) => MessageBox.Show($"Selected: {box.SelectedItem}");
        Controls.Add(box);

        // textBox.TextChanged += (s, e) => label.Text = $"You entered: {textBox.Text}";
    }
}
