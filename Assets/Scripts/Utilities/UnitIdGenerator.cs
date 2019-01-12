using System;
public class UnitIdGenerator 
{
    public string getNewId() 
    {
        Guid guid = Guid.NewGuid();
        return guid.ToString();
    }
}