using System;
using System.Collections.Generic;
using System.Text;

namespace M4Restaurant
{
        public class OptionInsertedIncorrect : Exception
        {
            public OptionInsertedIncorrect()
            {
            }

            public OptionInsertedIncorrect(string message)
                : base(message)
            {
            }

            public OptionInsertedIncorrect(string message, Exception inner)
                : base(message, inner)
            {
            }
      


         }

    public class DishIsNotInTheList : Exception
    {
        public DishIsNotInTheList()
        {
        }

        public DishIsNotInTheList(string message)
            : base(message)
        {
        }

        public DishIsNotInTheList(string message, Exception inner)
            : base(message, inner)
        {
        }



    }

}
