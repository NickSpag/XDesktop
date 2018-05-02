using System;
using System.Collections.Generic;
using System.Text;

#if __MAC__
using Foundation;
#endif

namespace XDesktop.Shared.Models
{
    public class Item : BaseModel
    {
        private string _name;

        public Item()
        {

        }

#if __MAC__
        [Export("Name")]
#endif
        public string Name
        {
            get => _name;
            set
            {
                SetProperty(ref _name, value);
            }
        }
    }
}
