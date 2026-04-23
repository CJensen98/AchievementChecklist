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
        button.Click += (s, e) => MessageBox.Show(textBox.Text);
        Controls.Add(button);

        
    }
}
