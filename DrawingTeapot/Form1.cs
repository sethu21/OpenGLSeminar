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
using SharpGL.SceneGraph.Primitives;

namespace DrawingTeapot
{
    public partial class Form1 : Form
    {
        OpenGL gl;
        float rot = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            gl.Translate(0, 1, -8);
            gl.Rotate(rot, 1, 0.5, 1);
            Teapot tp = new Teapot();
            tp.Draw(gl, 14, 1, OpenGL.GL_FILL);
            gl.End();

            rot += 2;
        }

        private void openGLControl1_OpenGLInitialized(object sender, EventArgs e)
        {
            gl = openGLControl1.OpenGL;

            gl.Enable(OpenGL.GL_DEPTH_TEST);
            float[] global_ambient = new float[] { 0.5f, 0.5f, 0.5f, 0.5f };
            float[] light0pos = new float[] { 0.0f, 5.0f, -10.0f, 1.0f };
            float[] light0ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] light0diffuse = new float[] { 0.1f, 0.9f, 0.3f, 1.0f };
            float[] light0specular = new float[] { 0.1f, 0.8f, 0.8f, 1.0f };
            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, global_ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light0pos);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, light0ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, light0diffuse);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, light0specular);
            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);
            gl.ShadeModel(OpenGL.GLU_FLAT);

        }
    }
}
