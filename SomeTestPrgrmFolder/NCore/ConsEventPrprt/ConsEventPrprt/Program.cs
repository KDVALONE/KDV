using System;
using System.Buffers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace TestObsrvbleNC
{
    class Program
    {

        static void Main(string[] args)
        {

            Phone phn = new Phone();
            Phone phn1 = new Phone();
            Console.WriteLine("Start");
            Console.WriteLine($"phone: {phn.PhoneModel}  is {phn.Owner},  \nphone:  {phn1.PhoneModel}  is {phn1.Owner},");
            Console.ReadKey();

            phn.PropertyChanged += (sender, argss) => { DoSomething(); };

            #region Commented code
            //Console.WriteLine("Add phone to collection");
            //ObservableCollection<Phone> observableCollection = new ObservableCollection<Phone>();
            //observableCollection.CollectionChanged += Phone_CollectionChanged;
            //observableCollection.Add(phn);
            //observableCollection.Add(phn1);
            #endregion

            Console.WriteLine("Changing phone owner");
            Console.ReadKey();
            PhoneOwnerChanger.ChangePhone(phn);
            Console.WriteLine($"phone:{phn.PhoneModel}  is {phn.Owner}");
            Console.ReadKey();

        }
        private static void DoSomething()
        {
            Console.WriteLine("Сработало событие измения свойства в другом классе! Ура!");
        }

        private static void Phn_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void Phone_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    Phone newPhone = e.NewItems[0] as Phone;
                    Console.WriteLine("Добавлен новый объект: {0}", newPhone.PhoneModel);
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    Phone oldPhone = e.OldItems[0] as Phone;
                    Console.WriteLine("Удален объект: {0}", oldPhone.PhoneModel);
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    Phone replacedPhone = e.OldItems[0] as Phone;
                    Phone replacingPhone = e.NewItems[0] as Phone;
                    Console.WriteLine("Объект {0} заменен объектом {1}",
                        replacedPhone.PhoneModel, replacingPhone.PhoneModel);
                    break;

            }
        }
    }
}



public class Phone
{
    private readonly List<string> _phoneName = new List<string>() { "IPhone", "Nokia", "Samsung", "Siemens" };
    private string _owner;

    public static Random rnd = new Random();
    public string PhoneModel;

    public string Owner
    {
        get => _owner;
        set
        {
            if (_owner != value)
            {
                _owner = value;
                OnPropertyChanged(nameof(Owner));
            }
        }
    }


    public Phone()
    {
        Owner = "free";
        PhoneModel = _phoneName[rnd.Next(1, _phoneName.Count)];
    }

    public Phone(string owner)
    {

        Owner = owner;
        PhoneModel = _phoneName[rnd.Next(1, _phoneName.Count)];
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName]string owner = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(owner));
    }

    public void ChangeOwner(string owner)
    {
        Owner = owner;
    }

}

public static class PhoneOwnerChanger
{
    private static Random _rnd = new Random();
    private static List<string> _onwer = new List<string>() { "Den", "Max", "Roy" };  

    public static void ChangePhone(Phone phone)
    {
        phone.Owner = _onwer[_rnd.Next(1, _onwer.Count)];
    }


}






