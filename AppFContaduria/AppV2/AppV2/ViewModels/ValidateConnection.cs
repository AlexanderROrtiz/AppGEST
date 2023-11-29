using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace AppV2.ViewModels
{
    public class ValidateConnection
    {
        public bool IsInternetConnected()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                // Hay conexión a Internet
                return true;
            }
            else if (current == NetworkAccess.Local)
            {
                // Hay conectividad local, pero no acceso a Internet
                return false;
            }
            else
            {
                // No hay conexión a Internet ni conectividad local
                return false;
            }
        }
    }
}
