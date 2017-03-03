using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePang
{
    public class InputBase
    {
       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAction"></param>
        /// <returns></returns>
        public virtual bool IsActionPressed(eAction pAction)
        {           
            return false;
        }
    }
}
