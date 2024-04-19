using System;

interface ITransaction
{
    void ExecuteTransaction();
    bool CheckTransactionStatus();
}

class FinancialTransaction : ITransaction
{
    public double Amount { get; set; }
    public DateTime TransactionDate { get; set; }
    public bool TransactionStatus { get; set; }

    public FinancialTransaction(double amount, DateTime date, bool status)
    {
        Amount = amount;
        TransactionDate = date;
        TransactionStatus = status;
    }

    public void ExecuteTransaction()
    {   
        this.TransactionStatus = true;
    }

    public bool CheckTransactionStatus() => TransactionStatus;

    public override string ToString()
    {
        return $"Amount: {Amount}\nTransactionDate: {TransactionDate}\nStatus: {TransactionStatus}\n";
    }
}

class Transaction
{
    public double Amount { get; set; }
    public DateTime TransactionDate { get; set; }

    public Transaction(double amount, DateTime transactionDate)
    {
        Amount = amount;
        TransactionDate = transactionDate;
    }

    public void Deposit(double dep)
    {
        Amount = Amount + dep;
    }

    public void Withdraw(double withd)
    {
        Amount = Amount - withd;
    }

    public override string ToString()
    {
        return $"Amount: {Amount}\nTransactionDate: {TransactionDate}\n";
    }
}

class Program
{
    static void Main(string[] args)
    {
        FinancialTransaction fin = new FinancialTransaction(24, DateTime.Now, true);
        Console.WriteLine(fin);

        FinancialTransaction fin1 = new FinancialTransaction(500, DateTime.Today, true);
        Console.WriteLine(fin1);

        Transaction fin2 = new Transaction(53, DateTime.Now);
        Console.WriteLine(fin2);
        Console.WriteLine("Depositing +55");
        fin2.Deposit(55);
        Console.WriteLine(fin2);
        Console.WriteLine("Withdrawing -100");
        fin2.Withdraw(100);
        Console.WriteLine(fin2);
    }
}