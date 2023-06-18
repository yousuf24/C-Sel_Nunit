using System;

public class Person
{
    private String _name;

    Person()
    {

    }
    Person(String S) : this()
    {
        this._name = S;
    }
    public void Introduce(String str)
    {
        //_name = str;
        Console.WriteLine($"Hello {str} this is {_name} ! ");
    }
    public String GetName { get=>_name; set=>_name=value; }
    public  Person parse(String to)
    {
        _name = to;
        return this;
    }
}
