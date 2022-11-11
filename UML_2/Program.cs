#region SRP_before

class Employee
{

    public string Name { get; set; }
    public string Surname { get; set; }
    public DateOnly DateOfBirth { get; set; }


    public void PrintTimeSheetReport()
    {
        // do smth...
    }

}

#endregion

#region SRP_AFTER

class TimeSheetReport
{

    public void Print(Employee2 employee)
    {
        // do smth...
    }

}

class Employee2
{

    public string Name { get; set; }
    public string Surname { get; set; }
    public DateOnly DateOfBirth { get; set; }

}

#endregion