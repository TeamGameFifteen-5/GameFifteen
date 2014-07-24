using Game.Common;
using Game.UI.IOProviders;
using Game.UI.KeyMappings;
using Game.UI.Windows.Forms.IOProviders.Settings;
using Game.UI.Windows.Forms.KeyMappings;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Game.UI.Windows.Forms.IOProviders
{
	public class WindowsFormsIOProvider : IOProvider<Keys>
	{
		private Font _drawFont = new Font("Arial", 16);
		private SolidBrush _drawBrush = new SolidBrush(Color.White);
		private float _x;
		private float _y;
		private float _characterWidth;
		private float _characterHeight;
		private StringFormat _drawFormat = new StringFormat();

		private IKeyMapping<Keys> _keyMapping;

		private IGameForm _gameForm;
		private Graphics _graphics;

		public WindowsFormsIOProvider(IGameForm gameForm)
			: base(new WindowsFormsIOProviderSettings())
		{
			this._gameForm = gameForm;
			this._graphics = this._gameForm.CreateGraphics();

			var sizeF = this.MeasureText("M");
			this._characterWidth = sizeF.Width;
			this._characterHeight = sizeF.Height;
		}

		protected override IKeyMapping<Keys> KeyMapping
		{
			get
			{
				if (this._keyMapping == null)
				{
					this._keyMapping = new WindowsFormsKeyMapping();
				}
				return this._keyMapping;
			}
		}

		public override string GetTextInput()
		{
			while (true)
			{
				Thread.Sleep(1000);
			}
		}

		public override ActionType GetKeyInput(bool displayKey = false)
		{
			while (!this._gameForm.LastKey.HasValue)
			{
				Thread.Sleep(100);
			}

			var actionType = this.KeyMapping.Map(this._gameForm.LastKey.Value);
			this._gameForm.LastKey = null;

			return actionType;
		}

		public override void Display(string output = null)
		{
			if (output == null)
			{
				this._y += this._characterHeight;
			}
			else
			{
				this.DrawString(output);
				this._x += this._characterWidth;
			}
		}

		public override void Display(string format, params string[] args)
		{
			var output = string.Format(format, args);
			this.DrawString(output);
			this._x += this._characterWidth;
		}

		public override void DisplayLine(string output = null)
		{
			if (output == null)
			{
				this._y += this._characterHeight;
			}
			else
			{
				this.DrawString(output);
				var sizeF = this.MeasureText(output);
				this._x = 0;
				this._y += sizeF.Height;
			}
		}

		public override void DisplayLine(string format, params string[] args)
		{
			var output = string.Format(format, args);
			this.DrawString(output);
			var sizeF = this.MeasureText(output);
			this._x = 0;
			this._y += sizeF.Height;
		}

		public override void ChangeColor(System.Drawing.Color color)
		{
			this._drawBrush = new SolidBrush(color);
		}

		public override void ChangeStyle(IOStyleType style)
		{
		}

		public override void Invalidate()
		{
			this._graphics.Clear(Color.Black);
			this._x = 0;
			this._y = 0;
		}

		private void RunOnUIThread(Action action)
		{
			this._gameForm.Execute(action);
		}

		private void DrawString(string output)
		{
			this.RunOnUIThread(() =>
			{
				this._graphics.DrawString(output, _drawFont, _drawBrush, _x, _y, _drawFormat);
			});
		}

		private SizeF MeasureText(string text)
		{
			var sizeF = this._graphics.MeasureString(text, this._drawFont, new PointF(this._x, this._y), this._drawFormat);
			return sizeF;
		}
	}
}