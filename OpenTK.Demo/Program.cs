using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace OpenTK.Demo
{
    class MyWindow : GameWindow
    {
        private bool loaded = false;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            loaded = true;
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            if (loaded)
            {
                GL.ClearColor(1.0f, 0.0f, 0.0f, 1.0f);
                GL.Clear(ClearBufferMask.ColorBufferBit);
                base.SwapBuffers();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            var w = new MyWindow();
            w.Run();
        }
    }
}
