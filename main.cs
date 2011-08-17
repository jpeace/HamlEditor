using System;
using System.Drawing;
using System.Windows.Forms;
 
using System.Drawing.Html;

namespace html
{
	public class HelloWorld : Form
	{
		static public void Main ()
		{
			Application.Run (new HelloWorld ());
		}
	 
		private PictureBox _imgBox;
		
		public HelloWorld ()
		{
			Button b = new Button ();
			b.Text = "Click Me!";
			b.Location = new Point(200, 10);
			b.Size = new Size(100, 30);
			b.Click += (s,e) => 
			{
				var image = new HtmlImage("<html><body><h1 style='color:red;'>Hello World!</h1></body></html>", 400, 400);
				_imgBox.Image = image.Image;
			};
			
			Controls.Add (b);
			
			_imgBox = new PictureBox();
			_imgBox.Location = new Point(50,50);
			_imgBox.Size = new Size(400,400);
			_imgBox.BorderStyle = BorderStyle.FixedSingle;
			Controls.Add(_imgBox);
			
			Width=500;
			Height=500;
		}
	}
}
