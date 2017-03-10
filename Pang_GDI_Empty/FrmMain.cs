using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePang
{
    public partial class FrmMain : Form
    {
        
    

        /// <summary>
        /// 
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();

            this.Location = new Point();
            

            // Carga de contenidos de forma independiente a la plataforma
            Game.LoadContents();
            Game.mRenderer.SetGameWindow(Game.DefaultGameWidth, Game.DefaultGameHeight,
                this.doubleBufferPanel1.ClientRectangle.Width,
                this.doubleBufferPanel1.ClientRectangle.Height);
        }
       
        /// <summary>
        /// 
        /// </summary>
        public void Dostep()
        {
            // Update
            Game.onFrameMove();

            // Render
            this.doubleBufferPanel1.Refresh();

        }
        /// <summary>
        /// 
        /// </summary>
        public void GameOver()
        {
            System.Windows.Forms.MessageBox.Show("Game Over");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doubleBufferPanel1_Paint(object sender, PaintEventArgs e)
        {

            (Game.mRenderer as RendererGDI).mGraphics = e.Graphics;

            Game.onFrameRender();
        }        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doubleBufferPanel1_Resize(object sender, EventArgs e)
        {
            // If screen size changes, refresh parameters for coords calculation
            Game.mRenderer.SetGameWindow(Game.DefaultGameWidth, Game.DefaultGameHeight, this.doubleBufferPanel1.ClientRectangle.Width, this.doubleBufferPanel1.ClientRectangle.Height);

            Game.onFrameRender();

        }    
        /// <summary>
        /// Handle keydown events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            (Game.mInput as InputGDI).PreviewKeyDown(e);
        }
        /// <summary>
        /// Handle keyup events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            (Game.mInput as InputGDI).KeyUp(e);
        }
    }
}
