using System;
using System.Drawing;
using System.Drawing.Html;

namespace html
{
	interface IHtmlImage : IDisposable
	{
		int Width {get;set;}
		int Height {get;set;}
		
		string Html {get;}
		Image Image {get;}
		void Save(string path);
	}
	
	public class HtmlImage : IHtmlImage
	{
		private string _html;
		private Image _image;
		
		public HtmlImage(string html, int width, int height)
		{
			_html = html;
			_width = width;
			_height = height;
		}
		
		public Image Image 
		{
			get
			{
				if (_image == null)
				{
					_image = BuildImage(_html, _width, _height);
				}
				return _image;
			}
		}
		
		public string Html { get {return _html;} }
		
		private int _width;
		public int Width
		{
			get { return _width; }
			set
			{
				if (value <= 0) return;
				if (value != _width)
				{
					_image = BuildImage(_html, value, _height);
				}
				_width = value;
			}	
		}
		
		private int _height;
		public int Height
		{
			get { return _height; }
			set
			{
				if (value <= 0) return;
				if (value != _height)
				{
					_image = BuildImage(_html, _width, value);
				}
				_height = value;
			}
		}
		
		public void Save(string path)
		{
			throw new NotImplementedException();
		}
		
		private Image BuildImage(string html, int width, int height)
		{
			if (_image != null)
			{
				_image.Dispose();
			}
			
			var bmp = new Bitmap(width, height);
			var g = Graphics.FromImage(bmp);
			HtmlRenderer.Render(g, _html, new RectangleF(new PointF(0,0), new SizeF(_width, _height)), false);
			
			return bmp;
		}
		
		public void Dispose()
		{
			if(_image != null)
			{
				_image.Dispose();
			}
		}
	}
}

