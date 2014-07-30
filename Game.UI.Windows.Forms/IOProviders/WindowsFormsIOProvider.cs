namespace Game.UI.Windows.Forms.IOProviders
{
	using Game.Common;
	using Game.Common.Utils;
	using Game.UI.IOProviders;
	using Game.UI.KeyMappings;
	using Game.UI.Windows.Forms.KeyMappings;
	using System;
	using System.Diagnostics.CodeAnalysis;
	using System.Drawing;
	using System.Threading;
	using System.Windows.Forms;

	[ExcludeFromCodeCoverage]
	public class WindowsFormsIOProvider : IOProvider<Keys>, IWindowsFormsOutputProvider
	{
		private static readonly object _Locker = new object();

        private readonly Font _drawFont = new Font("Arial", 16);
        private readonly StringFormat _drawFormat = new StringFormat();
        private readonly float _characterWidth;
        private readonly IGameForm _gameForm;
        private readonly Graphics _graphics;
        private SolidBrush _drawBrush = new SolidBrush(Color.White);
        private float _x;
        private float _y;
        private float _characterHeight;
		private IKeyMapping<Keys> _keyMapping;
        private string _currentTextInput;

		public WindowsFormsIOProvider(IGameForm gameForm)
		{
			Validation.ThrowIfNull(gameForm);

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
			this._currentTextInput = string.Empty;
			var gameForm = this._gameForm;
			while (!gameForm.LastKey.HasValue || gameForm.LastKey.Value != Keys.Enter)
			{
				while (!gameForm.LastKey.HasValue)
				{
					Thread.Sleep(100);
				}

				Keys key = gameForm.LastKey.Value;
				if (this.IsKeyLetterOrDigit(key))
				{
					var keyString = key.ToString();
					if (keyString.Length > 1)
					{
						keyString = keyString.Substring(1);
					}

					if (!gameForm.IsShiftPressed)
					{
						keyString = keyString.ToLower();
					}

					this.Display(keyString);
					gameForm.LastKey = null;
					this._currentTextInput += keyString;
				}
			}

			gameForm.LastKey = null;
			this.DisplayLine();
			return this._currentTextInput;
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
			this.ValidateFormatAndArgs(format, args);

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
			this.ValidateFormatAndArgs(format, args);

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
			this.RunOnUIThread(() =>
			{
				this._graphics.Clear(Color.DarkSeaGreen);
				this._x = 0;
				this._y = 0;
			});
		}

		public void DrawImage(Image image)
		{
			Validation.ThrowIfNull(image);

			this.RunOnUIThread(() =>
			{
				this._graphics.DrawImage(image, new PointF(_x, _y));
				this._x = 0;
				this._y += image.Height;
			});
		}

		private void DrawString(string output)
		{
			this.RunOnUIThread(() =>
			{
				this._graphics.DrawString(output, this._drawFont, this._drawBrush, this._x, this._y, this._drawFormat);
			});
		}

		private SizeF MeasureText(string text)
		{
			return this.LockGraphics<SizeF>(() =>
			{
				var sizeF = this._graphics.MeasureString(text, this._drawFont, new PointF(this._x, this._y), this._drawFormat);
				return sizeF;
			});
		}

		private void RunOnUIThread(Action action)
		{
			this.LockGraphics<bool>(() =>
			{
				this._gameForm.Execute(action);
				return true;
			});
		}

		private TResult LockGraphics<TResult>(Func<TResult> action)
		{
			lock (_Locker)
			{
				return action();
			}
		}

		private bool IsKeyLetterOrDigit(Keys key)
		{
			return this.IsKeyLetter(key) || this.IsKeyDigit(key);
		}

		private bool IsKeyLetter(Keys key)
		{
			return key >= Keys.A && key <= Keys.Z;
		}

		private bool IsKeyDigit(Keys key)
		{
			return key >= Keys.D0 && key <= Keys.D9;
		}
	}
}