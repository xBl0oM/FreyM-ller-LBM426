using System;
using System.Collections.Generic;


interface IObserver
{
    void Update(int newBankCredits);
}


interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}


class Bank : ISubject
{
    private int _bankCredits;
    private List<IObserver> _observers = new List<IObserver>();

    public int BankCredits
    {
        get { return _bankCredits; }
        set
        {
            if (_bankCredits != value)
            {
                _bankCredits = value;
                Notify(); 
            }
        }
    }

    public Bank(int bankCredits)
    {
        _bankCredits = bankCredits;
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_bankCredits);
        }
    }
}

// Beispielklasse, die als Observer fungiert
class BankObserver : IObserver
{
    public void Update(int newBankCredits)
    {
        Console.WriteLine($"Neuer Bankkontostand: {newBankCredits}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank(1000);
        BankObserver observer = new BankObserver();

        // Observer an das Subject anhängen
        bank.Attach(observer);

        // Änderung am Bankkontostand durchführen
        bank.BankCredits += 500;

        Console.ReadLine();
    }
}