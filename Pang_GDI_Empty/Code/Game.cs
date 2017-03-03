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
        public static void OnFrameMove()
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
        }
        /// <summary>
        /// 
        /// </summary>
        public static void LoadContents()
        {
            mStopwatch.Reset();
        }
    }
}
