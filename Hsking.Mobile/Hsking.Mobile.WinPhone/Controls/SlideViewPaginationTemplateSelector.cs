using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hsking.Mobile.WinPhone.Controls
{
    public abstract class DataTemplateSelector : ContentControl
    {
        public virtual DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return null;
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);

            ContentTemplate = SelectTemplate(newContent, this);
        }
    }

    public class SlideViewPaginationTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Page1
        {
            get;
            set;
        }

        public DataTemplate Page2
        {
            get;
            set;
        }

        public DataTemplate Page3
        {
            get;
            set;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            switch ((int)item)
            {
                case 1:
                    return Page1;

                case 2:
                    return Page2;

                case 3:
                    return Page3;


            }

            return base.SelectTemplate(item, container);
        }
    }
}
