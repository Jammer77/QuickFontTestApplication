using System;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;
using QuickFont;
using System.Drawing;

namespace Test
{
    public class Game : GameWindow
    {
        QFont _quickFont;
        string _poem = "This is test!!!";
       
        public Game(): base(320, 200, GraphicsMode.Default, "")
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            float size1 = 20;
            _quickFont = new QFont("COMICATE.TTF", size1, FontStyle.Regular);
            _quickFont.Options.Colour = new Color4(0.1f, 0.1f, 0.1f, 1.0f);
            _quickFont.Options.DropShadowActive = true;
            GL.ClearColor(1.0f, 1.0f, 1.0f, 0.0f);
            GL.Disable(EnableCap.DepthTest);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            QFont.Begin();
            float width = _quickFont.Measure(_poem).Width;
            _quickFont.Print(_poem, width, QFontAlignment.Left, new Vector2(10, 40));
            GL.Disable(EnableCap.Texture2D);
            QFont.End();
            SwapBuffers();
        }

        [STAThread]
        static void Main()
        {
           using (var game = new Game())
            {
                game.Run(30.0, 0.0);
            }
        }
    }
}

