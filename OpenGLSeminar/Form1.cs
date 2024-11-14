using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Assets;

namespace OpenGLSeminar
{
    public partial class Form1 : Form
    {
        OpenGL gl;
        Texture texture = new Texture();

        float rcube = 0;
        float rpyr = 0;

        public Form1()
        {
            InitializeComponent();
            gl = openGLControl1.OpenGL;
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            texture.Create(gl, "crateTexture.jpg");

        }

        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();

            gl.Translate(-1.5f, 0.0f, -6.0f);
            gl.Rotate(rpyr, 0.0f, 1.0f, 0.0f);

            gl.Begin(OpenGL.GL_TRIANGLES);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0, 1, 0);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(-1, -1, 1);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(1, -1, 1);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0, 1, 0);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, 1.0f);
            gl.Color(0.0f, 1.0, 0.0f);
            gl.Vertex(1.0f, -1.0f, -1.0f);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(1.0f, -1.0f, -1.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(-1.0f, -1.0f, -1.0f);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0, 1, 0);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(-1.0f, -1.0f, -1.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.End();

            gl.LoadIdentity();

            gl.Translate(1.5f, 0.0f, -7.0f);
            gl.Rotate(rcube, 1.0f, 1.0f, 1.0f);

            texture.Bind(gl);
            gl.Begin(OpenGL.GL_QUADS);

            gl.Color(1.0f, 1.0f, 1.0f);
            gl.TexCoord(0, 0); gl.Vertex(1, 1, -1);
            gl.TexCoord(1, 0); gl.Vertex(-1, 1, -1);
            gl.TexCoord(1, 1); gl.Vertex(-1, 1, 1);
            gl.TexCoord(0, 1); gl.Vertex(1, 1, 1);

            //gl.Color(1.0f, 0.5f, 0.0f);
            gl.TexCoord(0, 0); gl.Vertex(1, -1, 1);
            gl.TexCoord(1, 0); gl.Vertex(-1, -1, 1);
            gl.TexCoord(1, 1); gl.Vertex(-1, -1, -1);
            gl.TexCoord(0, 1); gl.Vertex(1, -1, -1);

            //gl.Color(1.0f, 0.0f, 0.0f);
            gl.TexCoord(0, 0); gl.Vertex(1, 1, 1);
            gl.TexCoord(1, 0); gl.Vertex(-1, 1, 1);
            gl.TexCoord(1, 1); gl.Vertex(-1, -1, 1);
            gl.TexCoord(0, 1); gl.Vertex(1, -1, 1);

            //gl.Color(1.0f, 1.0f, 0.0f);
            gl.TexCoord(0, 0); gl.Vertex(1, -1, -1);
            gl.TexCoord(1, 0); gl.Vertex(-1, -1, -1);
            gl.TexCoord(1, 1); gl.Vertex(-1, 1, -1);
            gl.TexCoord(0, 1); gl.Vertex(1, 1, -1);

            //gl.Color(1.0f, 0.0f, 1.0f);
            gl.TexCoord(0, 0); gl.Vertex(-1, 1, 1);
            gl.TexCoord(1, 0); gl.Vertex(-1, 1, -1);
            gl.TexCoord(1, 1); gl.Vertex(-1, -1, -1);
            gl.TexCoord(0, 1); gl.Vertex(-1, -1, 1);

            //gl.Color(0.0f, 0.0f, 1.0f);
            gl.TexCoord(0, 0); gl.Vertex(1, 1, -1);
            gl.TexCoord(1, 0); gl.Vertex(1, 1, 1);
            gl.TexCoord(1, 1); gl.Vertex(1, -1, 1);
            gl.TexCoord(0, 1); gl.Vertex(1, -1, -1);



            gl.End();

            rpyr += 3;
            rcube += 2;
        }

        private void openGLControl1_OpenGLInitialized(object sender, EventArgs e)
        {

        }
    }
}
