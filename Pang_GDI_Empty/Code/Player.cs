using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePang
{
    public class Player
    {

        public string mTextureName = "";
        public SMX.Maths.Vector2 mPos = new SMX.Maths.Vector2(100,100);
        public SMX.Maths.Vector2 mSpeedPxS;
        public float DefaultHorizontalSPeedPxS = 500f;
        public const float PlayerWidth = 128;
        public const float PlayerHeight = 128;
        public int mCurrentAnimationIdx = 0;
        private float mContadorDeTiempoAnimacion = 0;

        private List<SMX.Maths.Rectangle> mWalkAnimationSourceRectangles = new List<SMX.Maths.Rectangle>()
        {

            new SMX.Maths.Rectangle {X = 12, Y = 2, Width = 30, Height =  32},
            new SMX.Maths.Rectangle {X = 46, Y = 3, Width = 30, Height =  31},
            new SMX.Maths.Rectangle {X = 80, Y = 2, Width = 30, Height =  32},
            new SMX.Maths.Rectangle {X = 114, Y = 3, Width = 28, Height =  31},
            new SMX.Maths.Rectangle {X = 148, Y = 3, Width = 30, Height =  31}


        };

        public enum ePlayerState
        {

            Idle,
            WalkRight,
            WalkLeft,
            Up,
            Down,
            Shoot,
            Undefined

        }

        public ePlayerState mState = ePlayerState.Idle;

        private SMX.Maths.Rectangle mSpriteSourceRectangle;
    
        public void onFrameMove()
        {

            mSpeedPxS += Game.mGravityVel * Game.mDt;
            mPos += mSpeedPxS * Game.mDt;

            mState = ePlayerState.Idle;
            if (Game.mInput.IsActionPressed(eAction.Left))
            {

                mPos.X -= DefaultHorizontalSPeedPxS * Game.mDt;
                mState = ePlayerState.WalkLeft;


            } else if (Game.mInput.IsActionPressed(eAction.Right))
            {

                mPos.X += DefaultHorizontalSPeedPxS * Game.mDt;
                mState = ePlayerState.WalkRight;

            }

            //Restricciones para que no se salga de la pantalla
            mPos.X = Math.Min(mPos.X, Game.DefaultGameWidth - PlayerWidth);
            mPos.X = Math.Max(mPos.X, 0);
            mPos.Y = Math.Min(mPos.Y, Game.DefaultGameHeight - PlayerHeight);
            mPos.Y = Math.Max(mPos.Y, 0);

            //Animacion del personaje
            float limitetiempo;
            switch (mState)
            {
                case ePlayerState.Idle:
                    mSpriteSourceRectangle = mWalkAnimationSourceRectangles[mCurrentAnimationIdx];
                    break;
                case ePlayerState.WalkLeft:
                    mContadorDeTiempoAnimacion += Game.mDt;
                    limitetiempo = 1f / 12f;

                    if (mContadorDeTiempoAnimacion > limitetiempo)
                    {
                        mContadorDeTiempoAnimacion = 0;
                        mCurrentAnimationIdx++;
                        if (mCurrentAnimationIdx >= mWalkAnimationSourceRectangles.Count)
                        {
                            mCurrentAnimationIdx = 0;
                        }

                        mSpriteSourceRectangle = mWalkAnimationSourceRectangles[mCurrentAnimationIdx];

                    }
                    break;
                case ePlayerState.WalkRight:
                    mContadorDeTiempoAnimacion += Game.mDt;
                    limitetiempo = 1f / 12f;

                    if (mContadorDeTiempoAnimacion > limitetiempo)
                    {
                        mContadorDeTiempoAnimacion = 0;
                        mCurrentAnimationIdx++;
                        if (mCurrentAnimationIdx >= mWalkAnimationSourceRectangles.Count)
                        {
                            mCurrentAnimationIdx = 0;
                        }

                        mSpriteSourceRectangle = mWalkAnimationSourceRectangles[mCurrentAnimationIdx];

                    }
                    break;

            }
            
            
        }
        public void onFrameRender()
        {

            float currentPlayerWidth = PlayerWidth;
            float currentPosX = mPos.X;
            if (mState == ePlayerState.WalkLeft)
            {
                currentPlayerWidth = -PlayerWidth;
                currentPosX += PlayerWidth;
            }

            Game.mRenderer.DrawSprite(mTextureName, mSpriteSourceRectangle.X, mSpriteSourceRectangle.Y, mSpriteSourceRectangle.Width, mSpriteSourceRectangle.Height, currentPosX, mPos.Y, currentPlayerWidth, PlayerHeight);


        }
    }

}
