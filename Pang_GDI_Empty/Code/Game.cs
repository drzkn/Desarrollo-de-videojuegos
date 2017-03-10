using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMX.Maths;

namespace SimplePang
{
    public static class Game
    {
        public static RendererBase mRenderer;
        public static InputBase mInput;
        public static int mCurrentLevelIdx;

        /// <summary>
        /// Stopwatch used to measure time
        /// </summary>
        private static System.Diagnostics.Stopwatch mStopwatch = new System.Diagnostics.Stopwatch();
        /// <summary>
        /// Assembly name, to be used across the game to load embedded resources
        /// </summary>
        public static string AssemblyName = "SimplePang";
        /// <summary>
        /// Gravity velocity, in pixels per second
        /// </summary>
        public static Vector2 mGravityVel_PixelsPerSecond = new Vector2(0, 800);
        public static float mDt;
        private static int mFPSCounter;
        private static float mTimeCounter;
        private static int mFPS;
        public static int DefaultGameWidth
        {
            get { return 1920; }
        }
        public static int DefaultGameHeight
        {
            get { return 1080; }
        }

        public static Player mPlayer = new Player();
        public static List<Level> mLevels = new List<Level>();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static float CalcDt()
        {
            // A hi-resolution timer would be used in normal circumstances
            mStopwatch.Stop();
            System.TimeSpan span = mStopwatch.Elapsed;
            mStopwatch.Reset();
            mStopwatch.Start();
            float dt = (float)span.TotalSeconds;

            // Filter out negative or too big DTs to protect the code
            dt = Math.Max(0.00001f, dt);
            dt = Math.Min(0.15f, dt);

            return dt;
        }
        /// <summary>
        /// 
        /// </summary>
        public static void onFrameMove()
        {
            // Calc time
            mDt = CalcDt();

            // Calc FPS
            mFPSCounter++;
            mTimeCounter += mDt;
            if (mTimeCounter >= 1)
            {
                mFPS = mFPSCounter;
                mFPSCounter = 0;
                mTimeCounter = 0;
            }

            // Actualizar lógica del juego
            mLevels[mCurrentLevelIdx].onFrameMove();
            mPlayer.onFrameMove();

        }

        public static void onFrameRender() { 
            // Dibujar juego
            mLevels[mCurrentLevelIdx].onFrameRender();
            mPlayer.onFrameRender();

#if(DEBUG)
            mRenderer.DrawText("FPS: "+ mFPS, 18, 10, 10, Color4.White);
#endif
        }
        /// <summary>
        /// 
        /// </summary>
        public static void LoadContents()
        {
            mRenderer = new RendererGDI();
            mInput = new InputGDI();

            mStopwatch.Reset();

            // Ir a la carpeta dónde están los recursos. Enumerarlos y coger los png
            System.IO.DirectoryInfo dinfo = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"\Resources");
            foreach(System.IO.FileInfo file in dinfo.GetFiles())
            {
                mRenderer.LoadTexture(file.FullName);
            }

            //Load texture for player
            mPlayer.mTextureName = AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Pang.png";
            mRenderer.LoadTexture(mPlayer.mTextureName);

            // Cargar todos los niveles que estén presentes en la carpeta niveles
            dinfo = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"\Levels");
            System.IO.FileInfo[] xmlFiles = dinfo.GetFiles("*.xml");
            mLevels.Clear();
            foreach (System.IO.FileInfo file in xmlFiles)
            {
                Level level = new Level();
                level.mBackgroundTextureName = System.IO.Path.ChangeExtension(file.FullName, ".png");
                mRenderer.LoadTexture(level.mBackgroundTextureName);
                mLevels.Add(level);
            }

        }
    }
}
