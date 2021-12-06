using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace CraciunCatalin_Lab2
{
    public class PizzaMachine : Component
    {
    public enum PizzaType
        {
            Margherita,
            Pepperoni,
            Veggie,
            Quattro_Stagioni,
            Canibale
        }
        private PizzaType mIngredients;
        public PizzaType Ingredients
        {
            get
            {
                return mIngredients;
            }
            set
            {
                mIngredients = value;
            }
        }
        private System.Collections.ArrayList mPizzas = new System.Collections.ArrayList();
        Pizza this[int Index]
        {
            get
            {
                return (Pizza)mPizzas[Index];
            }
            set
            {
                mPizzas[Index] = value;
            }
        }

        public delegate void PizzaCompleteDelegate();
        public event PizzaCompleteDelegate PizzaComplete;

        DispatcherTimer pizzaBakeTimer;
        private void InitializeComponent()
        {
            this.pizzaBakeTimer = new DispatcherTimer();
            this.pizzaBakeTimer.Tick += new System.EventHandler(this.pizzaBakeTimer_Tick);
        }

        public PizzaMachine()
        {
            InitializeComponent();
        }

        private void pizzaBakeTimer_Tick(object sender, EventArgs e)
        {
            Pizza aPizza = new Pizza(this.Ingredients);
            mPizzas.Add(aPizza);
            PizzaComplete();
        }

        internal void MakePizzas(object margherita)
        {
            throw new NotImplementedException();
        }

        public bool Enabled
        {
            set
            {
                pizzaBakeTimer.IsEnabled = value;
            }
        }
        public int Interval
        {
            set
            {
                pizzaBakeTimer.Interval = new TimeSpan(0, 0, value);
            }
        }
        public void MakePizzas(PizzaType dIngredients)
        {
            Ingredients = dIngredients;

            switch (Ingredients)
            {
                case PizzaType.Canibale: Interval = 3; break;
                case PizzaType.Margherita: Interval = 2; break;
                case PizzaType.Pepperoni: Interval = 5; break;
                case PizzaType.Quattro_Stagioni: Interval = 7; break;
                case PizzaType.Veggie: Interval = 4; break;
            }

            pizzaBakeTimer.Start();
        }


    class Pizza
        {
            private PizzaType mIngredients; // câmp
            public PizzaType Ingredients // proprietate
            {
                get
                {
                    return mIngredients;
                }
                set
                {
                    mIngredients = value;
                }
            }
            private readonly DateTime mTimeOfCreation;

            public DateTime TimeOfCreation
            {
                get
                {
                    return mTimeOfCreation;
                }
            }
            public Pizza(PizzaType aIngredients)
            {
                mTimeOfCreation = DateTime.Now;
                mIngredients = aIngredients;
            }
        }  // end of pizza class    
    } // end of Pizza Machine 
}
