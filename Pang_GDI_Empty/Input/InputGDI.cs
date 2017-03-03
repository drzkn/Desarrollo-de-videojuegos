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
    public class InputGDI : InputBase
    {
        private bool mLeftPressed;
        private bool mRightPressed;
        private bool mUpPressed;
        private bool mDownPressed;
        private bool mFirePressed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAction"></param>
        /// <returns></returns>
        public override bool IsActionPressed(eAction pAction)
        {
            switch (pAction)
            {
                case eAction.Left:
                    return mLeftPressed;
                case eAction.Right:
                    return mRightPressed;
                case eAction.Up:
                    return mUpPressed;
                case eAction.Down:
                    return mDownPressed;
                case eAction.Fire:
                    return mFirePressed;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void PreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left:
                    mLeftPressed = true;
                    break;
                case Keys.Right:
                    mRightPressed = true;
                    break;
                case Keys.Up:
                    mUpPressed = true;
                    break;
                case Keys.Down:
                    mDownPressed = true;
                    break;
                case Keys.Z:
                    mFirePressed = true;
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void KeyUp(KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left:
                    mLeftPressed = false;
                    break;
                case Keys.Right:
                    mRightPressed = false;
                    break;
                case Keys.Up:
                    mUpPressed = false;
                    break;
                case Keys.Down:
                    mDownPressed = false;
                    break;
                case Keys.Z:
                    mFirePressed = false;
                    break;
            }
        }
    }
}
