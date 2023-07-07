using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumoApiJNS6
{
    public interface IMensaje
    {
        void shortAlert(string msg);
        void longAlert(string msg);
    }
}
