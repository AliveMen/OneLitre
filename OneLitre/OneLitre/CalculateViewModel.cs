using System.ComponentModel;
using System.Runtime.CompilerServices;
using OneLitre.Annotations;

namespace OneLitre
{
    public class CalculateViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private decimal _price;
        private decimal _weight;
        public decimal Cost { get; set; }



        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;

                Cost = CalculateTotal();

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cost"));

            }
        }

        public decimal Weight
        {
            get => _weight;
            set
            {
                _weight = value;

                Cost = CalculateTotal();
                
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cost"));
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private decimal CalculateTotal()
        {
            return Price > 0 ? 1000 * Price / Weight : 0;
        }
    }
}