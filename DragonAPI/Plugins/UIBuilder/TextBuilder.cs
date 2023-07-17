using System;
using System.Drawing;
using System.Windows.Forms;

namespace DragonAPI.Plugins.UIBuilder
{
    public class TextBuilder
    {
        public static void DrawText(Form SourceForm, string Content)
        {
            Label label = new Label();
            label.Text = Content;
            label.Location = new Point(0,0);
            label.AutoSize = true;
            SourceForm.Controls.Add(label);
        }
        public static void DrawText(Form SourceForm, string Content, Point Location)
        {
            Label label = new Label();
            label.Text = Content;
            label.Location = Location;
            label.AutoSize = true;
            SourceForm.Controls.Add(label);
        }
        public static void DrawText(Form SourceForm, string Content, Point Location, Size SizeOfText)
        {
            Label label = new Label();
            label.Text = Content;
            label.Location = Location;
            label.AutoSize = false;
            label.Size = SizeOfText;
            SourceForm.Controls.Add(label);
        }
        public static void DrawText(Form SourceForm, string Content, Size SizeOfText)
        {
            Label label = new Label();
            label.Text = Content;
            label.Location = new Point(0,0);
            label.AutoSize = false;
            label.Size = SizeOfText;
            SourceForm.Controls.Add(label);
        }
    }
}
