using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hsking.Mobile.WinPhone.Controls
{
    public class TransitionControlSlider:ContentControl
    {
        protected override void OnContentChanged(object oldContent, object newContent)
        {
            Debug.WriteLine("asdasd");
            base.OnContentChanged(oldContent, newContent);

        }
        
    }
}
