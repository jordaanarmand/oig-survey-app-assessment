﻿namespace OIG.Survey.Data.Database.Entities;

public class Respondent
{
    public long Id { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public Guid? DeviceId { get; set; }
}